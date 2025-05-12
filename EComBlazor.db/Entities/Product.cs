using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }
        
        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? productImae { get; set; }

        public int? quantity { get; set; }

        public Category? category { get; set; }

        public Guid categoryId { get; set; }
    }
}
