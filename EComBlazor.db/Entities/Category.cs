using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Entities
{
    public class Category
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "field Name is reqired")]
        [MaxLength(50, ErrorMessage = "Max field Name is 50 char")]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
