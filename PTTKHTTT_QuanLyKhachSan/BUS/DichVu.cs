using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
     public class DichVu
    {
        public int MADV { get; set; }
        public string TENDV { get; set; }
        public int GIA { get; set; }
        public string MOTA { get; set; }
        public string DIADIEM{ get; set; }
        public int SOLUONG { get; set; }
        public string THOIGIAN{ get; set; }
        public static List<DichVu> TT_LayDSDichVu_PDP(int MaPDP)
        {
            return DichVuDB.LayDSDichVu_ChiTietPDP(MaPDP);
        }
        public static List<DichVu> QLPhong_tdv_LayDSDichVu()
        {
            return DichVuDB.QLPhong_tdv_LayDSDV();
        }
    }
}
