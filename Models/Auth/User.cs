using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimeTracker.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public string Name { get; set; }
        public override string Email { get; set; }
    }
}