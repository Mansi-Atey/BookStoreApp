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
    public class CustomerDetailsManager:ICustomerDetailsManager
    {
        private readonly ICustomerDetails customerRepository;

        public CustomerDetailsManager(ICustomerDetails customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public int AddCustomerDetails(CustomerDetails info)
        {
            return this.customerRepository.AddCustomerDetails(info);
        }
        //public bool DeleteCustomerDetails(int customerId)
        //{
        //    return this.customerRepository.DeleteCustomerDetails(customerId);
        //}
        public CustomerDetails UpdateCustomerDetails(int CustomerId, CustomerDetails info)
        {
            return this.customerRepository.UpdateCustomerDetails(CustomerId,info);
        }
        public List<CustomerDetails> GetAllCustomerDetails(int UserId)
        {
            return this.customerRepository.GetAllCustomerDetails(UserId);
        }
    }
}
