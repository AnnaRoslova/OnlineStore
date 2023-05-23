using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage ="Пароль должен быть не менее 8 символов.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [Compare("Password", ErrorMessage ="Пароли  не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
