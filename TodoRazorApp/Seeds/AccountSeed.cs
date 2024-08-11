using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Seeds
{
    public static class AccountSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoRazorAppContext(serviceProvider.GetRequiredService<DbContextOptions<TodoRazorAppContext>>()))
            {
                if (context == null || context.Account == null) throw new ArgumentNullException("Null TodoRazorAppContext");

                // シード済みであれば、後続処理を行わない
                if (context.Account.Any()) return;

                context.Account.AddRange(
                    new Account
                    {
                        Name = "太郎",
                        Mail = "taro@xxx.com",
                        Password = "taropass",
                        IsDelete = false
                    },

                    new Account
                    {
                        Name = "二郎",
                        Mail = "jiro@yyy.com",
                        Password = "jiropass",
                        IsDelete = false
                    },

                    new Account
                    {
                        Name = "三郎",
                        Mail = "saburo@zzz.com",
                        Password = "saburopass",
                        IsDelete = false
                    });
                context.SaveChanges();
            }
        }
    }
}
