using EComBlazor.lib.DTOs;
using FluentValidation;

namespace EComBlazor.Base
{
    public interface IValidationServices
    {
        Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator);
    }
}
