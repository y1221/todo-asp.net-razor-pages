using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Models;

namespace TodoRazorApp.Data
{
    public class TodoRazorAppContext : DbContext
    {
        public TodoRazorAppContext (DbContextOptions<TodoRazorAppContext> options)
            : base(options)
        {
        }

        public DbSet<TodoRazorApp.Models.Account> Account { get; set; } = default!;
    }
}
