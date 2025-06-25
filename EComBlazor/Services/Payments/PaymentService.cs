using EComBlazor.Base;
using EComBlazor.db.Entities;
using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Payments;

namespace EComBlazor.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<ResponseDto> PayMonye(decimal totalAmount, IEnumerable<Product> products, IEnumerable<CartDto> carts)
        {
            throw new NotImplementedException();
        }
    }
}
