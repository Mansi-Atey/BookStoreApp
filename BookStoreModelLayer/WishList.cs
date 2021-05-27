using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
   public class WishList
    {
        [Key]
        [Required]
        public int WishListId { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public double Price { get; set; }
        public string BookName { get; set; }
         public int WishListQuantity { get; set; }
    }
}
