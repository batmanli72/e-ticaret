using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using teleferic_commerce_core.DTO;
using teleferic_commerce_infrastructure.Models;

namespace teleferic_commerce_core.AplicationServices.İnterfaces
{
    public interface IAuthService
    {
        Task<ResponseModel<UserDTO>> Register(RegisterDTO registerDTO);
        Task<ResponseModel<UserDTO>> Login(LoginDTO loginDTO);
    }
}
