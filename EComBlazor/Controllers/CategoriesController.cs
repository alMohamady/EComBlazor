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

        [HttpPost("add")]
        public async Task<IActionResult> AddNew(CategoryDto item)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await srvCategory.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCategoryDto item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await srvCategory.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvCategory.DeleteAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }
    }
}
