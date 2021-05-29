using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepo ordersRepo;
        public OrderManager(OrderRepo ordersRepo)
        {
            this.ordersRepo = ordersRepo;
        }
        public int PlaceOrder(int UserId, int CartId)
        {
            return this.ordersRepo.PlaceOrder(UserId, CartId);
        }
        public OrderDetails GetAllOrders(OrderDetails orders)
        {
            return this.ordersRepo.GetAllOrders(orders);
        }

    }
}
