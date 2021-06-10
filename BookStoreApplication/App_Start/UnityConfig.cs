using BookStoreManagerLayer;
using BookStoreManagerLayer.IManager;
using BookStoreManagerLayer.InterfaceManager;
using BookStoreManagerLayer.Manager;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.Repository;
using BookStoreRepositoryLayer.RepositoryInterface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookStoreApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBookManager, BookManagerLayer>();
            container.RegisterType<ICartManager, CartManager>();
            container.RegisterType<ICustomerDetailsManager, CustomerDetailsManager>();
            container.RegisterType<IUserManager, UserManagerLayer>();
            container.RegisterType<IOrderManager, OrderManager>();
            container.RegisterType<IWishListManager, WishListManager>();

            container.RegisterType<IBookRepository, BookRepositoryLayer>();
            container.RegisterType<ICart, CartRepo>();
            container.RegisterType<ICustomerDetails, CustomerDetailsRepo>();
            container.RegisterType<IWishListRepo, WishListRepo>();
            container.RegisterType<IOrderRepo, OrderRepo>();
            container.RegisterType<IUserRepository, UserRepo>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}