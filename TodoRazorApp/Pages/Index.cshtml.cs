using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoRazorApp.Pages.Shared;

namespace TodoRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("./Accounts/Index");
        }

        public IActionResult OnGetLogout()
        {
            LoginAccount.Logout();
            return RedirectToPage("./Accounts/Index");
        }
    }
}
