using QuanLiCafe.Dao;
using QuanLiCafe.DAO;
using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCafe
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Load();           
        }
      void LoadDoanhThu(DateTime checkIn, DateTime checkout)
        {
            dataGridViewDoanhThu.DataSource=BillDAO.Instance.getlistDate(checkIn, checkout);
        }
        private void btnThucAnXoa_Click(object sender, EventArgs e)
        {

        }
        void Load()
        {
            LoadDoanhThu(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadListFood();
            LoadCategory(comboBoxDanhmuc);
         /*   addFoodBinding();*/

            LoadDanhSachTaiKhoan();
        /*    addBinddingAccount();*/
        
            LoadTypeAccount(cbxLoaiTaiKhoan);
            LoadListTableFood();
            InDanhSachCategory();
        }

        private void dataGridViewThucAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThucAnXem_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnDoanhThuTimKiem_Click(object sender, EventArgs e)
        {
            LoadDoanhThu(dateTimePicker1.Value,dateTimePicker2.Value);
        }

        void LoadListFood()
        {
            dataGridViewThucAn.DataSource = FoodDOa.Instance.getListFood();
        }

        private void btnBanAnXem_Click(object sender, EventArgs e)
        {
           
        }
    /*    void addFoodBinding()
        {
            txtTenMon.DataBindings.Add(new Binding("text", dataGridViewThucAn.DataSource, "Name"));
            txtIDMon.DataBindings.Add(new Binding("text",dataGridViewThucAn.DataSource,"ID"));
         *//*   numericUpDownGiaThucAn.DataBindings.Add(new Binding("value", dataGridViewThucAn, "price"));
            *//*

        }*/
      /*  void addBinddingAccount()
        {
            txtTenTaiKhoan.DataBindings.Add(new Binding("text",dataGridViewTaiKhoan.DataSource, "userName"));
            txtTenHienThi.DataBindings.Add(new Binding("text", dataGridViewTaiKhoan.DataSource, "displayName"));

        }*/
        void LoadCategory (ComboBox cbx)
        {
            cbx.DataSource = catgoryADO.Instance.LayIdTuCategory();
            cbx.DisplayMember = "Name";
        }
        void LoadTypeAccount(ComboBox cbx)
        {
            cbx.DataSource = AccountDao.Instance.GetAccounts();
            cbx.DisplayMember= "Type";  
        }
        void LoadDanhSachTaiKhoan()
        {

            dataGridViewTaiKhoan.DataSource = AccountDao.Instance.GetAccounts();

        }
        public void InDanhSachCategory()
        {
            dataGridViewDanhMuc.DataSource = catgoryADO.Instance.LayIdTuCategory();
        }
        private void cbxDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void LoadListTableFood()
        {
            dataGridViewBanAn.DataSource=TableFoodDAO.Instance.getListTableFood();
        }
     /*   void addBinddingTableFood()
        {
            txtId.DataBindings.Add(new Binding("text", dataGridViewBanAn.DataSource, "id"));
            txtTenBan.DataBindings.Add(new Binding("text", dataGridViewBanAn.DataSource, "name"));
            txtTrangThai.DataBindings.Add(new Binding("text", dataGridViewBanAn.DataSource, "status"));
        }*/
        void addCellTableFood()
        {
        
        }
        private void txtTenBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewBanAn.Rows[e.RowIndex];
            txtId.Text = Convert.ToString(row.Cells["id"].Value);
            txtTenBan.Text = Convert.ToString(row.Cells["name"].Value);
            txtTrangThai.Text = Convert.ToString(row.Cells["status"].Value);

        }
        
        private void btn1BanAnThem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewThucAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewThucAn.Rows[e.RowIndex];
            txtIDMon.Text= Convert.ToString(row.Cells["id"].Value);
            txtTenMon.Text = Convert.ToString(row.Cells["name"].Value);
            comboBoxDanhmuc.Text = Convert.ToString(row.Cells["idCategory"].Value);
            numericUpDownGiaThucAn.Value= Convert.ToInt32(row.Cells["price"].Value);
        }

        private void btnThucAnThem_Click(object sender, EventArgs e)
        {
            string name = txtTenMon.Text;
            int categoryid = (comboBoxDanhmuc.SelectedItem as Category).Id;
            double price = Convert.ToDouble(numericUpDownGiaThucAn.Value);
            if (FoodDOa.Instance.InsertFood(name, categoryid, price))
            {
                MessageBox.Show("them thanh cong");
                LoadListFood();
            }
        }
        List<Food> SearchByName(string name)
        {
            List<Food> listFood =
            FoodDOa.Instance.searchFoodByName(name);
            return listFood;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewThucAn.DataSource= SearchByName(txtTimKiem.Text);
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    } 
}
