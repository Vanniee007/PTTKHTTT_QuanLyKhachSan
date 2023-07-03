﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class KhachHang
    {
        public int MAKH { get; set; }
        public string HOTEN { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public int FAXID { get; set; }
        public string EMAIL { get; set; }
        public KhachHang()
        {
            MAKH = -1;
            HOTEN = "";
            CCCD = "";
            SDT = "";
            DIACHI = "";
            FAXID = -1;
            EMAIL = "";
        }
        public static KhachHang TT_LayThongTinKhach_PDP(int MAPDP)
        {
            return KhachHangDB.TT_LayThongTinKhach(MAPDP);
        }
        public static KhachHang QLPhong_LayThongTinKhach_PDP(int MaPhong)
        {
            return KhachHangDB.TT_LayThongTinKhach(PhieuDatPhongDB.QLPhong_LayMaPDP(MaPhong));
        }
     
        public static List<int> DVTour_LayDSMaKhachHang()
        {
            List<KhachHang> t = KhachHangDB.DVTour_LayDSKhachHang();
            var ds = new List<int>();
            for (int i = 0; i < t.Count(); i++)
            {
                ds.Add(t[i].MAKH);
            }
            return ds;
        }

    }
}
