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

        public async Task<LogInResponseDto> LogInUser(LogInUser user)
        {
            var _validationResult = await validationServices.ValidationAsync(user, logInUserValidator);
            if (!_validationResult.success) return new LogInResponseDto(false, _validationResult.msessage);

            var mappedModel = mapper.Map<AppUser>(user);
            mappedModel.PasswordHash = user.Password;

            bool loginResult = await userManagement.LogInUser(mappedModel);
            if (!loginResult)
                return new LogInResponseDto { msessage = "invalid user credintionals" };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var cliams = await userManagement.GetUserClaims(user.Email);

            string jwtToken = tokenManagement.GenrateToken(cliams);
            string refreshToken = tokenManagement.GetRefreshToken();

            int saveTokenReult = 0;
            bool userCurrentToken = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (userCurrentToken)
                saveTokenReult = await tokenManagement.UpdateRefreshToken(_user!.Id, refreshToken);
            else
                saveTokenReult = await tokenManagement.AddRefreshToken(_user!.Id, refreshToken);
            return saveTokenReult <= 0 ? new LogInResponseDto { msessage = "Internal Server Error" } :
                new LogInResponseDto { success = true, Token = jwtToken, RefreshToken = refreshToken };
        }

        public async Task<LogInResponseDto> RetriveToken(string refreshToken)
        {
            bool validateTokenResult = await tokenManagement.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult)
                return new LogInResponseDto { msessage = "Invalid Token" };

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            AppUser? appUser = await userManagement.GetuserById(userId);
            var claims = await userManagement.GetUserClaims(appUser!.Email!);
            string newJwtToken = tokenManagement.GenrateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LogInResponseDto { success = true, Token= newJwtToken, RefreshToken = newRefreshToken };
        }
    }
}
