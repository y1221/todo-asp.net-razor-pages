using System;
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
    public class IndexModel : PageModel
    {
        private readonly TodoRazorApp.Data.TodoRazorAppContext _context;

        public IndexModel(TodoRazorApp.Data.TodoRazorAppContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; } = default!;
        public IList<Todo> DoneTodo { get;set; } = default!;

        public IList<Category> Category { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int SelectedCategory { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var accountId = LoginAccount._loginAccount.Id;

            var todos = _context.Todo.Where(todo => todo.AccountId == accountId && todo.IsDone == false && todo.IsDelete == false);
            var doneTodos = _context.Todo.Where(todo => todo.AccountId == accountId && todo.IsDone == true && todo.IsDelete == false);

            if (SelectedCategory != 0)
            {
                // カテゴリで絞り込む
                todos = todos.Where(todo => todo.CategoryId == SelectedCategory);
                doneTodos = doneTodos.Where(todo => todo.CategoryId == SelectedCategory);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                // 検索文字列で絞り込む
                todos = todos.Where(todo => todo.Name.Contains(SearchString));
                doneTodos = doneTodos.Where(doneTodo => doneTodo.Name.Contains(SearchString));
            }

            Todo = await todos.ToListAsync();
            DoneTodo = await doneTodos.ToListAsync();

            Category = await _context.Category.ToListAsync();
        }

        public IActionResult OnGetChangeCategoryFilter(int id)
        {
            return RedirectToPage(new { SelectedCategory = id });
        }

        public async Task<IActionResult> OnPostDoneAsync(int id)
        {
            return await ChangeIsDoneAsync(id, true);
        }

        public async Task<IActionResult> OnPostReturnAsync(int id)
        {
            return await ChangeIsDoneAsync(id, false);
        }

        private async Task<IActionResult> ChangeIsDoneAsync(int id, bool isDone)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            // 完了状態に更新
            todo.IsDone = isDone;
            _context.Attach(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage(new { SelectedCategory, SearchString });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            // 削除状態に更新
            todo.IsDelete = true;
            _context.Attach(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage(new { SelectedCategory, SearchString });
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
