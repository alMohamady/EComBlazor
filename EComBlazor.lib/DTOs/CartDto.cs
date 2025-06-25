using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs
{
    public class CartDto
    {
        public required Guid productId { get; set; }
        public required int QTY { get; set; }
    }
}
