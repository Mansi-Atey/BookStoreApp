
using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStoreRepositoryLayer
{
    public class BookRepositoryLayer:IBookRepository
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public Books AddBook(Books book)
        {
            try
            {
                    Connection();
                    SqlCommand cmd = new SqlCommand("spAddBooks", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", book.BookID);
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@Quantity", book.Quantity);
                    cmd.Parameters.AddWithValue("@BookImage", book.BookImage);
                    cmd.Parameters.AddWithValue("@BookDiscription", book.BookDiscription);
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                        return book;
                    else
                        return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteBook(int bookID)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("spDeleteBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                        return true;
                    else
                        return false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public Books UpdateBook( Books book)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@BookDiscription", book.BookDiscription);
                    cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.Quantity);
                    cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)           
                        return book;
                    else
                        return null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Books> GellAllBooks()
        {
            try
            {
                Connection();
                   List<Books> booklist = new List<Books>();
                    SqlCommand com = new SqlCommand("spGetAllBooks", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    connection.Open();
                    da.Fill(dt);
                    //Bind bookModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {
                    booklist.Add(
                        new Books
                        {
                                
                                BookID = Convert.ToInt32(dr["BookID"]),
                                BookName = Convert.ToString(dr["BookName"]),
                                BookDiscription = Convert.ToString(dr["BookDiscription"]),
                                BookPrice = Convert.ToString(dr["BookPrice"]),
                                AuthorName = Convert.ToString(dr["AuthorName"]),
                                BookImage = Convert.ToString(dr["BookImage"]),
                                Quantity = Convert.ToString(dr["Quantity"])
                        }) ; 
                    }
                    return booklist;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UploadImage(int BookID, string imageUpload)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("spAddImage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", BookID);
            // var myAccount = new Account { ApiKey = "371652781151548", ApiSecret = "1aVBjz0E-GdsHlguqwgk_spEyCo", Cloud = "dywhtr8hk" };
            cmd.Parameters.AddWithValue("@BookImage", imageUpload);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;

            else
                return false;
        }
        
    }
}
