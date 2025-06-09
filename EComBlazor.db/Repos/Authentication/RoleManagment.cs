using EComBlazor.db.Base.Authentication;
using EComBlazor.db.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Repos.Authentication
{
    public class RoleManagment(UserManager<AppUser> userManager) : IRoleManagment
    {
        public async Task<bool> AddUserToRole(AppUser user, string roleName)
        {
            return (await userManager.AddToRoleAsync(user, roleName)).Succeeded;
        }

        public async Task<string?> GetUserRole(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return (await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }
    }
}
