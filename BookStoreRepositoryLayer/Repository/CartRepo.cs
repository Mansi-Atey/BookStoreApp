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
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        public Cart AddCartDetails(Cart cartModel)
        {
            try
            {
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", cartModel.BookID);
                    command.Parameters.AddWithValue("@SelectBookQuantity", cartModel.SelectBookQuantity);
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
        public bool DeleteCartByCartId(int cartId)
        {
            try
            {
                    SqlCommand command = new SqlCommand("spDeleteCartByCartId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cartId);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
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
        public bool UpdateCart(int CartID, Cart cartModel)
        { 
            try
            {              
                    SqlCommand cmd = new SqlCommand("spUpdateCart", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartID", CartID);
                    cmd.Parameters.AddWithValue("@BookID", cartModel.BookID);
                    cmd.Parameters.AddWithValue("@SelectBookQuantity", cartModel.SelectBookQuantity);
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
        public List<Cart> GellAllCart()
        {
            try
            {
                    List<Cart> cartlist = new List<Cart>();
                    SqlCommand com = new SqlCommand("spGetAllCart", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    connection.Open();
                    da.Fill(dt);
                    //Bind CartModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {

                        cartlist.Add(

                            new Cart
                            {
                                CartId = Convert.ToInt32(dr["CartID"]),
                                BookID = Convert.ToInt32(dr["BookID"]),
                                SelectBookQuantity = Convert.ToInt32(dr["SelectBookQuantity"])
                            });
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
