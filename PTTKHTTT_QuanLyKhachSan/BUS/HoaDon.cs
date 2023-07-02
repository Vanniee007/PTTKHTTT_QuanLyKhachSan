using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class HoaDon
    {
        public int MAHD { get; set; }
        public string NGAYLAP { get; set; }
        public int MAPDP { get; set; }
        public int TONGTIEN { get; set; }
        public string TINHTRANGTT { get; set; }
        public int MANV { get; set; }

        public HoaDon()
        {
        }
        public static List<HoaDon> LayDanhSachHoaDon()
        {
            return HoaDonDB.LayDanhSachTatCa();
        }

    }
}
