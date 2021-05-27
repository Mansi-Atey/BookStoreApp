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
    public class UserRepositoryLayer:IUserRepository
    {
        private IConfiguration configuration { get; }
        public UserRepositoryLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object AddUserDetails(UserModel user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spAddUserDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@UserAddress", user.UserAddress);
                    cmd.Parameters.AddWithValue("@City", user.City);
                    cmd.Parameters.AddWithValue("@PinCode", user.PinCode);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    return "registration done successfully.";
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public LoginModel Login(LoginModel login)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("UserDbConnection")))
                {

                    SqlCommand cmd = new SqlCommand("spLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            con.Close();
                            return login;
                        }
                    }
                    con.Close();
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
