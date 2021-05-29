using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
   public interface IOrderManager
    {
        int PlaceOrder(int UserId, int CartId);
        OrderDetails GetAllOrders(OrderDetails orders);
    }
}
