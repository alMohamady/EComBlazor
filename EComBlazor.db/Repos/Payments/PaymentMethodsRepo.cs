using EComBlazor.db.Base.Paymants;
using EComBlazor.db.Contexts;
using EComBlazor.db.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Repos.Payments
{
    public class PaymentMethodsRepo(AppDbContext context) : IPaymentMethodsRepo
    {
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            return await context.PaymentMethods.AsNoTracking().ToListAsync();
        }
    }
}
