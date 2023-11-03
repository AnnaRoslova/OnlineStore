using OnlineShopWebApp.Models;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Допустимая длинна имени от 2 до 25 символов.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Email должен быть привязан к электронной почте.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Пароль должен быть не менее 8 символов.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [Compare("Password", ErrorMessage = "Пароли  не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
