using EComBlazor.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Base
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetById(Guid id);
        Task<ResponseDto> AddAsync(ProductDto entity);
        Task<ResponseDto> UpdateAsync(UpdateProductDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
