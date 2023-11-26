using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Db
{
    public enum OrderStatuses
    {  
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
}
