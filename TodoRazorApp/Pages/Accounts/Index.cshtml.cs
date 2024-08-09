using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public IndexModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        [ViewData]
        public string ErrorMsg { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 未入力チェック
            if (string.IsNullOrEmpty(Account.Mail)
                || string.IsNullOrEmpty(Account.Password))
            {
                ErrorMsg = "未入力項目があります";
                return Page();
            }

            // ログインチェック
            var account = await _context.Account.FirstOrDefaultAsync(m => m.Mail == Account.Mail && m.Password == Account.Password);
            if (account == null)
            {
                ErrorMsg = "メールアドレスまたはパスワードが誤っています";
                return Page();
            }

            return RedirectToPage("../Todos/Index");
        }
    }
}
