using System.ComponentModel.DataAnnotations;

namespace TodoRazorApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Display(Name = "ユーザ名")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "30文字以下で入力してください。")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "メールアドレス")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "30文字以下で入力してください。")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Mail { get; set; } = string.Empty;

        [Display(Name = "パスワード")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9 -/:-@[-`{-~]*$", ErrorMessage = "英数字または記号で入力してください。")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "8文字以上30文字以下で入力してください。")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Password { get; set; } = string.Empty;

        public bool IsDelete { get; set; }

        public ICollection<Todo> Todos { get; } = new List<Todo>();
    }
}
