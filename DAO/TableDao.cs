using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.Dao
{
    public class TableDao
    {
        private static TableDao instance;
        private TableDao() { 
        }
       public static TableDao Instance { 
            get
            {
                if (instance == null)
                {
                    instance = new TableDao();  
                }
                return instance;
            } 
            set => instance = value; }

        public void switchtable (int id1, int id2)
        {
            DataProvider.Instance.excuteQuery("SwitchTable @idTable1 ,@idTable2  ", new object[] { id1, id2});

        }
        public List<Table> LoadListtable()
        {
            DataTable data = DataProvider.Instance.excuteQuery("Select *from TableFood");
            List<Table> list = new List<Table>();
            foreach (DataRow item in data.Rows )
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;

            // danh sach table 
        }
       
    }
   
}
