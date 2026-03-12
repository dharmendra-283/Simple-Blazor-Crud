using Microsoft.Data.SqlClient;
using SampleBlazorApp.Models;
using System.Data;

namespace SampleBlazorApp.Data
{
    public class DataAccessLayer
    {
        string constr = "Server=.;Database=TestDB;uid=sa;pwd=pass@123;TrustServerCertificate=True;";

        internal IEnumerable<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Customer()
                            {
                                CustomerId = Convert.ToInt32(sdr["CustomerId"]),
                                Name = sdr["Name"].ToString(),
                                City = sdr["City"].ToString(),
                                Country = sdr["Country"].ToString(),
                                Gender = sdr["Gender"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return customers;
        }

        internal Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetCustomerById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customer.CustomerId = Convert.ToInt32(sdr["CustomerId"]);
                            customer.Name = sdr["Name"].ToString();
                            customer.City = sdr["City"].ToString();
                            customer.Country = sdr["Country"].ToString();
                            customer.Gender = sdr["Gender"].ToString();
                        }
                    }
                    con.Close();
                }
            }

            return customer;
        }

        internal void AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        internal void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@City", customer.City);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    cmd.Parameters.AddWithValue("@Gender", customer.Gender);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        internal void DeleteCustomer(int? id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
