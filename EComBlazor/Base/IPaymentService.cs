using EComBlazor.db.Entities;
using EComBlazor.lib.DTOs;

namespace EComBlazor.Base
{
    interface IPaymentService
    {
        Task<ResponseDto> PayMonye(decimal totalAmount, IEnumerable<Product> products, IEnumerable<CartDto> carts);
    }
}
