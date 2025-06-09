using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Identity;

namespace EComBlazor.Base
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> CreateUser(CreateUser user);
        Task<LogInResponseDto> LogInUser(LogInUser user);
        Task<LogInResponseDto> RetriveToken(string refreshToken); 
    }
}
