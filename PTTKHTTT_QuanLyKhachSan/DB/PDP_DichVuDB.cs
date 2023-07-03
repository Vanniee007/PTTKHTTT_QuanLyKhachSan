using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.BUS;

namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class PDP_DichVuDB
    {
        public static void QLPhong_ThemDV(PDP_DichVu dv)
        {
            try
            {
                string sql = "INSERT INTO PDT_DICHVU ( MADV, MAPDP, SOLUONG, THOIGIAN) VALUES('" + dv.MADV + "'," +
                           "'" + dv.MAPDP + "','" + dv.SOLUONG + "','" + SupportFunction.FormatDateSQL( dv.THOIGIAN) + "')";
                DataTable tb = DBConnect.SQL_select(sql);
            }
            catch
            {

            }

        }
        public static int QLPhong_DemDichVu()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select count(*) from PDT_DICHVU");
                return Convert.ToInt32(tb.Rows[0][0]);

            }
            catch
            {
                return -1;
            }

        }
    }
}
