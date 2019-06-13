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
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.ViewModels
{
    public class TaskUserViewModel
    {
        public TaskUserViewModel() {}

        public TaskUserViewModel(Tasks task) {
            Task = task;
        }

        public TaskUserViewModel(Tasks _task, User _user) {
            Task = _task;
            User = _user;
        }

        [Required]
        public Tasks Task { get; set; }

        public User User { get; set; }
    }
}