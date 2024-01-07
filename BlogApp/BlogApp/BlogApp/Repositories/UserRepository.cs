using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace BlogApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["BlogAppConnectionString"].ConnectionString;

        public void CreateUser(User u)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", u.Name);
                    command.Parameters.AddWithValue("@Email", u.Email);
                    command.Parameters.AddWithValue("@Password", u.Password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User ValidUser(LoginModel model)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("CheckUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString()
                            };
                        }
                    }

                }
            }
            return user;
        }

    }
}