using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
     public class ChiTietPhieuDatPhong
    {
        public int MAPDP { get; set; }
        public int MAPHONG { get; set; }

        public static void PDP_ThemChiTietPhieuDatPhong(DataGrid data, int MaPDP)
        {
            List<string> list = SP_Func.GetSelectedIndexes(data, 5);
            foreach (var maphong in list)
            {
                ChiTietPhieuDatPhongDB.ThemCTPDP(new ChiTietPhieuDatPhong { MAPDP = MaPDP, MAPHONG = int.Parse(maphong) });
            }
        }

    }

}
