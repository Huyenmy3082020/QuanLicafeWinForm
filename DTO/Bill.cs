using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.DTO
{
    public class Bill
    {
        private DateTime _date;
        private DateTime _time;

        private int id;
        private int status;
        private int discount;
        public Bill(DateTime _date, DateTime _time, int id,int status, int discount=0)
        {
            this._date = _date;
            this._time = _time;
            this.id = id;
            this.status = status;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.id = (int)row["id"];
            this._date=(DateTime)row["dataCheckIn"];
            var dateChekOut = row["dateOut"];
            if (dateChekOut.ToString()!="")
            {

            this._time = (DateTime) dateChekOut;
            }
            this.status = (int)row["status"];
            if (row["discount"].ToString() != "")
            {

            this.Discount = (int)row["discount"];
            }

        }
        public DateTime Date { get => _date; set => _date = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public int Id { get => id; set => id = value; }
        public int Statust { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
    
}
