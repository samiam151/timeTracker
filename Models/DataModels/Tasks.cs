using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TimeTracker.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public TimeSpan timeSpent { get; set; }
        public string description { get; set; }
    }
}