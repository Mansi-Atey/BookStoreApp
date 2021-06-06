using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
   public interface ICartManager
    {
        Cart AddCartDetails(Cart cartModel);
        int DeleteCartByCartId(int cartId);
        bool UpdateCart(int CartId, Cart cartModel);
        List<CartResponse> GellAllCart();
    }
}
