using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }
        [Key]
        public int BookID { get; set; }
        public int SelectBookQuantity { get; set; }
    }
}
