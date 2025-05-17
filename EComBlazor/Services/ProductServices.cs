using EComBlazor.db.Base;
using EComBlazor.db.Entities;
using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.Services
{
    class ProductServices(IGenralRepo<Product> product) : IProductService
    {
        public async Task<ResponseDto> AddAsync(ProductDto entity)
        {
             int result = await product.AddAsync()
        }

        public Task<ResponseDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProductDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateAsync(UpdateProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
