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
    public class DichVuDB
    {
        public static List<DichVu> LayDSDichVu_ChiTietPDP(int MAPDP)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select * from CHITIETPHIEUDATPHONG  CT" +
                            "inner JOIN PHONG ON CT.MAPHONG = PHONG.MAPHONG " +
                            "where CT.MAPDP = " + MAPDP.ToString());
                List<DichVu> ds = new List<DichVu>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new DichVu
                    {
                        MADV = (int)row["MAPHONG"],
                        TENDV = row["LOAIPHONG"].ToString(),
                        GIA = (int)row["GIA"],
                        MOTA = row["TINHTRANG"].ToString(),
                        DIADIEM = row["HANG"].ToString(),
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

