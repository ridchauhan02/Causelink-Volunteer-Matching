using Microsoft.AspNetCore.Mvc;
using CauseLink.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CauseLink.Controllers
{
    public class Search : Controller
    {
        public IActionResult Index()
        {
            List<addpost> model = GetDataFromDatabase();
            return View(model);
        }

        public IActionResult detail1()
        {
            return View();
        }

        private List<addpost> GetDataFromDatabase()
        {
            var data = new List<addpost>();
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=CauseLink;Integrated Security=True;Connect Timeout=30;Encrypt=False;"; // Replace with your actual connection string

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sql = "SELECT Id, Title, Mode, Address, Location, Date FROM post"; // Include additional fields in the SQL query
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var post = new addpost
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Mode = reader["Mode"].ToString(),
                                Address = reader["Address"].ToString(),
                                Location = reader["Location"].ToString(),
                                Date = reader["Date"].ToString()
                                // Add more fields as needed
                            };
                            data.Add(post);
                        }
                    }
                }
            }

            return data;
        }
    }
}
