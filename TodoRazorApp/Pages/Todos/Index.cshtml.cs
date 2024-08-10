using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public IndexModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; } = default!;

        public async Task OnGetAsync(int accountId)
        {
            var testString = HttpContext.Session.GetString("testSession");
            var testaccountId = HttpContext.Session.GetInt32("accountId");

            Todo = await _context.Todo.ToListAsync();
        }
    }
}
