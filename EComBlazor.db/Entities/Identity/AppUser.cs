using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.db.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? fullName { get; set; }
    }
}
