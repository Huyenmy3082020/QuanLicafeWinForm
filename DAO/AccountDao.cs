using QuanLiCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLiCafe.Dao
{
    public class AccountDao
    {
        private static AccountDao instance;

        public static AccountDao Instance {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDao();
                }
                return instance;

            }
         private   set => instance = value; }
        private AccountDao()
        {

        }
        public List<Account> GetAccounts()
        {

            DataTable data = DataProvider.Instance.excuteQuery("select *from Account");
            List<Account> accounts = new List<Account>();
            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                accounts.Add(acc);
            }
            return accounts;
        }
        public bool Login (string username, string password)
        {
            string query = "select *from Account where userName= '" + username + "' and passWord='"+password+"'";
            DataTable data= DataProvider.Instance.excuteQuery(query);

            return data.Rows.Count>0;
        }
        public Account getAcountbyUserName(string username)
        {

           DataTable data= DataProvider.Instance.excuteQuery("select *from Account where userName = '" + username + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;

        }
        public bool UpdateAcoount(string username, string displayname, string password, string newpassword)
        {
            DataTable data = DataProvider.Instance.excuteQuery(" exec updateAccount @userName, @displayname , @passWord , @newPassword ", new object[] { username, displayname, password, newpassword });

            return data.Rows.Count > 0;
        
        }
         
    }
   
}
