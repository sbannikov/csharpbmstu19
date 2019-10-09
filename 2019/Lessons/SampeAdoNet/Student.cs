using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampeAdoNet
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Family { get; set; }

        public Student() : this (null, null)
        {
        }

        public Student(string name, string family)
        {
            Name = name;
            Family = family;
        }
    }
}
