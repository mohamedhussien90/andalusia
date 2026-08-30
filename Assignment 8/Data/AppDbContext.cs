using Assignment_8.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment_8.Data
{
   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<TaskItem> Tasks { get; set; }
        }
    
}

