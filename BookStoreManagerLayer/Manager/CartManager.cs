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
   public class CartManager:ICartManager
    {
        private readonly ICart cartRepository = new CartRepo();

        //public CartManager(ICart cartRepository)
        //{
        //    this.cartRepository = cartRepository;
        //}

        public Cart AddCartDetails(Cart cart)
        {
            return this.cartRepository.AddCartDetails(cart);
        }

        public int DeleteCartByCartId(int cartId)
        {
            return this.cartRepository.DeleteCartByCartId(cartId);
        }
        public bool UpdateCart(int CartId, Cart cartModel)
        {
            return this.cartRepository.UpdateCart(CartId,cartModel);
        }
        public List<CartResponse> GellAllCart()
        {
            return this.cartRepository.GellAllCart();
        }
    }
}
