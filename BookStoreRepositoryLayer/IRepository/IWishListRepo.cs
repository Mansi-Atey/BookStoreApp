using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
    public interface IWishListRepo
    {
        WishList AddToWishList(WishList wishList);
        bool DeleteFromWishList(int UserId, int WishListId);
        List<WishList> ViewWishListDetails();
    }
}
