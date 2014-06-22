using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace SieuThiMVC.DataAccess
{
    public class OrderDBO : DBO
    {
        static public bool AddOrder(Models.Order order, int userid)
        {
            try
            {
                foreach (var item in order.Orders)
                {
                    var con = connect();
                    var cmstr = "INSERT INTO HoaDon(MaTk, MaHH, Status, NgayMua, SoLuong) VALUES(@userid, @productid, @status, @date, @quantity)";
                    con.Open();
                    var command = new SqlCommand(cmstr, con);
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@productid", item.Product.ID);
                    command.Parameters.AddWithValue("@status", "Đang giao hàng");
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@quantity", item.Quantity);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}