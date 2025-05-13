using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "field Name is reqired")]
        [MaxLength(50, ErrorMessage = "Max field Name is 50 char")]
        public string? Name { get; set; }

        [MaxLength(100, ErrorMessage = "Max field Name is 50 char")]
        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? productImae { get; set; }

        public int? quantity { get; set; }

        [ForeignKey("categoryId")]
        public Category? category { get; set; }

        public Guid categoryId { get; set; }
    }
}
