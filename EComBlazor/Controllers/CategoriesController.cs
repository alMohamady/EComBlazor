﻿using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService srvCategory) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await srvCategory.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await srvCategory.GetById(id);
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddNew(CategoryDto item)
        {
            var result = await srvCategory.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(UpdateCategoryDto item)
        {
            var result = await srvCategory.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvCategory.DeleteAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }
    }
}
