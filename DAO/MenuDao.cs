using QuanLiCafe.Dao;
using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCafe.DAO
{
    internal class MenuDao
    {
        private static MenuDao instance;

        public static MenuDao Instance {

            get
            {
                if (instance == null)
                {
                    instance = new MenuDao();
                }
                return instance;
            } 
                
                 set => instance = value; }

         private MenuDao()
        {

        }      
        public List<Menu1> GetMenus(int id )
        {
            List<Menu1> list = new List<Menu1>();

            string query = "select f.name,bi.count,f.price ,f.price*bi.count as totalprice from BillInfo as bi , Bill as b, Food as f Where b.status=0 and bi.idBill= b.id and bi.idFood=f.id and b.idTable =" + id;

          
            DataTable dataTable = DataProvider.Instance.excuteQuery(query);

           

            foreach (DataRow item in dataTable.Rows)
            {
                Menu1 m = new Menu1(item);
                list.Add(m);
            }
            return list;

           

        }
    }
}
