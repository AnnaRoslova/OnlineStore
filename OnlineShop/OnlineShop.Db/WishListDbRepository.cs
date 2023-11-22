using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class WishListDbRepository : IWishListRepository
    {
        private readonly DatabaseContext _databaseContext;

        public WishListDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }   

        public WishList TryGetByUserId(string userId)
        {
            return _databaseContext.WishLists.Include(x=>x.productsWishList).FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(Product product, string userid)
        {
            var existingWishList = TryGetByUserId(userid);
            if (existingWishList == null)
            {
                WishList newWishlist = new WishList
                {
                    UserId = userid,
                    productsWishList = new List<Product>
                    {
                        product
                    }

                };
                _databaseContext.WishLists.Add(newWishlist);
                _databaseContext.SaveChanges();
            }
            else
            {
                var existingWishListProduct = existingWishList.productsWishList.FirstOrDefault(x => x.Id == product.Id);
                if (existingWishListProduct == null)
                {
                    existingWishList.productsWishList.Add(product);
                    _databaseContext.SaveChanges();
                }
            }
        }
        public void Clear(string userid)
        {
            var existingWishList = TryGetByUserId(userid);
            _databaseContext.WishLists.Remove(existingWishList);
            _databaseContext.SaveChanges();
        }
        public void Delete(Guid productid, string userid)
        {
            var existingWishList = TryGetByUserId(userid);
            if (existingWishList == null)
            {
                return;
            }
            else
            {
                var existingWishListProduct = existingWishList?.productsWishList?.FirstOrDefault(x => x.Id == productid);
                if (existingWishListProduct == null)
                {
                    return;
                }
                else
                {
                    existingWishList.productsWishList.Remove(existingWishListProduct);
                    _databaseContext.SaveChanges();
                }

            }
        }
    }
}
