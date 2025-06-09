using EComBlazor.db.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Base.Authentication
{
    public interface IUserManagement
    {
        Task<bool> CreateUser(AppUser user);
        Task<bool> LogInUser(AppUser user);
        Task<AppUser?> GetUserByEmail(string userEmail);
        Task<AppUser?> GetuserById(string userId);
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<int> RemoveUserById(string userId);
        Task<List<Claim>> GetUserClaims(string userEmail);
    }
}
