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



    }
}

