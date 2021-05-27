using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
   public interface IBookManager
    {
        Book AddBook(Book book);
        bool DeleteBook(int bookId);
        bool UpdateBook(int BookID, Book book);
        List<Book> GellAllBooks();
    }
}
