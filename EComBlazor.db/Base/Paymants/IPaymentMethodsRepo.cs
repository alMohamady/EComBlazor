using EComBlazor.db.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Base.Paymants
{
    public interface IPaymentMethodsRepo
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();
    }
}
