using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TimeTracker.Data;

namespace TimeTracker.Controllers {

    [Authorize]
    public class UserController : Controller 
    {
        private ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
     
        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            return _context.Users.Select(user => user.UserName).ToList();
        }

        [HttpGet]
        public ActionResult<string> Current() 
        {
            return User.Identity.Name;
        }
    }
}