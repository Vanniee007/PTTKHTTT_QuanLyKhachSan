using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public TaiKhoan() 
        {
            username = "";
            pass = "";
            Loai = 0;
        }
        public static bool CheckUsername(string username)
        {
            if (!InputValidation.ValidUsername(username))
            {
                return false;
            }
            return true;
        }
        public static int CheckLogin(string username, string pass)
        {


            TaiKhoan tk = TaiKhoanDB.getTaiKhoan(username);
            if (username == tk.username && pass == tk.pass && tk.Loai != 0)
            {
                return tk.Loai;
            }
            return 0;
        }

    }
}
