using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QLKSAN
{
    public class KHACHHANGDAO
    {
     
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


        public bool KTKhachHang(string cm)
        {
            string sql = @"SELECT COUNT(*) FROM KHACHHANG WHERE CMND = @cmnd";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cmnd", cm);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        
        public bool Them(KHACHHANG KH)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO KHACHHANG(HoTen,CMND,Gioitinh,Sdt,Diachi) VALUES(@hoten,@cmnd, @gioitinh, @sdt, @diachi)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@hoten", KH.Hoten);
                    command.Parameters.AddWithValue("@cmnd", KH.Cmnd);
                    command.Parameters.AddWithValue("@gioitinh", KH.Gioitinh);
                    command.Parameters.AddWithValue("@sdt", KH.Sdt);
                    command.Parameters.AddWithValue("@diachi", KH.Diachi);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return (result >= 1);
                }
            }
        }
        public DataTable LayKhachHang()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM KHACHHANG";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public KHACHHANG LayKhachHangCMND(string cm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM KHACHHANG WHERE CMND = @cmnd";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@cmnd", cm);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    KHACHHANG kh = new KHACHHANG
                    {
                        Cmnd = (string)reader["CMND"],
                        Hoten = (string)reader["HoTen"],
                        Gioitinh = (string)reader["Gioitinh"],
                        Sdt = (string)reader["Sdt"],
                        Diachi = (string)reader["Diachi"],
                    };
                    return kh;
                }
            }
            return null;
        }
        public bool ChinhSua(KHACHHANG KH)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE KHACHHANG SET HoTen=@HoTen, Gioitinh = @gioitinh, Sdt=@sdt, Diachi = @diachi WHERE CMND = @cmnd";
                SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@cmnd", KH.Cmnd);
                    command.Parameters.AddWithValue("@hoten", KH.Hoten);
                    command.Parameters.AddWithValue("@gioitinh", KH.Gioitinh);
                    command.Parameters.AddWithValue("@sdt", KH.Sdt);
                    command.Parameters.AddWithValue("@diachi", KH.Diachi);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string cmnd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM KHACHHANG WHERE CMND = @cmnd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cmnd", cmnd);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from KHACHHANG where CMND LIKE N'%" + key + "%' or Hoten LIKE N'%" + key + "%'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
       
    }
}
