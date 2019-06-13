using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using TimeTracker.Models;

namespace TimeTracker.Services
{
    public interface IUserService {}

    public class UserService : IUserService {
        private readonly HttpContext http;
        private readonly UserManager<User> userManager;
        public UserService(
            IHttpContextAccessor _http,
            UserManager<User> _userManager
        )
        {
            http = _http.HttpContext;
            userManager = _userManager;
        }

        public async Task<User> GetCurrentUser()
        {
            var user = await userManager.GetUserAsync(http.User);
            return user;
        }
    }    
}