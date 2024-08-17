using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "カテゴリ")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "30文字以下で入力してください。")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Name { get; set; } = null!;

        public ICollection<Todo> Todos { get; } = new List<Todo>();
    }
}
