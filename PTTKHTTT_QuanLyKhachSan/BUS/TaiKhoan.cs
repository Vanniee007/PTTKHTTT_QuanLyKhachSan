using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTTKHTTT_QuanLyKhachSan.DB;
namespace PTTKHTTT_QuanLyKhachSan.BUS
{
     public class TaiKhoan
    {
        public string username { get; set; }
        public string pass { get; set; }
        public int Loai { get; set; }

        public static int CheckLogin(string username, string pass)
        {
            TaiKhoan tk = TaiKhoanDB.getTaiKhoan("admin");
            if (username == tk.username && pass == tk.pass)
            {
                return tk.Loai;
            }
            return 0;
        }

    }
}
