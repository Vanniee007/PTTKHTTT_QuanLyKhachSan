using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;

namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class PhieuDangKyTour
    {
        public int MAPDKTOUR { get; set; }
        public string THGIANKHOIHANH { get; set; }
        public int SONGUOITHGIA { get; set; }
        public string DICHVUDUADON { get; set; }
        public string YEUCAUDACBIET { get; set; }
        public int MAKH { get; set; }
        public int MATOUR { get; set; }
        public static List<PhieuDangKyTour> DVTour_LayDSpdkTour()
        {
            return PhieuDangKyTourDB.DVTour_LayDSPhieuDangKy();
        }
        public static bool DVTour_ThemPDKTour(PhieuDangKyTour pdk)
        {
            try
            {
                int demTruoc = PhieuDangKyTourDB.DVTour_DemSoPDK();
                PhieuDangKyTourDB.DVTour_ThemPhieuDangKy(pdk);
                int demSau = PhieuDangKyTourDB.DVTour_DemSoPDK();
                if (demTruoc == demSau - 1)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public static bool DVTour_KiemTraPDKTour(PhieuDangKyTour p)
        {
            return true;
        }
    }
}
