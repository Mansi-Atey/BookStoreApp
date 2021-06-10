using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreManagerLayer
{
    public class BookManagerLayer:IBookManager
    {
        private readonly IBookRepository bookRepository ;
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
        public Books UpdateBook(Books book)
        {
            return this.bookRepository.UpdateBook(book);
        }
        public List<Books> GellAllBooks()
        {
            return this.bookRepository.GellAllBooks();
        }
       public bool UploadImage(int BookID, string imageUpload)
        {
                return this.bookRepository.UploadImage( BookID, imageUpload);
        }
        //private string CloudImageLink(HttpPostedFileBase file)
        //{
        //    return this.bookRepository.CloudImageLink(file);
        //}
    }
}
