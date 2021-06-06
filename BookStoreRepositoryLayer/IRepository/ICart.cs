using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
   public interface ICart
    {
        Cart AddCartDetails(Cart cartModel);
        int DeleteCartByCartId(int cartId);
        bool UpdateCart(int CartId, Cart cartModel);
        List<CartResponse> GellAllCart();
    }
}
