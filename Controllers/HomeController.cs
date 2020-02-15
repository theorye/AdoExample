using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADOCRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace ADOCRUD.Controllers
{
    public class HomeController : Controller
    {
        string ConnectionInformation = "Server=DESKTOP-P55BTG2\\SQLEXPRESS;Database=ADOCRUD;Trusted_Connection=True;MultipleActiveResultSets=True";
        SqlDataReader myReader;

        public IActionResult Index()
        {
            UserInfo UI = new UserInfo();
            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);

            MainConnection.Open();
            // string MyCommand = "SELECT * FROM UserInfo";
            // SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            SqlCommand myCommand = new SqlCommand("UserInfoProcedure", MainConnection);
            myCommand.Parameters.Add(new SqlParameter("@Filter", "Read"));
            myCommand.CommandType = CommandType.StoredProcedure;
            myReader = myCommand.ExecuteReader();

            while(myReader.Read())
            {
                UI.UserName = myReader.GetValue(1).ToString();
            }
            MainConnection.Close();

            
            return View(UI);
        }

        [HttpPost]
        public IActionResult Index(UserInfo UI)
        {
            /* == ADO COMMAND == */
            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);

            MainConnection.Open();
            string MyCommand = "Insert Into UserInfo (UserName) values ('" + UI.UserName + "')";
            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            myCommand.ExecuteNonQuery();
            MainConnection.Close();
            return View(UI);
        }

        [HttpPost]
        public IActionResult UpdateUserInfo(UserInfo UI)
        {
            /* == ADO COMMAND == */
            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);

            MainConnection.Open();
            string MyCommand = "Update UserInfo set UserName='" + UI.NewUserName + "' where UserName ='" + UI.UserName + "' ";
            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            myCommand.ExecuteNonQuery();
            MainConnection.Close();
            return View(UI);
        }

        [HttpPost]
        public IActionResult DeleteUserInfo(UserInfo UI)
        {
            /* == ADO COMMAND == */
            SqlConnection MainConnection = new SqlConnection(ConnectionInformation);

            MainConnection.Open();
            string MyCommand = "Delete from UserInfo where UserName='" + UI.UserName + "'";
            SqlCommand myCommand = new SqlCommand(MyCommand, MainConnection);
            myCommand.ExecuteNonQuery();
            MainConnection.Close();
            return View(UI);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
