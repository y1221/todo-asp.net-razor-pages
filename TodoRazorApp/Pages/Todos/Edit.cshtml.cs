using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;
using TodoRazorApp.Pages.Shared;

namespace TodoRazorApp.Pages.Todos
{
    public class EditModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        [BindProperty]
        public Todo Todo { get; set; } = default!;

        [ViewData]
        public SelectList? CategoryList { get; set; }

        public EditModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountId = LoginAccount._loginAccount.Id;

            var todo =  await _context.Todo.Include(todo => todo.Account).FirstOrDefaultAsync(todo => todo.AccountId == accountId && todo.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            Todo = todo;

            CategoryList = new SelectList(_context.Category, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Todo.CategoryId == 0)
            {
                Todo.CategoryId = null;
            }

            _context.Attach(Todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(Todo.Id))
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
