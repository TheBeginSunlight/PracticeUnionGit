using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDB
{
    public class Class1
    {
        public static string Connect()
        {
            string connDB = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
            return connDB;
        }
    }
}
