using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.BUS;

namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class PhieuDangKyTourDB
    {
        public static List<PhieuDangKyTour> DVTour_LayDSPhieuDangKy()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select * from PhieuDangKyTour");
                List<PhieuDangKyTour> ds = new List<PhieuDangKyTour>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new PhieuDangKyTour
                    {
                         
        
                        MAPDKTOUR =(int) row["MAPDKTOUR"],
                        THGIANKHOIHANH = SupportFunction.FormatShortDate(row["THGIANKHOIHANH"].ToString()),
                        SONGUOITHGIA = (int)row["SONGUOITHGIA"],
                        DICHVUDUADON = row["DICHVUDUADON"].ToString(),
                        YEUCAUDACBIET = row["YEUCAUDACBIET"].ToString(),
                        MAKH = (int)row["MAKH"],
                        MATOUR = (int)row["MATOUR"],


                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }
        public static void DVTour_ThemPhieuDangKy(PhieuDangKyTour pdk)
        {
            try
            {

                string sql = "INSERT INTO PHIEUDANGKYTOUR ( THGIANKHOIHANH, SONGUOITHGIA, DICHVUDUADON, YEUCAUDACBIET, MAKH, MATOUR) VALUES('" + SupportFunction.FormatDateSQL(pdk.THGIANKHOIHANH) + "'," +
                            "'" + pdk.SONGUOITHGIA + "',N'" + pdk.DICHVUDUADON + "',N'" + pdk.YEUCAUDACBIET + "','" + pdk.MAKH + "','" + pdk.MATOUR + "')";
                DataTable tb = DBConnect.SQL_select(sql);
                           
               
            }
            catch
            {
                
            }

        }
        public static int DVTour_DemSoPDK()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select count(*) from PHIEUDANGKYTOUR");
                return Convert.ToInt32(tb.Rows[0][0]);

            }
            catch
            {
                return -1;
            }

        }
       
    }
}
