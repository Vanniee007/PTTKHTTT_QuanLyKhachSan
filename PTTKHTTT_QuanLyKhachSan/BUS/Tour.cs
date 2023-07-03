using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;

namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class Tour
    {
        public int MATOUR { get; set; }
        public string TENTOUR { get; set; }
        public string DIADIEM { get; set; }
        public int GIA { get; set; }
        public string MOTACT { get; set; }
        public int MADOITAC { get; set; }
        public static List<int> DVTour_LayDSMaTour()
        {
            List<Tour> t = TourDB.DVTour_LayDSTour();
            var ds = new List<int>();
            for (int i = 0; i < t.Count(); i++)
            {
                ds.Add(t[i].MATOUR);
            }
            return ds;
        }
    }
}
