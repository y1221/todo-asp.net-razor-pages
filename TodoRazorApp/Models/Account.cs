namespace TodoRazorApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public bool IsDelete { get; set; }
    }
}
