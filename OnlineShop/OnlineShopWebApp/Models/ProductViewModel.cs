using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Введите стоимость товара.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Введите название товара.")]
        [StringLength (30, MinimumLength = 2,ErrorMessage ="Длина названия товара должна быть от 2 до 30 символов.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание товара.")]
        [StringLength(250, MinimumLength = 15, ErrorMessage ="Описание товара должно быть от 15 до 250 символов.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите цвет товара.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Описание цвета должно быть от3 до 30 символов")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Введите название производителя товара.")]
        public string Compound { get; set; }
        [Required(ErrorMessage = "Введите материал из которого изготовлен товар.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Описание материала или состава товара должно быть длиной от 3 до 150 символов.")]
        public string Manufactured { get; set; }
        [Required(ErrorMessage = "Добавьте изображение.")]
        public string ImagePath { get; set; }
    }
}
