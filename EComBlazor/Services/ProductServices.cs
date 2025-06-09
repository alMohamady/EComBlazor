using AutoMapper;
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
    class ProductServices(IGenralRepo<Product> product, IMapper mapper) : IProductService
    {
        public async Task<ResponseDto> AddAsync(ProductDto entity)
        {
            //try
            //{
                var mappData = mapper.Map<Product>(entity);
                int result = await product.AddAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            //}
            //catch (Exception ex)
            //{
            //    return new ResponseDto(false, ex.Message);
            //}
            return new ResponseDto(false, "Please check you server Can't save new ?!");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            try
            {
                int result = await product.DeleteAsync(id);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check you server Can't delete ?!");
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            try
            {
                var data = await product.GetAllAsync();
                if (data == null || !data.Any()) return [];
                return mapper.Map<IEnumerable<GetProductDto>>(data);
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetProductDto> GetById(Guid id)
        {
            try
            {
                var data = await product.GetById(id);
                if (data == null) return new GetProductDto();
                return mapper.Map<GetProductDto>(data);
            }
            catch
            {
                return new GetProductDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateProductDto entity)
        {
            try
            {
                var mappData = mapper.Map<Product>(entity);
                int result = await product.UpdateAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check you server Can't update ?!");
        }
    }
}
