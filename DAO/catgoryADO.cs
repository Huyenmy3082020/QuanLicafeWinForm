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
    public class catgoryADO
    {
        private static catgoryADO instance;

      public catgoryADO()
        {

        }

        public static catgoryADO Instance { 
            get
            {
                if (instance == null)
                {
                    instance = new catgoryADO();

                }
                return instance;
            }
                
             private set => instance = value; }
       
        public List<Category> LayIdTuCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select *from FoodCategory ";
            DataTable data= DataProvider.Instance.excuteQuery(query);   
            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);
                list.Add(category);
            }
            return list;

        }
    /*    public Category GetCategorybyId(int id)
        {
            Category category = null;
            List<Category> list_categorybyId = new List<Category>();
            string query = "select *from FoodCategory where  id =" + id;
            DataTable data = DataProvider.Instance.excuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Category category1 = new Category(row);
                list_categorybyId.Add(category1);
            }
            return list_categorybyId;

        }*/
    }
}
