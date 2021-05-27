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
        public Book AddBook(Book book)
        {
            return this.bookRepository.AddBook(book);
        }
        public bool DeleteBook(int bookId)
        {
            return this.bookRepository.DeleteBook(bookId);
        }
        public bool UpdateBook(int BookID, Book book)
        {
            return this.bookRepository.UpdateBook(BookID, book);
        }
        public List<Book> GellAllBooks()
        {
            return this.bookRepository.GellAllBooks();
        }
    }
}
