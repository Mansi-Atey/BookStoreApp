using BookStoreModelLayer;
using BookStoreRepositoryLayer.RepositoryInterface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer
{
    public class UserRepo:IUserRepository
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public User AddUserDetails(User user)
        {
            try
            {
                Connection();
                string password = Encryptdata(user.Password);
               SqlCommand cmd = new SqlCommand("spAddUserDetails", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return user;
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
        public Login Login(Login login)
        {
            try
            {
                Connection();
                string password = Encryptdata(login.Password);
                SqlCommand cmd = new SqlCommand("spLogin", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", login.Email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return login;
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
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        //private string GenrateJWTToken(string Email, int userId)
        //{
        //    /// key getting from startup class
        //    var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.key["Key"]));
        //    var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
        //    var claims = new List<Claim>
        //    {
        //        new Claim("Email",Email),
        //        new Claim("userId",userId.ToString())
        //    };
        //    var tokenOptionOne = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: signinCredentials
        //        );
        //    string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
        //    return token;
        //}
    }
}
