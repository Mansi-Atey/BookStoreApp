using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
    public interface IWishListManager
    {
        WishList AddToWishList(WishList wishList);
        bool DeleteFromWishList(int UserId, int WishListId);
        List<WishList> ViewWishListDetails();
    }
}
