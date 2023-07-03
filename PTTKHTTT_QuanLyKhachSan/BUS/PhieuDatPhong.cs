using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
     public class PhieuDatPhong
    {
        public int MAPDP { get; set; }
        public string NGAYLAP { get; set; }
        public string NGAYNHANPHONG { get; set; }
        public string NGAYTRAPHONG { get; set; }
        public int MAKH { get; set; }
        public int MANV { get; set; }
        public PhieuDatPhong() 
        {
        }
        public static List <PhieuDatPhong> LayDanhSachPDP()
        {
            return PhieuDatPhongDB.LayDanhSachTatCa();
        }
        public static List<PhieuDatPhong> QLPhong_xempdp_LayDanhSachPDP(int MaPhong)
        {
            return PhieuDatPhongDB.QLPhong_xempdp_LayDSPDP(MaPhong);
        }

    }
}
