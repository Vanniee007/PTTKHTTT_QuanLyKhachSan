using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

