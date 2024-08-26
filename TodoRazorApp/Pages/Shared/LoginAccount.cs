using TodoRazorApp.Models;

namespace TodoRazorApp.Pages.Shared
{
    public static class LoginAccount
    {
        public static bool _isLogin { get; set; }

        public static Account _loginAccount { get; set; } = default!;

        public static void Login(Account account)
        {
            _isLogin = true;
            _loginAccount = account;
        }

        public static void Logout()
        {
            _isLogin = false;
            _loginAccount = default!;
        }
    }
}
