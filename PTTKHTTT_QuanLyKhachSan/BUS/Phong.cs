using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
     public class Phong
    {
        public int MAPHONG { get; set; }
        public string LOAIPHONG { get; set; }
        public string HANG { get; set; }
        public int GIA { get; set; }
        public string TINHTRANG { get; set; }
        public static List<Phong> QLPhong_LayDSPhong()
        {
            return PhongDB.QLPhong_LayDSPhong();
        }
        public static List<Phong> QLPhong_TimPhong(string kitu)
        {
            return PhongDB.QLPhong_LayDSPhongKhiTim(kitu);
        }
        public static int QLPhong_UpdateTinhTrangPhong(int MaPhong,string TinhTrangCu, string TinhTrangMoi)
        {
            try
            {
                if (TinhTrangCu != TinhTrangMoi)
                {
                    if (TinhTrangCu == "Chưa dọn" && TinhTrangMoi == "Đang dùng")
                    {
                        return -3;//thông báo: không được, chỉ được sử dụng phòng khi đã dọn
                    }
                    else if (TinhTrangCu == "Trống" && TinhTrangMoi == "Đang dùng")
                    {
                        //Phòng này đã được đặt trong lịch thì mới update
                        if (PhongDB.QLPhong_DemDatPhong(MaPhong) == 1)
                        {
                            return PhongDB.QLPhong_UpdateTinhTrang(MaPhong, TinhTrangMoi);//phong da duoc dat
                        }
                        else
                        {
                            return -2;//phong chua duoc dat
                        }
                    }
                    else if (TinhTrangCu == "Đang dùng" && (TinhTrangMoi == "Trống" || TinhTrangMoi == "Chưa dọn"))
                    {
                        return 0;//thông báo: phòng chưa được thanh toán
                    }
                    return PhongDB.QLPhong_UpdateTinhTrang(MaPhong, TinhTrangMoi);
                }
                return -4;//thông báo: 2 tình trạng update giống tình trạng cũ

            }
            catch {
                return -1;
            }
        }
    }
}
