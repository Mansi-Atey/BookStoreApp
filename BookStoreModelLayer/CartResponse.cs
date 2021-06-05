using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
   public class CartResponse
    {
        public int CartId { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }      
        public string AuthorName { get; set; }
        public string BookImage { get; set; }
    }
}
