using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
    public class CustomerDetails
    {
        [Key]
        public long UserId { get; set; }
        public string Name { get; set; }
        [Key]
        public long CustomerId { get; set; }
        public int Pincode { get; set; }
        public long PhoneNumber { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Landmark { get; set; }
        public string AddressType { get; set; }
    }
}
