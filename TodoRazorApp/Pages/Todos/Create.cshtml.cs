using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoRazorApp.Data;
using TodoRazorApp.Models;
using TodoRazorApp.Pages.Shared;

namespace TodoRazorApp.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        [BindProperty]
        public Todo Todo { get; set; } = default!;

        [ViewData]
        public SelectList? CategoryList { get; set; }

        public CreateModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CategoryList = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Todo.AccountId = LoginAccount._loginAccount.Id;

            if (Todo.CategoryId == 0)
            {
                Todo.CategoryId = null;
            }

            _context.Todo.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
