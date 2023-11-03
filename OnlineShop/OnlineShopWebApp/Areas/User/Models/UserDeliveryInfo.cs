using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage ="Введите Ваше имя.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage ="Имя должно быть от 2 до 25 символов.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Введите адрес доставки.")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Введите номер телефона.")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Введите электронный адрес.")]
        [EmailAddress(ErrorMessage ="Несуществующий почтовый домен.")]
        public string Email { get; set; }
    }
}
