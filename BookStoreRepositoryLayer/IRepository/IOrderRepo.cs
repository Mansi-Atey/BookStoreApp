using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
   public interface IOrderRepo
    {
        int PlaceOrder(int userId, int cartId);
        OrderDetails GetAllOrders(OrderDetails orders);
    }
}
