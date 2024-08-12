using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Seeds
{
    public static class TodoSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoRazorAppContext(serviceProvider.GetRequiredService<DbContextOptions<TodoRazorAppContext>>()))
            {
                if (context == null || context.Todo == null) throw new ArgumentNullException("Null TodoRazorAppContext");

                // シード済みであれば、後続処理を行わない
                if (context.Todo.Any()) return;

                context.Todo.AddRange(
                    new Todo
                    {
                        AccountId = 1,
                        CategoryId = 1,
                        Name = "英語宿題",
                        DueDate = DateTime.Now.AddDays(3),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 1,
                        CategoryId = 2,
                        Name = "サッカースパイク手入れ",
                        DueDate = DateTime.Now.AddDays(7),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 1,
                        CategoryId = 3,
                        Name = "料理",
                        DueDate = DateTime.Now.AddDays(1),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 2,
                        CategoryId = 1,
                        Name = "数学宿題",
                        DueDate = DateTime.Now.AddDays(8),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 2,
                        CategoryId = 2,
                        Name = "野球バット手入れ",
                        DueDate = DateTime.Now.AddDays(2),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 2,
                        CategoryId = 3,
                        Name = "洗濯",
                        DueDate = DateTime.Now.AddDays(5),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 3,
                        CategoryId = 1,
                        Name = "国語宿題",
                        DueDate = DateTime.Now.AddDays(4),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 3,
                        CategoryId = 2,
                        Name = "テニスラケット手入れ",
                        DueDate = DateTime.Now,
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    },

                    new Todo
                    {
                        AccountId = 3,
                        CategoryId = 3,
                        Name = "掃除",
                        DueDate = DateTime.Now.AddDays(6),
                        Memo = "",
                        IsDone = false,
                        IsDelete = false
                    });
                context.SaveChanges();
            }
        }
    }
}
