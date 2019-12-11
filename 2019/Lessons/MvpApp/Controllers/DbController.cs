using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvpApp.Storage;

namespace MvpApp.Controllers
{
    /// <summary>
    /// Контроллер БД
    /// </summary>
    public abstract class DbController : Controller
    {
        /// <summary>
        /// База данных
        /// </summary>
        protected readonly Database db = new Database();

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}