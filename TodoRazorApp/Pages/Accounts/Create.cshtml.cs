﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public CreateModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public string ErrorMsg { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 登録済みのメールアドレスかチェック
            var account = await _context.Account.FirstOrDefaultAsync(m => m.Mail == Account.Mail);
            if (account != null)
            {
                ErrorMsg = "既に登録されたメールアドレスです";
                return Page();
            }

            // パスワード（確認）が一致しているかチェック
            if (Account.Password != Request.Form["PassConfirm"])
            {
                ErrorMsg = "パスワードが一致しません";
                return Page();
            }

            _context.Account.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
