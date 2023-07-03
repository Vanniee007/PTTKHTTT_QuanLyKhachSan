using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;

namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class PDP_DichVu
    {
        public int MADV { get; set; }
        public int MAPDP { get; set; }
        
        public int SOLUONG { get; set; }
        public string THOIGIAN { get; set; }
        public static bool QLPhong_DatDV(PDP_DichVu dv)
        {
            try
            {
                int demTruoc = PDP_DichVuDB.QLPhong_DemDichVu();
                PDP_DichVuDB.QLPhong_ThemDV(dv);
                int demSau = PDP_DichVuDB.QLPhong_DemDichVu();
                if (demTruoc == demSau - 1)
                {
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }

}
