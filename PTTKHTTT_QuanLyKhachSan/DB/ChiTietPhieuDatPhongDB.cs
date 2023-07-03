using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class ChiTietPhieuDatPhongDB
    {
        public static void ThemCTPDP(ChiTietPhieuDatPhong ct)
        {
            try
            {
                DBConnect.SQL_SelectOneRow("INSERT INTO CHITIETPHIEUDATPHONG (MAPDP, MAPHONG) VALUES (" + ct.MAPDP.ToString() + "," + ct.MAPHONG.ToString() + ");");
            }
            catch
            { }
        }
    }
}

