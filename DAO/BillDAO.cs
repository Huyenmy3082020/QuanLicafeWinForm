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
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();

                }
                return instance;
            }
            set => instance = value;
        }
        BillDAO() { }
        public int LayRaIDcuaBill(int id)
        {
            DataTable data = DataProvider.Instance.excuteQuery("select *from Bill where idTable =" + id+"and status =0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;

        }
        public void checkOut(int id,int discount,float totalprice)
        {
            string query = "update Bill set dateOut=getdate(),  status = 1 ," + " discount = " + discount + ", " + " totalprice = " + totalprice + " where id = " +id ;
            DataProvider.Instance.excuteNonQuery(query);
        }

        public void insertBill(int id)
        {
            DataProvider.Instance.excuteQuery("themmoi @idtable",new object []{id});

        }

        public int laymaxId()
        {
         
             return  (int )DataProvider.Instance.excuteScalar("select max(id) from Bill");
          
          
        }
        public DataTable getlistDate (DateTime checkin ,DateTime checkout)
        {
         return   DataProvider.Instance.excuteQuery("getBillByDate @checkin , @checkout", new object[] { checkin, checkout });
        }
    }
}