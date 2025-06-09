using AutoMapper;
using EComBlazor.Base;
using EComBlazor.db.Base.Authentication;
using EComBlazor.db.Entities.Identity;
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
            var _validationResult = await validationServices.ValidationAsync(user, createUserValidator);
            if (!_validationResult.success) return _validationResult;

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.UserName = user.Email;
            mappedModel.PasswordHash = user.Password;

            var result = await userManagement.CreateUser(mappedModel);
            if (!result)
                return new ResponseDto { msessage = "There's some invalid data" };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var users = await userManagement.GetAllUsers();
            bool assignedResult = await roleManagment.AddUserToRole(_user!, users.Count() > 1 ? "User" : "Admin");

            if (!assignedResult)
            {
                int removeUser = await userManagement.RemoveUserById(_user!.Email!);
                if (removeUser <= 0)
                {
                    logger.LogError(new Exception($"User Error in use Email {_user!.Email!}"), "user error in role");
                    return new ResponseDto { msessage = "can't create new user account" };
                }
            }

            return new ResponseDto { success = true, msessage = "success user account has been created" };
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
