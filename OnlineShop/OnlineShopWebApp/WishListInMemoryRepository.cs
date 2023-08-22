using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class WishListInMemoryRepository : IWishListRepository
    {
        private readonly List<WishList> wishLists = new List<WishList>();

        public WishList TryGetBuUserId(string userId)
        {
            return wishLists.FirstOrDefault(x => x.UserId == userId);
        }
        public void Add(ProductViewModel product, string userid)
        {
            var existingWishList = TryGetBuUserId(userid);
            if (existingWishList == null)
            {
                WishList newWishlist = new WishList
                {
                    Id = Guid.NewGuid(),
                    UserId = userid,
                    productsWishList = new List<ProductViewModel>
                    {
                        product
                    }

                };
                wishLists.Add(newWishlist);
            }
            else
            {
                var existingWishListProduct = existingWishList.productsWishList.FirstOrDefault(x => x.Id == product.Id);
                if (existingWishListProduct == null)
                {
                    existingWishList.productsWishList.Add(product);
                }
            }
        }
        public void Clear(string userid)
        {
            var existingWishList = TryGetBuUserId(userid);
            wishLists.Remove(existingWishList);
        }
        public void Delete(Guid productid, string userid)
        {
            var existingWishList = TryGetBuUserId(userid);
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
                }

            }
        }
    }
}
