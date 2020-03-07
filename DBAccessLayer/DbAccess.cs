using DBAccessLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessLayer
{
    public class DbAccess:IDbAccess
    {


        private const string connectionString = @"Data Source=DESKTOP-GOCGBME\SQLEXPRESS;Initial Catalog=TestDB; Integrated Security=SSPI";

        public void Delete(string sqlString)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlString, sqlConn))
                {
                    cmd.ExecuteNonQuery();
                }
                sqlConn.Close();
            }
        }

        public DataTable GetDataTable(string sqlString)
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

        public void InsertDb(string sqlString)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(sqlString, sqlConn);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
            }



            //   using (SqlConnection openCon = new SqlConnection(connectionString))
            //   {
            //       string saveStaff = "INSERT into tbl_staff (staffName,userID,idDepartment) VALUES (@staffName,@userID,@idDepartment)";

            //       using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
            //       {
            //           querySaveStaff.Connection = openCon;
            //           querySaveStaff.Parameters.Add("@staffName", SqlDbType.VarChar, 30).Value = name;
            //           .....
            //openCon.Open();

            //           querySaveStaff.ExecuteNonQuery();
            //       }
            //   }
        }

        public void Update(string sqlString)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlString, sqlConn))
                {
                    cmd.ExecuteNonQuery();
                }
                sqlConn.Close();
            }
        }
    }
}
