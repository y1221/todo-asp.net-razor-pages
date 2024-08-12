using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "タスク")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "締め切り")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Display(Name = "備考")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string? Memo { get; set; }

        public bool IsDone { get; set; }

        public bool IsDelete { get; set; }
    }
}
