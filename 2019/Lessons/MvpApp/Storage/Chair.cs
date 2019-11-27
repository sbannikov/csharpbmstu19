using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpApp.Storage
{
    /// <summary>
    /// Кафедра
    /// </summary>
    public class Chair : Entity
    {
        /// <summary>
        /// Номер кафедры
        /// </summary>
        public int Number { get; set; }
    }
}