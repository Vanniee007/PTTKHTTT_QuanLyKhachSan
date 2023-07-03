using PTTKHTTT_QuanLyKhachSan.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class TourDB
    {
        public static List<Tour> DVTour_LayDSTour()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select * from Tour");
                List<Tour> ds = new List<Tour>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Tour
                    {
                        MATOUR = (int)row["MATOUR"],
                        TENTOUR = row["TENTOUR"].ToString(),
                        DIADIEM = row["DIADIEM"].ToString(),
                        GIA = (int)row["GIA"],
                        MOTACT = row["MOTACT"].ToString(),
                        MADOITAC = (int)row["MADOITAC"]


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
