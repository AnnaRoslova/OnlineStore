using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User: IdentityUser
    {
        public string UserId = "UserId";
        public string Phone {  get; set; }
        public string Password {  get; set; }
    }
}
