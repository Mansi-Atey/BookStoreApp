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
   public class CartManager:ICartManager
    {
        private readonly ICart cartRepository;

        public CartManager(ICart cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public Cart AddCartDetails(Cart cart)
        {
            return this.cartRepository.AddCartDetails(cart);
        }

        public bool DeleteCartByCartId(int cartId)
        {
            return this.cartRepository.DeleteCartByCartId(cartId);
        }
        public bool UpdateCart(int CartID, Cart cartModel)
        {
            return this.cartRepository.UpdateCart(CartID,cartModel);
        }
        public List<Cart> GellAllCart()
        {
            return this.cartRepository.GellAllCart();
        }
    }
}
