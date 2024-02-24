using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DTO
{
    public class Table
    {
        int id;
         string name, status;
        public Table(int id, string name, string status) {
            this.name = name;
            this.Id = id;   
            this.status = status;
        }
        public Table (DataRow data)
        {
            this.Id = (int)data["id"];
            this.name = data["name"].ToString();
            this.status = data["status"].ToString();
        }

       
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }
    }
}
