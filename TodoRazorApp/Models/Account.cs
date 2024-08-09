using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Mail { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool IsDelete { get; set; }
    }
}
