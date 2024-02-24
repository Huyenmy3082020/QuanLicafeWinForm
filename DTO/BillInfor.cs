using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DTO
{
    public class BillInfor
    {
        private int id;
        private int billID;
        private int foodID;
        private int count;

     
        public BillInfor(int id, int billID, int foodID, int count)
        {
            
            Id = id;
            Count = count;
            BillID = billID;
            FoodID = foodID;
        }

        public BillInfor(DataRow row) { 
            this.id=(int)row["id"];
            this.count = (int)row["count"];
            this.billID = (int)row["idBill"];
            this.foodID = (int)row["idFood"];
                }
        public int Id { get => id; set => id = value; }
       
        public int Count { get => count; set => count = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
    }
}
