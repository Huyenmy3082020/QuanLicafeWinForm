using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DTO
{
    public class Account
    {
        private string username;
        private string displayname;
        private int typeAcc;
        private string password;
        
        public Account(string username, string displayname, int typeAcc, string password=null)
        {
            this.username = username;
            this.displayname = displayname;
            this.typeAcc = typeAcc;
            this.password = password;
        }
       public Account (DataRow row)
        {
            this.username = row["username"].ToString();
            this.displayname = row["displayname"].ToString();
            this.typeAcc = Convert.ToInt32( row["typeAcc"]);
            this.password = row["password"].ToString();
        
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Displayname { get => displayname; set => displayname = value; }
        
        public int TypeAcc { get => typeAcc; set => typeAcc = value; }
    }
}
