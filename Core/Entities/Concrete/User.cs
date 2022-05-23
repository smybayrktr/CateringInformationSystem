using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class User : IdentityUser<int>,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] HashPassword { get; set; }
        public bool Status { get; set; }
        public double Balance { get; set; }
    }
}
