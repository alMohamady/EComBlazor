using EComBlazor.lib.DTOs.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Base
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethod();
    }
}
