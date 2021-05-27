using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer
{
    public class BookRepositoryLayer:IBookRepository
    {
        private readonly IConfiguration configuration;
        public BookRepositoryLayer(IConfiguration configuration)
        {

            this.configuration = configuration;
        }
        public Book AddBook(Book book)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spAddBooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@BookID", book.BookID);
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);
                    cmd.Parameters.AddWithValue("@BookDiscription", book.BookDiscription);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i >= 1)
                    {

                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", bookId);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public bool UpdateBook(int BookID, Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", BookID);
                    cmd.Parameters.AddWithValue("@BookDiscription", book.BookDiscription);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.Quantity);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<Book> GellAllBooks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    List<Book> booklist = new List<Book>();
                    SqlCommand com = new SqlCommand("spGetAllBooks", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    connection.Open();
                    da.Fill(dt);
                    connection.Close();
                    //Bind EmpModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {

                        booklist.Add(

                            new Book
                            {

                                BookID = Convert.ToInt32(dr["Id"]),
                                BookName = Convert.ToString(dr["Name"]),
                                BookDiscription = Convert.ToString(dr["Discription"]),
                                BookPrice = Convert.ToInt32(dr["Price"]),
                                AuthorName = Convert.ToString(dr["AName"]),
                                Quantity = Convert.ToInt32(dr["Quantity"])
                            });
                    }
                    return booklist;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
