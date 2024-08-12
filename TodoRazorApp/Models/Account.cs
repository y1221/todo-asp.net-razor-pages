using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Display(Name = "名前")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "メールアドレス")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required]
        public string Mail { get; set; } = string.Empty;

        [Display(Name = "パスワード")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9 -/:-@[-`{-~]*$")]
        [StringLength(30, MinimumLength = 8)]
        [Required]
        public string Password { get; set; } = string.Empty;

        public bool IsDelete { get; set; }
    }
}
