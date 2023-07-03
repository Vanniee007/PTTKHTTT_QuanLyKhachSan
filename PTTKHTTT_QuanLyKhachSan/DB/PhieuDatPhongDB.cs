using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class PhieuDatPhongDB
    {
        public static List<PhieuDatPhong> LayDanhSachTatCa()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("select * from PhieuDatPhong order by MAPDP DESC");
                List<PhieuDatPhong> ds = new List<PhieuDatPhong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new PhieuDatPhong
                    {
                        MAPDP = (int)row["MAPDP"],
                        NGAYLAP = row["NGAYLAP"].ToString(),
                        NGAYNHANPHONG = SupportFunction.FormatShortDate(row["NGAYNHANPHONG"].ToString()),
                        NGAYTRAPHONG = SupportFunction.FormatShortDate(row["NGAYTRAPHONG"].ToString()),
                        MAKH = (int)row["MAKH"],
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

        public static int PDP_ThemPhieuDatPhong(PhieuDatPhong phieu)
        {
            try
            {
                return int.Parse(DBConnect.SQL_select("EXEC USP_LT_TAOPHIEUDATPHONG '" + phieu.NGAYNHANPHONG + "', '" + phieu.NGAYTRAPHONG + "', " + phieu.MAKH + ", " + phieu.MANV).Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }
        }
        //Chỉ lấy về MAPDP 
        public static int QLPhong_LayMaPDP(int MaPhong)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("select PDP.MAPDP from PHIEUDATPHONG PDP INNER JOIN CHITIETPHIEUDATPHONG CTP ON PDP.MAPDP=CTP.MAPDP " +
                    "where CTP.MAPHONG='" + MaPhong + "' and (GETDATE()>=PDP.NGAYNHANPHONG AND GETDATE() <=PDP.NGAYTRAPHONG)");
                if (tb.Rows.Count == 1)
                {
                    return Convert.ToInt32(tb.Rows[0][0]);
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        public static List<PhieuDatPhong> QLPhong_xempdp_LayDSPDP(int MaPhong)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("SELECT *\r\nFROM PHIEUDATPHONG\r\n" +
                    "WHERE MAPDP IN (\r\n    SELECT MAPDP\r\n    FROM CHITIETPHIEUDATPHONG\r\n   " +
                    " WHERE MAPHONG = '"+MaPhong+"');\r\n");
                List<PhieuDatPhong> ds = new List<PhieuDatPhong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new PhieuDatPhong
                    {
                        MAPDP = (int)row["MAPDP"],
                        NGAYLAP = SupportFunction.FormatShortDate(row["NGAYLAP"].ToString()),
                        NGAYNHANPHONG = SupportFunction.FormatShortDate(row["NGAYNHANPHONG"].ToString()),
                        NGAYTRAPHONG = SupportFunction.FormatShortDate(row["NGAYTRAPHONG"].ToString()),
                        MAKH = (int)row["MAKH"],
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



    }
}

