using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Services
{
    public class CategoryServices : ICategoryService
    {
        public Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategoryDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
