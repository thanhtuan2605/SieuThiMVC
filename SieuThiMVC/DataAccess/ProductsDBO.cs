using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SieuThiMVC.Models;
namespace SieuThiMVC.DataAccess
{
    public class ProductsDBO : DBO
    {
        static public Models.SortOfProduct[] GetSortsOfProduct()
        {
            var con = connect();
            var commandstr = "SELECT * FROM LoaiHangHoa";
            var list = new List<Models.SortOfProduct>();
            con.Open();
            var command = new SqlCommand(commandstr, con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Models.SortOfProduct { ID = reader.GetInt32(0), Name = reader.GetString(1) });
            }
            con.Close();
            return list.ToArray();
        }
        static public bool ConfirmSortOfProduct(string sproduct)
        {
            var con = connect();
            var cmstr = "SELECT * FROM LoaiHangHoa WHERE TenLHH = @name";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@name", sproduct);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        static public bool AddSortOfProduct(string product)
        {
            if (!ConfirmSortOfProduct(product))
                return false;
            var con = connect();
            var cmstr = "INSERT INTO LoaiHangHoa(TenLHH) VALUES(@product)";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@product", product);
            command.ExecuteNonQuery();
            con.Close();
            return true;
            
        }
        static public bool ConfirmProduct(string product)
        {
            var con = connect();
            var cmstr = "SELECT * FROM HangHoa WHERE TenHH = @name";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@name", product);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }
        static public bool AddProduct(ProductModel product)
        {
            if (!ConfirmProduct(product.Name))
                return false;
            var con = connect();
            var cmstr = "INSERT INTO HangHoa(MaLHH, TenHH, Gia, MoTa, Hinhanh) VALUES(@categoryid,@name,@cost,@discribe,@Hinhanh)";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@categoryid", product.CategoryID);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@cost", product.Cost);
            command.Parameters.AddWithValue("@discribe", product.Discription);
            command.Parameters.AddWithValue("@Hinhanh", product.ImgLink);
            command.ExecuteNonQuery();
            con.Close();
            return true;
        }
        static public List<Product> GetProductsByCategory(int cateid)
        {
            var list = new List<Product>();
            var con = connect();
            var cmstr = "SELECT * FROM HangHoa WHERE MaLHH=@id";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@id", cateid);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var product = new Product
                {
                    CategoryID = reader.GetInt32(1),
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(2),
                    Cost = reader.GetInt64(3),
                    Discription = reader.GetString(4),
                    ImgLink = reader.GetString(5)
                };
                list.Add(product);
            }
            con.Close();
            return list;
        }
        static public void DeleteProduct(string name)
        {
            var con = connect();
            var cmstr = "DELETE FROM HangHoa WHERE TenHH=@name";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@name", name);
            command.ExecuteNonQuery();
            con.Close();
        }
        static public ProductModel GetProduct(int id)
        {
            ProductModel model = null;
            var con = connect();
            var cmstr = "SELECT * FROM HangHoa WHERE MaHH = @id";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                model = new ProductModel
                {
                    CategoryID = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Cost = reader.GetInt64(3),
                    Discription = reader.GetString(4),
                    ImgLink = reader.GetString(5),
                    ID = id
                   
                };
                break;
            }
            con.Close();
            return model;
        }
        static public List<Comment> GetComment(int pid)
        {
            var con = connect();
            var cmstr = "SELECT * FROM BinhLuan WHERE HHID=@pid";
            var list = new List<Comment>();
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@pid", pid);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Comment
                {
                    PID = pid,
                    UID = reader.GetInt32(1),
                    Context = reader.GetString(3),
                    Date = reader.GetDateTime(4)
                });
            
            }
            con.Close();
            return list;
        }
        static public void PostComment(Models.CommentModel model)
        {
            var con = connect();
            var cmstr = "INSERT INTO BinhLuan(TkID, HHID, NoiDung, Ngay) VALUES(@uid,@pid,@context,@date)";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.Add("@pid", model.PID);
            command.Parameters.Add("@uid", model.UID);
            command.Parameters.Add("@context", model.Comment);
            command.Parameters.Add("@date", DateTime.Now);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}