using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs
{
    public class ProductDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public string? productImae { get; set; }

        [Required]
        public Guid? CategoryId { get; set; }
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
