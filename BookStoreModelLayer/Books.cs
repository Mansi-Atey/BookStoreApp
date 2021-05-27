using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModelLayer
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Book Name")]
        public string BookName { get; set; }
        public string BookDiscription { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Price")]
        public int BookPrice { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Author Name")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Please Enter Valid Quantity")]
        public int Quantity { get; set; }
        [Required]
        public string BookImage { get; set; }

    }
}
