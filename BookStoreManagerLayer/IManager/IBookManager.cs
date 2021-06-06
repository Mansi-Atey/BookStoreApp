﻿using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.InterfaceManager
{
   public interface IBookManager
    {
        Books AddBook(Books book);
        int DeleteBook(int bookID);
        bool UpdateBook(int BookID, Books book);
        List<Books> GellAllBooks();
    }
}
