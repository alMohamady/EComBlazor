using EComBlazor.Base;
using EComBlazor.lib.DTOs;
using EComBlazor.Validations.Identity;
using FluentValidation;

namespace EComBlazor.Services.Authentication
{
    public class ValidationServices : IValidationServices
    {
        public async Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator)
        {
            var _validator = await validator.ValidateAsync(model);
            if (!_validator.IsValid)
            {
                var errors = _validator.Errors.Select(e => e.ErrorMessage).ToList();
                string errorsToString = string.Join(", ", errors);
                return new ResponseDto { msessage = errorsToString };
            }
            return new ResponseDto { success = true };  
        }
    }
}
