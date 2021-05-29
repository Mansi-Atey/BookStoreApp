using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int CartId { get; set; }

        public int UserId { get; set; }

    }
}
