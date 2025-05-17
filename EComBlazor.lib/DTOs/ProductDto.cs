using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs
{
    public class ProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? productImae { get; set; }
    }

    public class UpdateProductDto : ProductDto
    {
        public Guid? Id { get; set; }
    }

    public class GetProductDto : ProductDto
    {
        public Guid? Id { get; set; }
        public GetCategoryDto? Category { get; set; }
    }
}
