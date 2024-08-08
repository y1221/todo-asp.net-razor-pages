using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int CategoryId { get; set; }

        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string? Memo { get; set; }

        public string? IsDone { get; set; }

        public string? IsDelete { get; set; }
    }
}
