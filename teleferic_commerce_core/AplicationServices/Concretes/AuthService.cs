using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using teleferic_commerce_core.AplicationServices.İnterfaces;
using teleferic_commerce_core.DTO;
using teleferic_commerce_domain.Entities;
using teleferic_commerce_infrastructure.Extensions.TokenExtensions;
using teleferic_commerce_infrastructure.Models;

namespace teleferic_commerce_core.AplicationServices.Concretes
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ResponseModel<UserDTO> _responseModel;
        public AuthService(ResponseModel<UserDTO> _responseModel, ITokenService tokenService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            this._responseModel = _responseModel;
        }

        public async Task<ResponseModel<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                _responseModel.Success = false;
                _responseModel.Message = "User not found";
                return _responseModel;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (!result.Succeeded)
            {
                _responseModel.Success = false;
                _responseModel.Message = "Invalid password";
                return _responseModel;
            }

            var roles = await _userManager.GetRolesAsync(user);
            _responseModel.Success = true;
            _responseModel.Data = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.firstName,
                LastName = user.lastName,
                Token = _tokenService.CreateToken(user, roles)
            };
            return _responseModel;

        }

        

        public async Task<ResponseModel<UserDTO>> Register(RegisterDTO registerDTO)
        {
            var user = new ApplicationUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                firstName = registerDTO.FirstName,
                lastName = registerDTO.LastName,

            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                _responseModel.Success = false;
                string messagges = "";
                foreach(var item in result.Errors)
                {
                    messagges = messagges + item.Description;
                }
                _responseModel.Message = messagges;
                return _responseModel;
            }

            await _userManager.AddToRoleAsync(user, "user");
            var roles = await _userManager.GetRolesAsync(user);
            _responseModel.Success = true;
            _responseModel.Data = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.firstName,
                LastName = user.lastName,
                Token = _tokenService.CreateToken(user,roles)
             };
            return _responseModel;
        }
    }
}
