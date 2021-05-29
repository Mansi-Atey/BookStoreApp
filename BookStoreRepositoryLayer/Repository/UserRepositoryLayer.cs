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
    public class UserRepositoryLayer:IUserRepository
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public object AddUserDetails(User user)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spAddUserDetails", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    return "registration done successfully.";
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
        public Login Login(Login login)
        {
            try
            {
                    SqlCommand cmd = new SqlCommand("spLogin", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    connection.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                            return login;
                    }
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
    }
}
