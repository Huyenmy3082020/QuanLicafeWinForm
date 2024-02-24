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
    public class FoodDOa
    {
        private static FoodDOa instance;

        public static FoodDOa Instance { 
            get
            {
                if (instance == null)
                {
                    instance = new FoodDOa();
                }
                return instance;
            }
            private set => instance = value; }


        public List<Food> getIDFood(int id)
        {
            List<Food> foodList = new List<Food>();
            string sql = "select *from Food where idCategory= '" + id + "'";
            DataTable data = DataProvider.Instance.excuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                Food f = new Food(row);
                foodList.Add(f);
            }
            return foodList;
            
        }


        public List<Food> getListFood()
        {
            List<Food> foodList = new List<Food>();
            string sql = "select *from Food "; 
            DataTable data = DataProvider.Instance.excuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                Food f = new Food(row);
                foodList.Add(f);
            }
            return foodList;

        }
        public bool InsertFood (string name, int id, double price)
        {
            string query
             = string.Format("insert Food (name,idCategory,price) values ({0},{1},{2})", name, id, price);
               DataTable result = DataProvider.Instance.excuteQuery(query); 


            return result.Rows.Count>0;
        }
        public List<Food> searchFoodByName(string name)
        {
            List<Food> list= new List<Food>();

            string query = "select *from Food where name = " + name;
            DataTable data = new DataTable();
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                list.Add(food);

            }
            return list;
        }

    }
}
