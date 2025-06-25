using AutoMapper;
using EComBlazor.db.Base.Paymants;
using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs.Payments;

namespace EComBlazor.Services.Payments
{
    public class PaymentMethodService(IPaymentMethodsRepo repo, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<PaymentMethodDto>> GetPaymentMethod()
        {
            var methodes = await repo.GetAllPaymentMethods();
            if (!methodes.Any()) return [];
            return mapper.Map<IEnumerable<PaymentMethodDto>>(methodes);
        }
    }
}
