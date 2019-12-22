using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using adder.Models;
using System.Collections.Generic;

namespace adder.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _iconfiguration;
      
        private readonly ILogger<HomeController> _logger;

        Database databaseObject = new Database();

        public HomeController(ILogger<HomeController> logger, IConfiguration iconfiguration)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            databaseObject.OpenConnection();

            List<string> SourceData = new List<string>();
            string query = "SELECT `pniv` FROM `sources`";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);
            SQLiteDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    SourceData.Add(new string(result["pniv"].ToString()));
                }

                ViewData["source_data"] = SourceData;
            }


            List<string> SensorData = new List<string>();
            query = "SELECT `sensor_uuid` FROM `sensors`";
            command = new SQLiteCommand(query, databaseObject.conn);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    SensorData.Add(new string(result["sensor_uuid"].ToString()));
                }

                ViewData["sensor_data"] = SensorData;
            }


            List<string> ParameteresData = new List<string>();
            query = "SELECT `code` FROM `parameteres`";
            command = new SQLiteCommand(query, databaseObject.conn);
            result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    ParameteresData.Add(new string(result["code"].ToString()));
                }

                ViewData["parameter_data"] = ParameteresData;
            }

            databaseObject.CloseConnection();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Microsoft.AspNetCore.Http.IFormCollection collection)
        {
            try
            {
                ViewData["source"] = collection["source"];
                ViewData["sensor"] = collection["sensor"];
                ViewData["parameter"] = collection["parameter"];
                ViewData["value"] = collection["value"];

                string query = "INSERT INTO indicators (`code`, `unit`, `type`, `value`) VALUES (@Code, @Unit, @Type, @Value)";

                SQLiteCommand command = new SQLiteCommand(query, databaseObject.conn);
                databaseObject.OpenConnection();


                command.Parameters.AddWithValue("@Code", collection["source"]);
                command.Parameters.AddWithValue("@Unit", collection["sensor"]);
                command.Parameters.AddWithValue("@Type", collection["parameter"]);
                command.Parameters.AddWithValue("@Value", collection["value"]);
                var result = command.ExecuteNonQuery();

                databaseObject.CloseConnection();


                Console.WriteLine(result);

                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
