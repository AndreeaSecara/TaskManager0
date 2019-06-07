using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Models
{
    public class Task_ManagerContext : DbContext
    {
        public Task_ManagerContext (DbContextOptions<Task_ManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Task_Manager.Models.Task> Task { get; set; }
    }
}
