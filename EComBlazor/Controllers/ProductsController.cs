﻿using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService srvProcude) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await srvProcude.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await srvProcude.GetById(id);
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddNew(ProductDto item)
        {
            var result = await srvProcude.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update(UpdateProductDto item)
        {
            var result = await srvProcude.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            var result = await srvProcude.DeleteAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }
    }
}
