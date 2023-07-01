using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class TaiKhoanDB
    {
        
        public static TaiKhoan getTaiKhoan(string username)
        {
            DataTable tb = new DataTable();
            tb = DBConnect.SQL_select("select * from TaiKhoan where username = '"+username+ "'");
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.username = tb.Rows[0][0].ToString();
            taikhoan.pass = tb.Rows[0][1].ToString();
            taikhoan.Loai = Int32.Parse(tb.Rows[0][2].ToString());
            return taikhoan;
        }
    }
}
