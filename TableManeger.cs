using QuanLiCafe.Dao;
using QuanLiCafe.DAO;
using QuanLiCafe.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuanLiCafe
{
    public partial class TableManeger : Form
    {
        private Account loginaccount;

        public Account Loginaccount {
            get => loginaccount; set { loginaccount = value ;
                channgeAccount(loginaccount.TypeAcc);
            }
            
        
        }

        public TableManeger(Account acc)
        {
            InitializeComponent();
            this.loginaccount = acc;
              LoadCateGory();
              LoadTable();
            loadComboboxTable(cbxChuyenBan);
        }
        void channgeAccount (int typeAcc)
        {
            adminToolStripMenuItem.Enabled = typeAcc == 1;

        }

        //  nút thêm mới
        private void button1_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;
            int idBill = BillDAO.Instance.LayRaIDcuaBill(table.Id);
            int idFood = (cbxFood.SelectedItem as Food).Id;
            int count = (int)nmrFoodcount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.insertBill(table.Id);
                  BillForDAO.Instance.insertBillInfo(BillDAO.Instance.laymaxId(),idFood,count);
            }
            else
            {
                BillForDAO.Instance.insertBillInfo(idBill, idFood, count);
            }
            showBill(table.Id);
            LoadTable();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan  thongTinCaNhan = new ThongTinCaNhan(loginaccount);
            thongTinCaNhan.ShowDialog();

                
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.ShowDialog();
        }
        void LoadCateGory()
        {
            List<Category> list = catgoryADO.Instance.LayIdTuCategory();
            cbxCategory.DataSource=list;
            cbxCategory.DisplayMember = "name";
        }

        void LoadListTableCategoryId(int id)
        {
            List<Food> list_food= FoodDOa.Instance.getIDFood(id);
            cbxFood.DataSource=list_food;
            cbxFood.DisplayMember = "name";

          
        }
        void LoadDanhSachTaiKhoan ()
        {
            List<Account> listAcc = AccountDao.Instance.GetAccounts();
           

        }
        void LoadTable()
        {
            flowLayoutPanel2.Controls.Clear();
            List<Table> list_table =TableDao.Instance.LoadListtable();
            foreach (Table table in list_table)
            {
                Button btn = new Button() { Width = 100, Height = 100 };
                btn.Text= table.Name+Environment.NewLine+table.Status;
                btn.Tag= table;
                btn.Click += btn_click;

                if (table.Status == "Trong")
                {
                    btn.BackColor = Color.LightSkyBlue;
                   
                }
                else  
                {
                    btn.BackColor = Color.Pink;
                }
                flowLayoutPanel2.Controls.Add(btn);
              }
        }

        void showBill(int id)
        {
            listView1.Items.Clear();
            List<Menu1> listBill = MenuDao.Instance.GetMenus(id);
            float totalPrice = 0;
            foreach(Menu1 item in listBill)
            {
                ListViewItem lvitem=new ListViewItem(item.Name.ToString());
                lvitem.SubItems.Add(item.Count.ToString());
                lvitem.SubItems.Add(item.Price.ToString());
                lvitem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice+= item.TotalPrice;
                listView1.Items.Add(lvitem);
            }
          
            txtTongTien.Text = totalPrice.ToString();

          
        }
        private void btn_click(object sender, EventArgs e)
        {

            int table_Id = ((sender as Button).Tag as Table).Id;
            listView1.Tag = (sender as Button).Tag;
            showBill(table_Id);

        }

        private void numericUpDownThemMon_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TableManeger_Load(object sender, EventArgs e)
        {

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return; 
            }
            Category seleted= cb.SelectedItem as Category;
            id =seleted.Id;
            LoadListTableCategoryId(id);
          

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            int idBill=BillDAO.Instance.LayRaIDcuaBill(table.Id);
            int discount = Convert.ToInt32(numGiamGia.Value);
            double totalprice=Convert.ToDouble(txtTongTien.Text.Split(' ')[0]);
            double finaltotalprice = totalprice - (totalprice / 100) * discount;
            if (idBill != -1)
            {
                if (MessageBox.Show("ban muon thanh toan hao don cho"+table.Name,"thong bao",MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.checkOut(idBill,discount,(float)finaltotalprice);
                    showBill(table.Id);
                    LoadTable();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ban co muon chuyen ban ", "thong bao ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int id1 = (listView1.Tag as Table).Id;

                int id2 = (cbxChuyenBan.SelectedItem as Table).Id;

                TableDao.Instance.switchtable(id1, id2);

                LoadTable();
            }

        }
        void loadComboboxTable (ComboBox box)
        {
            box.DataSource = TableDao.Instance.LoadListtable();
            box.DisplayMember = "name";
        }
    }
 }
