using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длинна имени должна быть от 2 до 25 символов!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения.")]
        public string Password { get; set; }
        [ValidateNever]
        public bool RememberMe { get; set; }
    }
}
