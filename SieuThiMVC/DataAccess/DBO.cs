using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace SieuThiMVC.DataAccess
{
    public class DBO
    {
        static public string ConnnectionString = @"Data Source=PC-PC\SQLEXPRESS;initial catalog=QLHangHoa;user id=sa;password=sa;";
        static protected SqlConnection connect()
        {
            var con = new SqlConnection(ConnnectionString);
            return con;
        }
    }
}