
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teleferic_commerce_core.AplicationServices.İnterfaces;
using teleferic_commerce_infrastructure.UoW;

namespace teleferic_commerce_core.AplicationServices.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfwork;


        public CategoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task CategoryAdd()
        {
            await _unitOfwork.Categories.AddAsync(new teleferic_commerce_domain.Entities.Category
            {
                Name = "Sample Category  ",
                Description = " this is a simple category"
            });
            await _unitOfwork.SaveAsync();
        }
    }
}
