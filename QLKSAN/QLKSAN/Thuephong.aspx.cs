using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QLKSAN
{
    public partial class Thuephong : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            load_data();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Maphong FROM PHONG WHERE Tinhtrang = 'False'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlMaphong.DataSource = dt;
                ddlMaphong.DataTextField = "Maphong";
                ddlMaphong.DataValueField = "Maphong";
                ddlMaphong.DataBind();
            }
        }
         public void load_data()
             {
                 using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                 {
                     con.Open();
                     SqlDataAdapter da = new SqlDataAdapter("Select * FROM KHACHHANG", con);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     gvKH.DataSource = dt;
                     gvKH.DataBind();
                 }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string maPhong = ddlMaphong.DataValueField;
            string maNV = txtmanhanvien.Text;
            string cmnd = txtCMND.Text;
            string ngaythue = txtNgaythue.Text;
            if (maPhong == string.Empty || maNV == string.Empty || cmnd == string.Empty || ngaythue == string.Empty)
            {
                lblThongbao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {

                string connectionString = "Data Source=DESKTOP-14FDJVC\\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                string sql = "INSERT INTO THUEPHONG values (@maphong, @manv, @cmnd, @ngaythue)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maphong", ddlMaphong.DataValueField);
                cmd.Parameters.AddWithValue("@manv", txtmanhanvien.Text);
                cmd.Parameters.AddWithValue("@cmnd", txtCMND.Text);
                cmd.Parameters.AddWithValue("@ngaythue", txtNgaythue.Text);
                int sl = (int)cmd.ExecuteNonQuery();
                if (sl > 0)
                {
                    lblThongbao.Text = "Thêm thành công";
                    string sql1 = "UPDATE PHONG SET Tinhtrang = 'True' where Maphong ='" + ddlMaphong.DataValueField + "' ";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                }
                else
                    lblThongbao.Text = "Không thành công vui lòng nhập lại";
            }
        }

        protected void gvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dong = gvKH.SelectedIndex;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM KHACHHANG", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCMND.Text = dt.Rows[dong][1].ToString();
                     
        }

        protected void bntTimkiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimkiem.Text))
            {
                lblThongbao.Text = "Mời bạn nhập thông tin tìm kiếm";
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG where CMND LIKE N'%" + txtTimkiem.Text + "%' OR HoTen LIKE N'%" + txtTimkiem.Text + "%'", con);
                da.Fill(dt);
                gvKH.DataSource = dt;
                gvKH.DataBind();
            }
        }
            
    }
}