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
using TimeTracker.Services;

namespace TimeTracker.Controllers {

    [Authorize]
    public class UserController : Controller 
    {
        private ApplicationDbContext _context;

        private UserService userService;

        public UserController(ApplicationDbContext context, UserService _us)
        {
            _context = context;
            userService = _us;
        }
     
        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            return _context.Users.Select(user => user.UserName).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Current() 
        {
            var user = await userService.GetCurrentUser();
            return Json(user);
        }
    }
}