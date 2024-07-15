using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_Net.DBConnect
{
    public class ConnectSQLSeverDB
    {
       public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = null;
            var connectionString = "Data Source=DESKTOP-J6E5FOR;Initial Catalog=ShopDB;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            if(conn.State ==System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
