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
        CartModel AddCartDetails(CartModel cartModel);
        bool DeleteCartByCartId(int cartId);
        bool UpdateCart(int CartId, CartModel cartModel);
        List<CartModel> GellAllCart();
    }
}
