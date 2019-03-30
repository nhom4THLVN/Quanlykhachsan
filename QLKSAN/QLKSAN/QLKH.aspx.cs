using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace QLKSAN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDL();
            bntCo.Visible = false;
            bntKhong.Visible = false;
            
        }
        private void LoadDL()
        {
            KHACHHANGDAO khDAO = new KHACHHANGDAO();
            gvKH.DataSource = khDAO.LayKhachHang();
            gvKH.DataBind();
        }
        public void DoDuLieuVaoCacTruong(KHACHHANG KH)
        {
            txtCMND.Text = KH.Cmnd;
            txtHoten.Text = KH.Hoten;
            rdbGioitinh.SelectedValue = KH.Gioitinh.ToString();
            txtSDT.Text = KH.Sdt;
            txtDC.Text = KH.Diachi;
        }
        private KHACHHANG LayDuLieuTuForm()
        {
            string cmnd = txtCMND.Text;
            string hoten = txtHoten.Text;
            string gioitinh = rdbGioitinh.SelectedValue;
            string sdt = txtSDT.Text;
            string diachi = txtDC.Text;

            KHACHHANG kh = new KHACHHANG
            {
                Cmnd = cmnd,
                Hoten = hoten,
                Gioitinh = gioitinh,
                Sdt = sdt,
                Diachi = diachi
            };
            return kh;
        }

        private void XoaNoiDungForm(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                (ctrl as TextBox).Text = string.Empty;
                txtCMND.Enabled = true;
            }
            else
            {
                rdbGioitinh.SelectedValue = null;
            }

            foreach (Control i in ctrl.Controls)
            {
                XoaNoiDungForm(i);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            string cmnd = txtCMND.Text;
            if (string.IsNullOrEmpty(cmnd))
            {
                lblThongbao.Text = "Mời bạn chọn khách hàng cần xóa";
            }
            else
            {
                bntCo.Visible = true;
                bntKhong.Visible = true;
                lblThongbao.Text = "Bạn có chắc chắn muốn xóa";

            }
        }

        protected void bntXoatrong_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            XoaNoiDungForm(this);
            lblThongbao.Text = "";

        }

        protected void gvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCMND.Enabled = false;
            int dong = gvKH.SelectedIndex;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM KHACHHANG", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtHoten.Text = dt.Rows[dong][0].ToString();
            txtCMND.Text = dt.Rows[dong][1].ToString();
            rdbGioitinh.SelectedValue = dt.Rows[dong][2].ToString();
            txtSDT.Text = dt.Rows[dong][3].ToString();
            txtDC.Text = dt.Rows[dong][4].ToString();
        }

        protected void bntthem_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = LayDuLieuTuForm();
            KHACHHANGDAO khDAO = new KHACHHANGDAO();
            if (txtHoten.Text == string.Empty || txtCMND.Text == string.Empty || rdbGioitinh.SelectedValue == string.Empty || txtSDT.Text == string.Empty | txtDC.Text == string.Empty)
            {
                lblThongbao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {
                bool exist = khDAO.KTKhachHang(kh.Cmnd);
                if (exist)
                {
                    lblThongbao.Text = "Khách hàng đã tồn tại";
                }
                else
                {
                    bool result = khDAO.Them(kh);
                    if (result)
                    {
                        lblThongbao.Text = "Thêm khách hàng thành công";
                        LoadDL();
                    }
                    else
                    {
                        lblThongbao.Text = "Có lỗi, vui lòng thử lại!";
                    }
                }
            }
        }

        protected void bntsua_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = LayDuLieuTuForm();
            KHACHHANGDAO khDAO = new KHACHHANGDAO();
            if (txtHoten.Text == string.Empty || txtCMND.Text == string.Empty || rdbGioitinh.SelectedValue == string.Empty || txtSDT.Text == string.Empty | txtDC.Text == string.Empty)
            {
                lblThongbao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {
                bool result = khDAO.ChinhSua(kh);
                if (result)
                {
                    lblThongbao.Text = "Cập nhật thành công";
                    LoadDL();
                }
                else
                {
                    lblThongbao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
                }
                XoaNoiDungForm(this);
            }
        }

        protected void bntTimkiem_Click(object sender, EventArgs e)
        {
            string key = txtTimkiem.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                lblThongbao.Text = "Mời bạn nhập thông tin tìm kiếm";
            }
            else
            {
                lblThongbao.Text = "Kết quả tìm kiếm";
                KHACHHANGDAO khDAO = new KHACHHANGDAO();
                gvKH.DataSource = khDAO.Tim(key);
                gvKH.DataBind();
                { 
                    
                }
            }         
        }

        protected void bntCo_Click(object sender, EventArgs e)
        {
            string cmnd = txtCMND.Text;

            KHACHHANGDAO khDAO = new KHACHHANGDAO();
            bool result = khDAO.Xoa(cmnd);
            if (result)
            {
                lblThongbao.Text = "Xóa thành công";
                LoadDL();
            }
            else
            {
                lblThongbao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }
            XoaNoiDungForm(this);
        }

        protected void bntKhong_Click(object sender, EventArgs e)
        {
            bntCo.Visible = false;
            bntKhong.Visible = false;
            lblThongbao.Text = "";
        }
    }
}