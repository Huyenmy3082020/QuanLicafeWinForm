using QuanLiCafe.Dao;
using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DAO
{
    public class TableFoodDAO
    {
        private static TableFoodDAO instance;
        public TableFoodDAO() { }

        public static TableFoodDAO Instance { 
            get
            {
                if(instance == null)
                {
                    instance = new TableFoodDAO();
                }
                return instance;

            } 
            set => instance = value; }

        public List<TableFood> getListTableFood()
        {
            List<TableFood> tableFoods = new List<TableFood>();
            DataTable data = DataProvider.Instance.excuteQuery("select *from TableFood");
            foreach (DataRow item in data.Rows)
            {
                TableFood  tb= new TableFood(item);
                tableFoods.Add(tb);
            }
            return
                tableFoods;
        }

        public void InsertTableFood(string idcategory, string name , string status)
        {
            DataProvider.Instance.excuteQuery("insert into value )");
        }

    }
}
