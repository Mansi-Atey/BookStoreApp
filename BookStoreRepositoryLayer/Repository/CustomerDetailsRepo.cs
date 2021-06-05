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
    public class CustomerDetailsRepo:ICustomerDetails
    {
        private SqlConnection connection;
        //To Handle connection related activities    
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public CustomerDetails AddCustomerDetails(CustomerDetails info)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spAddBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", info.UserId);
                cmd.Parameters.AddWithValue("@Name", info.Name);
                cmd.Parameters.AddWithValue("@Address", info.Address);
                cmd.Parameters.AddWithValue("@Pincode",info.Pincode);
                cmd.Parameters.AddWithValue("@PhoneNumber", info.PhoneNumber);
                cmd.Parameters.AddWithValue("@Locality", info.Locality);
                cmd.Parameters.AddWithValue("@City", info.City);
                cmd.Parameters.AddWithValue("@Landmark", info.Landmark);
                cmd.Parameters.AddWithValue("@AddressType", info.AddressType);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return info;
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
        public bool DeleteCustomerDetails(int customerId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
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
        public bool UpdateCustomerDetails(int CustomerId, CustomerDetails info)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.Parameters.AddWithValue("@Name", info.Name);
                cmd.Parameters.AddWithValue("@Address", info.Address);
                cmd.Parameters.AddWithValue("@Pincode", info.Pincode);
                cmd.Parameters.AddWithValue("@PhoneNumber", info.PhoneNumber);
                cmd.Parameters.AddWithValue("@Locality", info.Locality);
                cmd.Parameters.AddWithValue("@City", info.City);
                cmd.Parameters.AddWithValue("@Landmark", info.Landmark);
                cmd.Parameters.AddWithValue("@AddressType", info.AddressType);
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
        public List<CustomerDetails> GellAllCustomerDetails()
        {
            try
            {
                List<CustomerDetails> customerlist = new List<CustomerDetails>();
                SqlCommand com = new SqlCommand("spGetAllCustomerDetails", connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    customerlist.Add(
                        new CustomerDetails
                        {
                            CustomerId = Convert.ToInt32(dr["CustomerId"]),
                            UserId = Convert.ToInt32(dr["UserId"]),
                            Name = Convert.ToString(dr["Name"]),
                             Address= Convert.ToString(dr["Address"]),
                            Pincode = Convert.ToInt32(dr["Pincode"]),
                            PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]),
                            Locality = Convert.ToString(dr["Locality"]),
                            City = Convert.ToString(dr["City"]),
                            Landmark = Convert.ToString(dr["Landmark"]),
                            AddressType = Convert.ToString(dr["AddressType"]),

                        });
                }
                return customerlist;
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
