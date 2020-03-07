using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SqlServer
{
    public class DataAccessSql
    {
        private const string connectionString = @"Data Source=DESKTOP-GOCGBME\SQLEXPRESS;Initial Catalog=TestDB; Integrated Security=SSPI";

        public static DataTable GetDataTable(string sqlString)
        {
            var table = new DataTable();
            using (var da = new SqlDataAdapter(sqlString, connectionString))
            {
                da.Fill(table);
            }
            return table;
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand(sqlString, sqlConnection);
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        }

        public static void InsertDb(string sqlString)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlString, sqlConn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
