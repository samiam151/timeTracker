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
using TimeTracker.ViewModels;

namespace TimeTracker.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        // private ApplicationDbContext Context;
        private TaskService TaskService;

        public TasksController(TaskService ts, ApplicationDbContext context) 
        {
            // Context = context;
            TaskService = ts;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var tasks = await TaskService.GetTasks();
            return View(tasks);
        }

        [HttpGet]
        [Route("tasks/{id}")]
        public IActionResult Details(int id)
        {
            TaskUserViewModel tvm = new TaskUserViewModel();
            
            Tasks task = TaskService.GetTaskByID(id);
            tvm.Task = task;

            User user = TaskService.GetUserByTaskID(id);

            if (user != null)
            {
                tvm.User = user;
            }
            return View(tvm);
        }

        [HttpGet]
        [Route("tasks/add")]
        public ActionResult AddTask()
        {
            return View("AddTask");
        }

        [HttpPost]
        [Route("tasks/add")]
        public async Task<ActionResult> AddTask(string name)
        {
            try
            {
                var task = await TaskService.AddTask(name);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ViewData["Error"] = ex;
                return RedirectToAction("Index");
            }
        }
    }
}