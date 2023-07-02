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
    public class HoaDonDB
    {
        public static List<HoaDon> LayDanhSachTatCa()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("select * from HoaDon");
                List<HoaDon> ds = new List<HoaDon>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new HoaDon
                    {
                        MAHD = (int)row["MAHD"],
                        NGAYLAP = SupportFunction.FormatShortDate(row["NGAYLAP"].ToString()),
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

    }
}

