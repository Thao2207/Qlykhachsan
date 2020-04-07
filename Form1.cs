using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Qlykhachsan
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EBUEM7R\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True");
            con.Open();
            string sql = " Select * From tblPhong";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tabletblPhong = new DataTable();
            adp.Fill(tabletblPhong);
            dataGridView_tblPhong .DataSource = tabletblPhong;
        }

        private void dataGridView_tblPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDonGia.Text = dataGridView_tblPhong.CurrentRow.Cells["DonGia"].Value.ToString();
            txtMaPhong.Text = dataGridView_tblPhong.CurrentRow.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = dataGridView_tblPhong.CurrentRow.Cells["TenPhong"].Value.ToString();
            txtMaPhong.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            string sql = "delete from tblPhong where MaPhong'" + txtMaPhong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
           

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtDonGia.Text = "";
            txtMaPhong.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaPhong.Text == "")
            {
                MessageBox.Show("ban can nhap ma phong");
                txtMaPhong.Focus();
                return;
            }  
            if (txtTenPhong.Text == "" )
            {
                MessageBox.Show("ban can nhap ten phong");
                txtTenPhong.Focus();
                return;
            }    
            else
            {
                string sql = "insert into tblPhong values('" + txtMaPhong.Text + "','" + txtTenPhong.Text + "'";
                if (txtDonGia.Text != "")
                    sql = sql + "," + txtDonGia.Text.Trim();
                sql = sql + ")";
                MessageBox.Show(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            txtMaPhong.Enabled = true;
            string sql = "update phong set tenphong= '" + txtTenPhong.Text + "', dongia = '" + txtDonGia.Text + "' where maphong= '" + txtMaPhong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtDonGia.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }
    }

}
