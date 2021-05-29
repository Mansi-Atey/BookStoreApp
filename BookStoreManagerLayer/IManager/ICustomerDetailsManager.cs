using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
   public interface ICustomerDetailsManager
    {
        CustomerDetails AddCustomerDetails(CustomerDetails info);
        bool DeleteCustomerDetails(int customerId);
         bool UpdateCustomerDetails(int CustomerId, CustomerDetails info);
        List<CustomerDetails> GellAllCustomerDetails();
    }
}
