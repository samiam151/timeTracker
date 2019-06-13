using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class TaskUser<TTasks, TUser>
        where TTasks : Tasks
        where TUser : User
    {
        private Tasks task;

        private User user;

        public TaskUser(Tasks _task, User _user)
        {
            task = _task;
            user = _user;
        }

        public Tasks GetTask()
        {
            return task;
        }

        public User GetUser()
        {
            return user;
        }
    }
}
