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
    public class DichVuDB
    {
        public static List<DichVu> LayDSDichVu_ChiTietPDP(int MAPDP)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select * from DICHVU dv inner JOIN PDT_DICHVU p ON dv.MADV = p.MADV where p.MAPDP = " + MAPDP.ToString());
                List<DichVu> ds = new List<DichVu>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new DichVu
                    {
                        MADV = (int)row["MADV"],
                        TENDV = row["TENDV"].ToString(),
                        GIA = (int)row["GIA"],
                        MOTA = row["MOTA"].ToString(),
                        DIADIEM = row["DIADIEM"].ToString(),
                        SOLUONG = (int)row["SOLUONG"],
                        THOIGIAN = SupportFunction.FormatShortDate(row["THOIGIAN"].ToString()),
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

