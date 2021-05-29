using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.RepositoryInterface
{
   public interface IBookRepository
    {
        Books AddBook(Books book);
        bool DeleteBook(int bookID);
        bool UpdateBook(int BookID, Books book);
        List<Books> GellAllBooks();
    }
}
