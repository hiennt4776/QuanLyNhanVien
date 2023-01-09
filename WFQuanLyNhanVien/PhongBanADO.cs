using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFQuanLyNhanVien
{
    class PhongBanADO
    {

        private string ConnectionString = @"Data Source=DESKTOP-H8M37V7\SQLEXPRESS;Initial Catalog=WFQuanLyNhanVien;User ID=sa;Password=123";
        private SqlConnection conn;
        public DataTable selectAllPhongBan()
        {

            // create Connect
            conn = new SqlConnection(ConnectionString);

            //new SQL string
            string queryString = "select * from PhongBan";
            //create Command
            SqlCommand command = new SqlCommand();
            //connect Command with Connection
            command.Connection = conn;
            //add queryString to Command
            command.CommandText = queryString;
            command.CommandType = CommandType.Text;

            //Create DataProvider and DataSet use Binding Data
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            DataTable dt = new DataTable();

            //DataSet ds = new DataSet();

            //Open Connection
            conn.Open();
            //Execute SQL
            command.ExecuteNonQuery();
            dataAdapter.SelectCommand = command;
            //binding dataset
            dataAdapter.Fill(dt);
            conn.Close();
            return dt;

        }

       
    }
}
