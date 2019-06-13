using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using TimeTracker.Models;
using TimeTracker.Data;

namespace TimeTracker.Services
{
    public class TaskService
    {
        private readonly UserService userService;
        private readonly ApplicationDbContext _context;

        public TaskService(UserService _us, ApplicationDbContext context)
        {
            userService = _us;
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            try
            {
                User user = await userService.GetCurrentUser();
                IEnumerable<Tasks> tasks = _context.Tasks
                    .Where(t => t.userId == user.Id);              

                return tasks;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Tasks GetTaskByID(int id)
        {
            try
            {
                Tasks task = _context.Tasks                    
                    .FirstOrDefault(t => t.id == id);
                
                return task;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public User GetUserByTaskID(int taskID){
            User userObj = null;
            string userID = _context.Tasks
                .Where(t => t.id == taskID)
                .Select(t => t.userId)
                .FirstOrDefault();
            if (!String.IsNullOrEmpty(userID)) 
            {
                userObj = _context.Users
                    .Where(user => String.Equals(user.Id, userID))
                    .FirstOrDefault();
            }
            return userObj;
        }

        public async Task<Tasks> AddTask(string taskName) { 
            using (_context)
            {    
                try
                {
                    var user = await userService.GetCurrentUser();
                    Tasks _task = new Tasks {
                        name = taskName,
                        userId = user.Id
                    };

                    _context.Tasks.Add(_task);
                    _context.SaveChanges();

                    return _task;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}