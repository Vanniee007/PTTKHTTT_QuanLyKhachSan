using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public static List<PhieuDatPhong> LayDanhSachPDP()
        {
            return PhieuDatPhongDB.LayDanhSachTatCa();
        }
        public static bool PDP_KiemTraThongTinPhieu(PhieuDatPhong phieu)
        {

            if (!InputValidation.ValidDate(phieu.NGAYNHANPHONG) || !InputValidation.ValidDate(phieu.NGAYTRAPHONG))
            {
                return false;
            }
            string format = "dd/MM/yyyy";
            DateTime NgayBD, NgayKT;
            // Sử dụng phương thức ParseExact
            NgayBD = DateTime.ParseExact(phieu.NGAYNHANPHONG, format, CultureInfo.InvariantCulture);
            NgayKT = DateTime.ParseExact(phieu.NGAYTRAPHONG, format, CultureInfo.InvariantCulture);
            if (NgayKT< NgayBD)
            {
                return false;
            }
            return true;
        }

        public static int PDP_ThemPhieuDatPhong(KhachHang khach, PhieuDatPhong phieu, DataGrid dataGrid)
        {
            try
            {
                if (SP_Func.GetSelectedIndexes(dataGrid, 5).Count == 0)
                {
                    return -2;
                }
                //Thêm khách hàng
                int MaKH = KhachHang.PDP_ThemKhach(khach);
                if (MaKH == -1)
                    return -1;
                //Thêm phiếu đặt phòng
                phieu.MAKH = MaKH;
                int maphieu = PhieuDatPhongDB.PDP_ThemPhieuDatPhong(phieu);
                if (maphieu == -1)
                    return -1;
                //Thêm chi tiết phiếu đặt phòng
                ChiTietPhieuDatPhong.PDP_ThemChiTietPhieuDatPhong(dataGrid, maphieu);
                //Thêm hoá đơn
                HoaDon.ThemHoaDon(maphieu);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        public static List<PhieuDatPhong> QLPhong_xempdp_LayDanhSachPDP(int MaPhong)
        {
            return PhieuDatPhongDB.QLPhong_xempdp_LayDSPDP(MaPhong);
        }
        public static int QLPhong_LayMaPDP(int MaPhong)
        {
            return PhieuDatPhongDB.QLPhong_LayMaPDP(MaPhong);
        }

    }
}
