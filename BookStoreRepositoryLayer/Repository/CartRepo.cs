using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer
{
    public class CartRepo:ICart
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public Cart AddCartDetails(Cart cartModel)
        {
            try
            {
                 Connection();
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", cartModel.UserId);
                    command.Parameters.AddWithValue("@BookID", cartModel.BookID);
                    command.Parameters.AddWithValue("@TotalQuantity", cartModel.TotalQuantity);
                    connection.Open();
                    int i =command.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        return cartModel;
                    }
                    else
                    {

                        return null;
                    }
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
        public int DeleteCartByCartId(int cartId)
        {
            try
            {
                    Connection();
                    SqlCommand command = new SqlCommand("spDeleteCartByCartId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cartId);
                 // command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        return 1;
                    }
                    else
                    {

                        return 0;
                    }
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
        public bool UpdateCart(int CartId, Cart cartModel)
        { 
            try
            {
                    Connection();
                    SqlCommand cmd = new SqlCommand("spUpdateCart", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@BookID", cartModel.BookID);
                    cmd.Parameters.AddWithValue("@TotalQuantity", cartModel.TotalQuantity);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        public List<CartResponse> GellAllCart()
        {
            try
            {
                    Connection();
                    List<CartResponse> cartlist = new List<CartResponse>();
                    SqlCommand com = new SqlCommand("spGetAllCart", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@UserId", 1);
                     SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    connection.Open();
                    da.Fill(dt);
                    //Bind CartModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {
                    cartlist.Add(
                        new CartResponse
                        {
                            CartId = Convert.ToInt32(dr["CartId"]),
                            //UserId = Convert.ToInt32(dr["UserId"]),
                            BookID = Convert.ToInt32(dr["BookID"]),
                            // TotalQuantity = Convert.ToInt32(dr["TotalQuantity"])
                            BookName = dr["BookName"].ToString(),
                            BookPrice = Convert.ToInt32(dr["BookPrice"]),
                            AuthorName = dr["AuthorName"].ToString(),
                            BookImage = dr["BookImage"].ToString(),
                        }) ;
                    }
                    return cartlist;
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
    }
}
