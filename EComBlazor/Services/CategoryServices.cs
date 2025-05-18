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
    public class CategoryServices(IGenralRepo<Category> category, IMapper mapper) : ICategoryService
    {
        public async Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.AddAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check you server Can't save new ?!");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            try
            {
                int result = await category.DeleteAsync(id);
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

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            try
            {
                var data = await category.GetAllAsync();
                if (data == null || !data.Any()) return [];
                return mapper.Map<IEnumerable<GetCategoryDto>>(data);
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetCategoryDto> GetById(Guid id)
        {
            try
            {
                var data = await category.GetById(id);
                if (data == null) return new GetCategoryDto();
                return mapper.Map<GetCategoryDto>(data);
            }
            catch
            {
                return new GetCategoryDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity)
        {
            try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.UpdateAsync(mappData);
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
