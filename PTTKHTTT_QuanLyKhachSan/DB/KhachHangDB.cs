using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class KhachHangDB
    {
        public static KhachHang TT_LayThongTinKhach(int MAPDP)
        {
            try
            {
                DataTable MAKH = DBConnect.SQL_select(
                            "select MAKH from PHIEUDATPHONG where MAPDP = " + MAPDP.ToString());
                DataTable tb = DBConnect.SQL_select(
                            "select * from KHACHHANG where MAKH = " + MAKH.Rows[0][0]);
                KhachHang kh = new KhachHang();
                kh.MAKH = (int)tb.Rows[0]["MAKH"];
                kh.HOTEN = tb.Rows[0]["HOTEN"].ToString();
                kh.CCCD = tb.Rows[0]["CCCD"].ToString();
                kh.SDT = tb.Rows[0]["SDT"].ToString();
                kh.DIACHI = tb.Rows[0]["DIACHI"].ToString();
                kh.FAXID = (int)tb.Rows[0]["FAXID"];
                kh.EMAIL = tb.Rows[0]["EMAIL"].ToString();
                return kh;
            }
            catch
            {
                return null;
            }

        }
        public static List<KhachHang> DVTour_LayDSKhachHang()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select * from KHACHHANG");
                List<KhachHang> ds = new List<KhachHang>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new KhachHang
                    {
                        MAKH = (int)row["MAKH"],
                        HOTEN = row["HOTEN"].ToString(),
                        CCCD = row["CCCD"].ToString(),
                        SDT = row["SDT"].ToString(),
                        DIACHI = row["DIACHI"].ToString(),
                        FAXID = (int)row["FAXID"],
                        EMAIL = row["EMAIL"].ToString(),

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

