using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SieuThiMVC.DataAccess
{
    public class UserProfileDBO : DBO
    {
        static public bool ConfirmUser(string username)
        {
            var con = connect();
            con.Open();

            con.Close();
            return false;
        }
        static public SieuThiMVC.Models.SecretQuestion[] GetQuestions()
        {
            var r = new List<SieuThiMVC.Models.SecretQuestion>();
            var con = connect();
            var comstr = "SELECT * FROM CauHoiBiMat";
            con.Open();
            var command = new SqlCommand(comstr, con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                r.Add(new Models.SecretQuestion { ID = reader.GetString(0), Q = reader.GetString(1) });
            }            
            con.Close();
            return r.ToArray();
        }
        static public List<Models.FullUserProfile>GetAccounts ()
        {
            var con = connect();
            var cmstr = "SELECT * FROM TaiKhoan";
            var list = new List<Models.FullUserProfile>();
            con.Open();
            var command = new SqlCommand(cmstr, con);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Models.FullUserProfile
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Birth = reader.GetDataTypeName(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4),
                    Identity = reader.GetString(5),
                    Phone = reader.GetString(6),
                    Gender = reader.GetString(7)
                });
            }
            con.Close();
            return list;
        }
        static public bool ConfirmEmail(string email)
        {
            var con = connect();
            var cmstr = "SELECT Email FROM TaiKhoan WHERE Email = @email";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@email", email);
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
        static public Models.FullUserProfile GetAccountInfo(int id)
        {
            var con = connect();
            Models.FullUserProfile profile = null;
            var cmstr = "SELECT * FROM TaiKhoan WHERE @id = id";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                profile = new Models.FullUserProfile
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Birth = reader.GetDataTypeName(2),
                    Address = reader.GetString(3),
                    Email = reader.GetString(4),
                    Identity = reader.GetString(5),
                    Phone = reader.GetString(6),
                    Gender = reader.GetString(7)

                };
                break;
            }
            con.Close();
            return profile;
        }
        static public bool UpdateProfile(Models.UpdateModel model)
        {
            try
            {
                var con = connect();
                var cmstr = "UPDATE TaiKhoan SET Email = @email, DiaChi = @address, SoCMND = @idcard, SoDT = @telnum, GioiTinh = @gender";
                con.Open();
                var command = new SqlCommand(cmstr, con);
                command.Parameters.AddWithValue("@email", model.Email);
                command.Parameters.AddWithValue("@address", model.Address);
                command.Parameters.AddWithValue("@idcard", model.Identitynum);
                command.Parameters.AddWithValue("@telnum", model.Phonenum);
                command.Parameters.AddWithValue("@gender", model.Gender);
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        static public void DeleteUserAccount(string name)
        {
            var con = connect();
            var cmstr = "DELETE FROM TaiKhoan WHERE TenTaiKhoan = @name";
            con.Open();
            var command = new SqlCommand(cmstr, con);
            command.Parameters.AddWithValue("@name", name);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
    
}