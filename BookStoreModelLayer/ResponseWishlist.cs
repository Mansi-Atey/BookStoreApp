using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
    public class ResponseWishlist
    {
        public int BookID{ get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookPrice { get; set; }
        public string BookImage { get; set; }
        public int WishListQuantity { get; set; }
    }
}
