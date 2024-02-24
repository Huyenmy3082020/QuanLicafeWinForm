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
    public class BillForDAO
    {
        private  static BillForDAO instance;

        public static BillForDAO Instance { 
            get
            {
                if (instance == null)
                {
                    instance= new BillForDAO();
                }
                return instance;
            } 
            private set => instance = value; }

        public List<BillInfor> layBillInfor(int id)
        {
            List<BillInfor> billInfors = new List<BillInfor>();

            DataTable data = DataProvider.Instance.excuteQuery("selectBillInfo  @id", new object[]{id});
            foreach (DataRow item in data.Rows)
            {
                BillInfor bill = new BillInfor(item);
                billInfors.Add(bill);
            }
            return billInfors;
        }
        public void insertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.excuteQuery("KiemTraTonTai @idBill , @idFood , @count",new object[] {idBill,idFood,count});


        }

       
    }
}

