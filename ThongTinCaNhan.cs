using QuanLiCafe.Dao;
using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCafe
{
    public partial class ThongTinCaNhan : Form
    {
        public ThongTinCaNhan(Account acc)
        {
            loginaccount = acc;
            InitializeComponent();
        }
        private Account loginaccount;

        public Account Loginaccount
        {
            get => loginaccount; set
            {
                loginaccount = value;
                channgeAccount(loginaccount);
            }


        }
        void channgeAccount(Account acc)
        {
            txtTenDangNhap.Text = loginaccount.Username;
            txtTenHienThi.Text = loginaccount.Displayname;
        }


        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {

        }
        void updateAccount()
        {
            string displayname = txtTenHienThi.Text;
            string password = txtMatKhau.Text;
            string newpassword = txtMatKhauMoi.Text;
            string username = txtTenDangNhap.Text;
            string reneter = txtNhapLai.Text;
            if (newpassword.Equals(reneter))
            {
                MessageBox.Show("vui long nhap lai mat khau ");
            }
            else
            {
                if (AccountDao.Instance.UpdateAcoount(username, displayname, password, newpassword))
                {
                    MessageBox.Show("Cap nhat thanh cong");
                }
                else
                {
                    MessageBox.Show("Vui long kiem tra lai tai khoan hoac mat khau ");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            updateAccount();
        }
    }
}
