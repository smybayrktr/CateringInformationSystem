using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class UserRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}