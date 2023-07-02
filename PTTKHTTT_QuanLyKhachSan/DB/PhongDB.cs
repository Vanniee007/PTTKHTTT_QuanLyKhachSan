using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class PhongDB
    {
        public static List<Phong> TT_LayDSPhong_ChiTietPDP(int MAPDP)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select CT.MAPHONG,LOAIPHONG,HANG,GIA,TINHTRANG from CHITIETPHIEUDATPHONG  CT " +
                            "inner JOIN PHONG ON CT.MAPHONG = PHONG.MAPHONG " +
                            "where CT.MAPDP = " + MAPDP.ToString());
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }

        public static List<Phong> PDP_LayDSPhongTrong_TheoNgay(string NgayBD, string NgayKT)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("EXEC LayDSPhongDeDat @StartDate = '"+NgayBD+"', @EndDate = '"+NgayKT+"';");
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
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

