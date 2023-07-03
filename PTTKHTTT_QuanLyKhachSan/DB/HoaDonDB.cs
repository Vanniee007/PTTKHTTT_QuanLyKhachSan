using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class HoaDonDB
    {
        public static List<HoaDon> LayDanhSachTatCa()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("select * from HoaDon order by MaPDP desc");
                List<HoaDon> ds = new List<HoaDon>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new HoaDon
                    {
                        MAHD = (int)row["MAHD"],
                        NGAYLAP = row["NGAYLAP"].ToString(),
                        MAPDP = (int)row["MAPDP"],
                        TONGTIEN = (int)row["TONGTIEN"],
                        TINHTRANGTT = row["TINHTRANGTT"].ToString(),
                        MANV = (int)row["MANV"],
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public static int PDP_ThemHoaDon(int MaPDP)
        {
            try
            {
                return int.Parse(DBConnect.SQL_select("EXEC USP_LT_THANHTOANCOC @MAPDP = " + MaPDP.ToString()).Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }
        }

        public static bool CapNhatTinhTrang(string MaHD)
        {
            try
            {
                DBConnect.SQL_select("EXEC UPDATE_TTPHONG_TTHOADON @MAHD = " + MaHD);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string TT_TongTienHoaDon(string MaHD)
        {
            try
            {
                return DBConnect.SQL_select("SELECT dbo.uf_LT_CNTONGTIEN_HOADON("+ MaHD.ToString() + ")").Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}

