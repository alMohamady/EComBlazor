using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs.Payments
{
    public class PaymentMethodDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
