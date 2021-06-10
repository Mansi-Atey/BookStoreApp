using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
   public interface IBookRepository
    {
        Books AddBook(Books book);
        bool DeleteBook(int bookID);
        Books UpdateBook(Books book);
        List<Books> GellAllBooks();
        bool UploadImage(int BookID, string imageUpload);
       // string CloudImageLink(HttpPostedFileBase file);
    }
}
