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
    public class WishListRepo : IWishListRepo
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ToString();
            connection = new SqlConnection(connectionString);
        }
        public WishList AddToWishList(int UserId, int BookId)
        {
            WishList WishList = new WishList();
            try
            {
                SqlCommand cmd = new SqlCommand("spAddTowishList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@BookId", BookId);
                connection.Open();

                SqlDataReader sqlreader = cmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    WishList.WishListId = Convert.ToInt32(sqlreader["WishListId"].ToString());
                    WishList.UserID = Convert.ToInt32(sqlreader["UserID"].ToString());
                    WishList.BookID = Convert.ToInt32(sqlreader["BookID"].ToString());
                    WishList.BookName = sqlreader["BookName"].ToString();
                    WishList.Price = Convert.ToInt32(sqlreader["Price"].ToString());
                    WishList.WishListQuantity = Convert.ToInt32(sqlreader["WishListQuantity"].ToString());
                }
                return WishList;
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
        public bool DeleteFromWishList(int UserId, int WishListId)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spDeleteFromWishList", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WishListId", WishListId);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
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
   
        public List<WishList> ViewWishListDetails()
        {
            try
            {
                List<WishList> wishlist = new List<WishList>();
                SqlCommand com = new SqlCommand("spGetAllWishList", connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                //Bind WistList generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    wishlist.Add(
                        new WishList
                        {
                            UserID = Convert.ToInt32(dr["UserID"]),
                            WishListId = Convert.ToInt32(dr["WishListId"]),
                            BookID = Convert.ToInt32(dr["BookID"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            Price = Convert.ToInt32(dr["Price"]),
                            WishListQuantity = Convert.ToInt32(dr["WishListQuantity"])
                        });
                }
                return wishlist;
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



