using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.Dao
{
    public class DataProvider
    {
        private static DataProvider instance;
         public DataProvider() { 
        }
        string ConnectionString = "Data Source=BLACKPINK\\SQLEXPRESS;Initial Catalog=QuanLiCafe_Winform;Integrated Security=True;Encrypt=False";

        public static DataProvider Instance {
            
            get
            {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                    return instance;
            }
            set => instance = value; 
        }
        //  Trả về 1 datatable chứa dữ liêuj 
        /*
         , object[] parameter=null*/
        public DataTable excuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            { 
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] values = query.Split(' ');
                    int i = 0;
                    foreach (string item in values)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();
            }

                return data;

        }
        // trả về số lượng phù hợp 
        public int excuteNonQuery(string query)
        {
            int data  = 0;
          
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {


                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);



                data = cmd.ExecuteNonQuery();
                conn.Close();
            }

            return data;

        }

        public object excuteScalar(string query)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {


                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);



                data = cmd.ExecuteScalar();
                conn.Close();
            }

            return data;

        }



    }
}
