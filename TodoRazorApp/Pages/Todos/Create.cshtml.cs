using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public CreateModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todo.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
