using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HouCell.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            using (var connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=root;password=;persistsecurityinfo=True;port=3306;database=Houcell"
            })
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM uporabnik;", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViewData["userID"] = reader["userID"] + "";
                        ViewData["userName"] = reader["userName"];
                        ViewData["password"] = reader["password"];
                    }
                }
                connection.Close();
            }

            return View();
        }
    }
}
