using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoRazorApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "タスク")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "30文字以下で入力してください。")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "締め切り")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Display(Name = "備考")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "100文字以下で入力してください。")]
        public string? Memo { get; set; }

        public bool IsDone { get; set; }

        public bool IsDelete { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
