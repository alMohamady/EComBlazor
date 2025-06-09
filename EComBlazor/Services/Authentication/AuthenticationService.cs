using AutoMapper;
using EComBlazor.Base;
using EComBlazor.db.Base.Authentication;
using EComBlazor.lib.Base;
using EComBlazor.lib.DTOs;
using EComBlazor.lib.DTOs.Identity;
using FluentValidation;

namespace EComBlazor.Services.Authentication
{
    public class AuthenticationService(ITokenManagement tokenManagement, IUserManagement userManagement
        ,IRoleManagment roleManagment, IAppLoger<AuthenticationService> logger, IMapper mapper,
        IValidator<CreateUser> createUserValidator, IValidator<LogInUser> logInUserValidator,
        IValidationServices validationServices
        ) : IAuthenticationService
    {
        public async Task<ResponseDto> CreateUser(CreateUser user)
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
