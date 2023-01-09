using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFQuanLyNhanVien.Controller;

namespace WFQuanLyNhanVien.Controller
{
    class ConnectDBString
    {
        //public string connectionString()
        //{

        //    string connectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=WFQuanLyNhanVien;User ID=sa;Password=123";

        //    return connectionString;
        //}

        internal static string connectionString()
        {
            string connectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=WFQuanLyNhanVien;User ID=sa;Password=123";
            return connectionString;
        }
    }

}

