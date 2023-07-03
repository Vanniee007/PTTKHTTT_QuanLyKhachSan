using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PTTKHTTT_QuanLyKhachSan.BUS;
namespace PTTKHTTT_QuanLyKhachSan.DB
{
    public class PhongDB
    {
        public static List<Phong> TT_LayDSPhong_ChiTietPDP(int MAPDP)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select(
                            "select CT.MAPHONG,LOAIPHONG,HANG,GIA,TINHTRANG from CHITIETPHIEUDATPHONG  CT " +
                            "inner JOIN PHONG ON CT.MAPHONG = PHONG.MAPHONG " +
                            "where CT.MAPDP = " + MAPDP.ToString());
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }
        public static List<Phong> QLPhong_LayDSPhong()
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("select * from PHONG");
                           
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }
        public static List<Phong> QLPhong_LayDSPhongKhiTim(string kitu)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("exec QLPhong_TraCuuPhong N'"+ kitu+"'"); 
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }


        public static List<Phong> PDP_LayDSPhongTrong_TheoNgay(string NgayBD, string NgayKT)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("EXEC LayDSPhongDeDat @StartDate = '"+ SupportFunction.FormatDateSQL(NgayBD) + "', @EndDate = '"+ SupportFunction.FormatDateSQL(NgayKT) +"';");
                List<Phong> ds = new List<Phong>();
                foreach (DataRow row in tb.Rows)
                {
                    ds.Add(new Phong
                    {
                        MAPHONG = (int)row["MAPHONG"],
                        LOAIPHONG = row["LOAIPHONG"].ToString(),
                        HANG = row["HANG"].ToString(),
                        GIA = (int)row["GIA"],
                        TINHTRANG = row["TINHTRANG"].ToString(),
                    });
                }
                return ds;
            }
            catch
            {
                return null;
            }

        }
        public static int QLPhong_UpdateTinhTrang(int MaPhong,string TinhTrangMoi)
        {
            try
            {
                return DBConnect.SQL_insert_update_delete("update PHONG set TINHTRANG=N'"+TinhTrangMoi+"' where MAPHONG='"+MaPhong+"'");
              
            }
            catch
            {
                
            }
            return -1; ;

        }
        //Hàm này dùng khi kiểm tra xem phòng này đã được đặt chưa
        public static int QLPhong_DemDatPhong(int MaPhong)
        {
            try
            {
                DataTable tb = DBConnect.SQL_select("SELECT count(*)  FROM CHITIETPHIEUDATPHONG CTP INNER JOIN PHIEUDATPHONG PDP ON CTP.MAPDP = PDP.MAPDP WHERE MAPHONG='" + MaPhong + "'" +
                    " and PDP.NGAYNHANPHONG<=GETDATE() AND PDP.NGAYTRAPHONG>=GETDATE()");
                return Convert.ToInt32(tb.Rows[0][0]);
            }
            catch
            {
                return -1; ;
            }
        }

    }
}

