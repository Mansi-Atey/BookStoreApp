using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer
{
   public class WishListManager:IWishListManager
    {
        private readonly IWishListRepo wishListRepository = new WishListRepo();

        //public WishListManager(IWishListRepo wishListRepository)
        //{
        //    this.wishListRepository = wishListRepository;
        //}
        public WishList AddToWishList(WishList wishList)
        {
            return this.wishListRepository.AddToWishList(wishList);
        }
        public bool DeleteFromWishList(int UserId, int WishListId)
        {
            return this.wishListRepository.DeleteFromWishList(UserId, WishListId);
        }
       public List<WishList> ViewWishListDetails()
        {
            return this.wishListRepository.ViewWishListDetails();
        }
    }
}

