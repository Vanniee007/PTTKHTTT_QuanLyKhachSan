using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKHTTT_QuanLyKhachSan.DB
{
    class DBConnect
    {
        static string chuoiKetNoi = "Data Source=LAPTOP-5OL2FINF\\SQLEXPRESS;Initial Catalog=PTTKHTTT_QLKS;Integrated Security=True";
        public static SqlConnection traCon = new SqlConnection(chuoiKetNoi);
        public static DataTable SQL_select(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(chuoiKetNoi);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();//Mở kết nối
                }
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dataRead = com.ExecuteReader();
                dt.Load(dataRead);//Đưa dữ liệu vào bảng
                con.Close();//Đóng kết nỗi
                return dt;
            }
            catch
            {
                //MessageBox.Show("Lỗi hệ thống!", "Thông báo");
                return dt;
            }


        }
        public static int SQL_insert_update_delete(string query)
        {
            SqlConnection con = new SqlConnection(chuoiKetNoi);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();//Mở kết nối
            }
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                int SQL_status = com.ExecuteNonQuery();
                return SQL_status;
            }
            catch
            {
                //MessageBox.Show("Lỗi hệ thống giao tác!", "Thông báo");
            }
            con.Close();//Đóng kết nỗi
            return -1;

        }
        public static string SQL_SelectOneRow(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(chuoiKetNoi);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();//Mở kết nối
                }
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = query;
                com.Connection = con;
                string giatri = (string)com.ExecuteScalar();
                con.Close();
                return giatri;
            }
            catch
            {
                return "";
            }
        }
    }
}
