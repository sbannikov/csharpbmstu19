using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class UUIDGenerator
    {
        static private Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomID()
        {
            return RandomString(8) + "-" +
                    RandomString(4) + "-" +
                    RandomString(4) + "-" +
                    RandomString(4) + "-" +
                    RandomString(12);
        }
    }
}
