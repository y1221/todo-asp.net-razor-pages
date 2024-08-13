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
        public IList<Todo> DoneTodo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var accountId = HttpContext.Session.GetInt32("accountId");
            Todo = await _context.Todo.Where(todo => todo.AccountId == accountId && todo.IsDone == false).ToListAsync();
            DoneTodo = await _context.Todo.Where(todo => todo.AccountId == accountId && todo.IsDone == true).ToListAsync();
        }

        public async Task<IActionResult> OnGetDone(int id)
        {
            return await ChangeIsDone(id, true);
        }

        public async Task<IActionResult> OnGetReturn(int id)
        {
            return await ChangeIsDone(id, false);
        }

        private async Task<IActionResult> ChangeIsDone(int id, bool isDone)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            // 完了状態に更新
            todo.IsDone = isDone;
            _context.Attach(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
