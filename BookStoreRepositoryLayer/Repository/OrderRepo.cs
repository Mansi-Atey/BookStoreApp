using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
   public class OrderRepo:IOrderRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int PlaceOrder(int userId, int cartId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spPlaceOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CartId", cartId);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return userId;
                else
                    return cartId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public OrderDetails GetAllOrders(OrderDetails orders)
        {
            try
            {
                Connection();
                List<OrderDetails> ordersList = new List<OrderDetails>();
                SqlCommand cmd = new SqlCommand("spGetAllOrders", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind OrdersModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    ordersList.Add(
                        new OrderDetails
                        {
                            OrderId = Convert.ToInt32(dr["orderId"]),
                            UserId = Convert.ToInt32(dr["userId"])
                        }
                        );
                }
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
