using EComBlazor.Base;
using EComBlazor.db.Base.Authentication;
using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Identity;

namespace EComBlazor.Services.Authentication
{
    public class AuthenticationService(ITokenManagement tokenManagement, IUserManagement userManagement
        ,IRoleManagment roleManagment, IAppLoger<AuthenticationService> logger) : IAuthenticationService
    {
        public Task<ResponseDto> CreateUser(CreateUser user)
        {
            throw new NotImplementedException();
        }

        public Task<LogInResponseDto> LogInUser(LogInUser user)
        {
            throw new NotImplementedException();
        }

        public Task<LogInResponseDto> RetriveToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
