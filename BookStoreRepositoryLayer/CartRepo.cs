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
    public class CartRepo:ICart
    {
        private readonly IConfiguration configuration;
        public CartRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public CartModel AddCartDetails(CartModel cartModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand command = new SqlCommand("spAddToCart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookId", cartModel.BookID);
                    command.Parameters.AddWithValue("@SelectBookQuantity", cartModel.SelectBookQuantity);
                    connection.Open();
                    int i =command.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        return cartModel;
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
        public bool DeleteCartByCartId(int cartId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand command = new SqlCommand("spDeleteCartByCartId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cartId);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
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
        public bool UpdateCart(int CartId, CartModel cartModel)
        { 
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateCart", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@CartId", cartModel.BookID);
                    cmd.Parameters.AddWithValue("@SelectBookQuantity", cartModel.SelectBookQuantity);
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
        public List<CartModel> GellAllCart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    List<CartModel> cartlist = new List<CartModel>();
                    SqlCommand com = new SqlCommand("spGetAllCart", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();

                    connection.Open();
                    da.Fill(dt);
                    connection.Close();
                    //Bind CartModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {

                        cartlist.Add(

                            new CartModel
                            {
                                CartId = Convert.ToInt32(dr["Id"]),
                                BookID = Convert.ToInt32(dr["ID"]),
                                SelectBookQuantity = Convert.ToInt32(dr["SelectBookQuantity"])
                            });
                    }
                    return cartlist;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
