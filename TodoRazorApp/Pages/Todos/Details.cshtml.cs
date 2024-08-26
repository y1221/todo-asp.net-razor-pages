﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;
using TodoRazorApp.Pages.Shared;

namespace TodoRazorApp.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public DetailsModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public Todo Todo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountId = LoginAccount._loginAccount.Id;

            var todo = await _context.Todo.Include(todo => todo.Category).FirstOrDefaultAsync(todo => todo.AccountId == accountId && todo.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                Todo = todo;
            }
            return Page();
        }
    }
}
