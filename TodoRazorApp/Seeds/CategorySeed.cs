using Microsoft.EntityFrameworkCore;
using TodoRazorApp.Data;
using TodoRazorApp.Models;

namespace TodoRazorApp.Seeds
{
    public static class CategorySeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoRazorAppContext(serviceProvider.GetRequiredService<DbContextOptions<TodoRazorAppContext>>()))
            {
                if (context == null || context.Category == null) throw new ArgumentNullException("Null TodoRazorAppContext");

                // シード済みであれば、後続処理を行わない
                if (context.Category.Any()) return;

                context.Category.AddRange(
                    new Category
                    {
                        Name = "学校"
                    },

                    new Category
                    {
                        Name = "スポーツ"
                    },

                    new Category
                    {
                        Name = "家事"
                    });
                context.SaveChanges();
            }
        }
    }
}
