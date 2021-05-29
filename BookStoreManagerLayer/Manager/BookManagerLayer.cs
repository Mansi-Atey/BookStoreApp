using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer
{
    public class BookManagerLayer:IBookManager
    {
        private readonly IBookRepository bookRepository;
        public BookManagerLayer(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Books AddBook(Books book)
        {
            return this.bookRepository.AddBook(book);
        }
        public bool DeleteBook(int bookID)
        {
            return this.bookRepository.DeleteBook(bookID);
        }
        public bool UpdateBook(int BookID, Books book)
        {
            return this.bookRepository.UpdateBook(BookID, book);
        }
        public List<Books> GellAllBooks()
        {
            return this.bookRepository.GellAllBooks();
        }
    }
}
