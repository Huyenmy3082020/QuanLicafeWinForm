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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool Login(string userName, string passWord)
        {

           return AccountDao.Instance.Login(userName, passWord);

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string userName= txtTenDangNhap.Text;
            Account loginaccount = AccountDao.Instance.getAcountbyUserName(userName);

            string passWord = txtMatKhau.Text;
            if (Login( userName,passWord))
            {
                TableManeger tableManeger = new TableManeger(loginaccount);
                this.Hide();
                tableManeger.ShowDialog();
                this.Show();
            }
           else
            {
                MessageBox.Show("oi ban oi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MessageBox.Show("Bạn có muốn thoát chương trinh ", "thong bao",MessageBoxButtons.OKCancel )!= DialogResult.OK))
            {
                e.Cancel=true;
            }
        }
    }
}
