using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Configuration;
using System.Web.UI.WebControls;

namespace BlogApp.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["BlogAppConnectionString"].ConnectionString;
        public List<BlogsModel> GetBlogsList(int? userId = null)
        {
            List<BlogsModel> blogsList = new List<BlogsModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetBlogsList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AuthorId", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var blogs = new BlogsModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Status = reader["Status"].ToString()
                            };

                            if (reader["PublishedDate"] != DBNull.Value)
                            {
                                blogs.PublishedDate = Convert.ToDateTime(reader["PublishedDate"]);
                            }
                            if (reader["CreationDate"] != DBNull.Value)
                            {
                                blogs.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            }
                            blogsList.Add(blogs);
                        }
                    }

                }
            }
            return blogsList;
        }

        public BlogsModel GetBlogById(int Id)
        {
            BlogsModel blog = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("GetBlogById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blog = new BlogsModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Status = reader["Status"].ToString(),
                                Content = reader["Content"].ToString(),
                                Image = reader["Image"] as byte[],
                                Video = reader["Video"] as byte[]
                            };

                            if (reader["PublishedDate"] != DBNull.Value)
                            {
                                blog.PublishedDate = Convert.ToDateTime(reader["PublishedDate"]);
                            }
                            if (reader["CreationDate"] != DBNull.Value)
                            {
                                blog.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            }
                           
                        }
                    }

                }
            }
            return blog;
        }
        public void ProcessBlog(BlogsModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("UpsertPost", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", model.Id);
                    command.Parameters.AddWithValue("@Title", model.Title);
                    command.Parameters.AddWithValue("@Author", 1);
                    command.Parameters.AddWithValue("@Content", model.Content);
                    command.Parameters.AddWithValue("@Status", model.Status);
                    command.Parameters.AddWithValue("@Image", model.Image);
                    command.Parameters.AddWithValue("@Video", model.Video);

                    if (model.Id == 0)
                    {
                        command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }

                    if (model.Status == "Published")
                    {
                        command.Parameters.AddWithValue("@PublishedDate", DateTime.Now);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}