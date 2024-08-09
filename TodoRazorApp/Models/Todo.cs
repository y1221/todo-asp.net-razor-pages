using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int CategoryId { get; set; }

        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Text)]
        public string? Memo { get; set; }

        public string? IsDone { get; set; }

        public string? IsDelete { get; set; }
    }
}
