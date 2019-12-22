using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SQLite;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using api.Models;
using api.Repositories;

namespace api.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _iconfiguration;

        private readonly ILogger<HomeController> _logger;

        private IndicatorRepository repo = new IndicatorRepository();

        public HomeController(ILogger<HomeController> logger, IConfiguration iconfiguration)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            List<IndicatorDto> values = repo.GetValues();
            return Json(values);
        }
    }
}
