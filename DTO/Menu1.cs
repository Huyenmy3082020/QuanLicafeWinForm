using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCafe.DTO
{
    public class Menu1
    {
   
        private float price;
        private float totalPrice;
        private string name;
        private int count;

        public float Price { get => price; set => price = value; }
     
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }

        public Menu1(string name,int count,float price ,float totalPrice=0)
        {
            this.name=name;
            this.count=count;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public Menu1()
        {

        }
        public Menu1(DataRow row) {
            this.name = row["name"].ToString();
            this.Count = (int)row["count"];
            this.price= (float)Convert.ToDouble( row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"]);

        }
    }
}
