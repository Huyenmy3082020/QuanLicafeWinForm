using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DTO
{
    public class TableFood
    {
        private int id;
        private string name;
        private string status;

        public string Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }


        public TableFood() { }
        public TableFood(int id, string name, string status)
        {

            this.id = id;
            this.name = name;
            this.status = status;
        }
        
        public TableFood(DataRow row)
        {
            this.id= (int)row["ID"];
            this.name = row["name"].ToString();
            this.Status= row["status"].ToString();
        }
    }
}
