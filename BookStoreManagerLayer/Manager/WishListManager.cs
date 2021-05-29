using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
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
        private readonly IWishListRepo wishListRepository;

        public WishListManager(IWishListRepo wishListRepository)
        {
            this.wishListRepository = wishListRepository;
        }
        public WishList AddToWishList(int UserId, int BookID)
        {
            return this.wishListRepository.AddToWishList(UserId, BookID);
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

