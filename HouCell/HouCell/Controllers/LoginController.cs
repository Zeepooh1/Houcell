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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string pass)
        {

            bool success = false;
            int redVal = 0;

            using (var connection = new MySqlConnection
            {

                //SPREMENI CONNECTION STRING 
                ConnectionString = "server=houcellbase.ddns.net;user id=remote;password=seminarskaGeslo;persistsecurityinfo=True;port=3306;database=Houcell"
            })
            {
                connection.Open();
                string query = "SELECT * FROM uporabnik WHERE userName =@userName AND pass =@pass;";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@pass", pass);
                Console.WriteLine("Username: " + userName);
                using (MySqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        //Če je login uspešen v TempData["logID"] zapišem vrednost userID
                        TempData["logID"] = (int)reader["userID"];


                        ViewData["userID"] = reader["userID"];
                        ViewData["userName"] = reader["userName"];
                        ViewData["password"] = reader["pass"];
                        success = true;
                    }
                }
                connection.Close();
            }
            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}
