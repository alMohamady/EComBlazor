using EComBlazor.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Base
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetById(Guid id);
        Task<ResponseDto> AddAsync(CategoryDto entity);
        Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
