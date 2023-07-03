using PTTKHTTT_QuanLyKhachSan.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using System.Windows.Shapes;
using PTTKHTTT_QuanLyKhachSan.BUS;
using System.Security.Claims;

namespace PTTKHTTT_QuanLyKhachSan.GUI
{
    /// <summary>
    /// </summary>
    public partial class LeTan_Main : Window
    {
        string username;
        public int MaNV = 1;
        public LeTan_Main(string username_)
        {
            InitializeComponent();
            username = username_;
        }
        private void Btn_dangxuat_Click(object sender, RoutedEventArgs e)
        {
            Login_Window lg = new Login_Window(username);
            this.Close();
            lg.Show();

        }
        private void bt_mini_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bt_max_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void bt_close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /*=============================================TABITEM: THONG TIN ============================================
         * =========================================================================================================*/
        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void DP_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            DP_HienThi();
        }
        private void DP_HienThi()
        {

            DP_datagird.ItemsSource = PhieuDatPhong.LayDanhSachPDP();
        }

        private void DP_tb_Them_Click(object sender, RoutedEventArgs e)
        {
            LeTan_ThemPhieuDatPhong pdp = new LeTan_ThemPhieuDatPhong();
            pdp.ShowDialog();
            DP_HienThi();

        }

        private void lb_information_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }


        /*=================================================TABITEM: QUẢN LÝ PHÒNG =================================================
         ==================================================================================================
        ==================================================================================================
        ==================================================================================================*/
        private void Tk_tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Tk_tb_search.Text) && Tk_tb_search.Text.Length > 0)
            {
                Tk_lb_search.Visibility = Visibility.Collapsed;
            }
            else
            {
                Tk_lb_search.Visibility = Visibility.Visible;
            }
            // Kiểm tra xem phím Enter có được nhấn hay không
          
        }
        private void QLPhong_HienThi()
        {
            try
            {
                QLPhong_datagird.ItemsSource = Phong.QLPhong_LayDSPhong();
            }
            catch { }
        }
        private void QLPhong_datagird_Loaded(object sender, RoutedEventArgs e)
        {

            QLPhong_HienThi();
        }

        private void DA_bt_capnhat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QLPhong_datagird.SelectedIndex.ToString() != null)
                {
                    Phong row = (Phong)QLPhong_datagird.SelectedItem;
                    if (row != null)
                    {
                        int kq = Phong.QLPhong_UpdateTinhTrangPhong(Convert.ToInt32(row.MAPHONG), QLPhong_tb_tthientai.Text, QLPhong_cb_tinhtrangmoi.Text);
                        switch (kq)
                        {
                            case 1:
                                SupportFunction.ShowSuccess(lb_error, "Đổi trạng thái thành công");
                                QLPhong_HienThi();
                                QLPhong_tb_tthientai.Text = QLPhong_cb_tinhtrangmoi.Text;
                                if(QLPhong_tb_tthientai.Text=="Đang dùng")
                                {
                                    KhachHang kh = KhachHang.QLPhong_LayThongTinKhach_PDP(row.MAPHONG);
                                    QLPhong_tb_tenkhach.Text = kh.HOTEN;
                                    QLPhong_tb_cccd.Text = kh.CCCD;
                                }
                                break;
                            case 0:
                                SupportFunction.ShowError(lb_error, "Phòng chưa được thanh toán");
                                break;
                            case -1:
                                SupportFunction.ShowError(lb_error, "Đổi trạng thái thất bại");
                                break;
                            case -2:
                                SupportFunction.ShowError(lb_error, "Hiện tại phòng chưa được đặt");
                                break;
                            case -3:
                                SupportFunction.ShowError(lb_error, "Không được, chỉ được sử dụng phòng khi đã dọn");
                                break;
                            case -4:
                                SupportFunction.ShowError(lb_error, "Tình trạng cũ giống tình trạng mới");
                                break;
                            
                            default:
                                // Xử lý khi kq không rơi vào bất kỳ trường hợp nào trên
                                break;
                        }
                    }
                    else
                    {
                        SupportFunction.ShowError(lb_error, "Vui lòng chọn phòng bạn muốn cập nhật.");
                    }
                }
             
           
            }
            catch
            {

            }
            
        }

        private void Da_bt_lichdat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QLPhong_datagird.SelectedIndex.ToString() != null)
                {
                    Phong row = (Phong)QLPhong_datagird.SelectedItem;
                    if (row != null)
                    {

                        LeTan_QLPhong_XemPDP qlp = new LeTan_QLPhong_XemPDP(row.MAPHONG);
                        qlp.ShowDialog();
                    }
                    else
                    {
                        SupportFunction.ShowError(lb_error, "Vui lòng chọn phòng bạn muốn xem lịch.");
                    }
                }
              

            }
            catch
            {

            }
        }

        private void DA_bt_dichvu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QLPhong_datagird.SelectedIndex.ToString() != null)
                {
                    Phong row = (Phong)QLPhong_datagird.SelectedItem;
                    if (row != null)
                    {

                        LeTan_QLPhong_ThemDichVu tdv = new LeTan_QLPhong_ThemDichVu(row.MAPHONG);
                        tdv.ShowDialog();
                    }
                    else
                    {
                        SupportFunction.ShowError(lb_error, "Vui lòng chọn phòng bạn muốn đặt dịch vụ.");
                    }
                }


            }
            catch
            {

            }
        }

        private void TT_datagird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (TT_datagird.SelectedItem != null)
                {
                    HoaDon row = (HoaDon)TT_datagird.SelectedItem;
                    TT_CTPDP_datagird.ItemsSource = Phong.LayDSPhong(row.MAPDP);
                    TT_DVP_datagird.ItemsSource = DichVu.TT_LayDSDichVu_PDP(row.MAPDP);
                    KhachHang kh = KhachHang.TT_LayThongTinKhach_PDP(row.MAPDP);
                    TT_tb_hoten.Text = kh.HOTEN;
                    TT_tb_cccd.Text = kh.CCCD;
                    TT_tb_sdt.Text = kh.SDT;
                    TT_tb_MaHD.Text = row.MAHD.ToString();
                    TT_lb_tongtien.Text = HoaDon.LayTongTien(row.MAHD.ToString());
                }
            }
            catch
            { }
        }
        private void TT_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            TT_HienThi();
        }
        private void TT_HienThi()
        {
            TT_datagird.ItemsSource = HoaDon.LayDanhSachHoaDon();
        }

        private void TT_CT_datagird_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Tk_tb_search_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    QLPhong_datagird.ItemsSource = Phong.QLPhong_TimPhong(Tk_tb_search.Text);
                }
            }
            catch { }
            
        }

        private void QLPhong_datagird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (QLPhong_datagird.SelectedIndex.ToString() != null)
                {
                    Phong row = (Phong)QLPhong_datagird.SelectedItem;
                    if (row != null)
                    {
                        QLPhong_tb_tthientai.Text = row.TINHTRANG;
                        QLPhong_label.Content = "Phòng: " + row.MAPHONG;
                        if(row.TINHTRANG=="Đang dùng")
                        {
                            
                            KhachHang kh = KhachHang.QLPhong_LayThongTinKhach_PDP(row.MAPHONG);
                            QLPhong_tb_tenkhach.Text = kh.HOTEN;
                            QLPhong_tb_cccd.Text = kh.CCCD;



                        }
                        else
                        {
                            QLPhong_tb_tenkhach.Text = "";
                            QLPhong_tb_cccd.Text = "";
                        }
                    }
                }
            }
            catch
            { }
        }
        private void TT_tb_Them_Click(object sender, RoutedEventArgs e)
        {
        }

        private void TT_tb_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HoaDon.TT_ThanhToanHoaDon(TT_tb_MaHD.Text))
                {
                    SupportFunction.ShowSuccess(lb_error,"Thanh toán hoá đơn thành công"); 
                    TT_datagird.ItemsSource = HoaDon.LayDanhSachHoaDon();
                }
                else {
                    SupportFunction.ShowError(lb_error, "Thanh toán hoá đơn thất bại");
                }

            }
            catch { }
        }
        /*=================================================TABITEM: DỊCH VỤ TOUR =================================================
        ==================================================================================================
       ==================================================================================================
       ==================================================================================================*/
        private void Tour_bt_dangky_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
               
                PhieuDangKyTour pdk = new PhieuDangKyTour
                {
                    MAPDKTOUR = -1,
                    THGIANKHOIHANH = Tour_tb_ngaykhoihanh.Text,
                    SONGUOITHGIA = int.Parse(Tour_tb_songuoi.Text),
                    DICHVUDUADON = Tour_cb_duadon.Text,
                    YEUCAUDACBIET = Tour_tb_yeucau.Text,
                    MAKH = int.Parse(Tour_cb_makh.Text),
                    MATOUR = int.Parse(Tour_cb_matour.Text)
                };
                if (PhieuDangKyTour.DVTour_ThemPDKTour(pdk) == true)
                {
                    SupportFunction.ShowSuccess(lb_error, "Thêm thành công");
                    DVTour_HienThi();
                }
                else
                {
                    SupportFunction.ShowError(lb_error, "Thêm thất bại");
                }
            }
            catch
            {

            }
        }
       
        
        public void DVTour_HienThi()
        {
            Tour_datagird.ItemsSource = PhieuDangKyTour.DVTour_LayDSpdkTour();
            Tour_cb_matour.DataContext = Tour.DVTour_LayDSMaTour();
            Tour_cb_makh.DataContext = KhachHang.DVTour_LayDSMaKhachHang();
        }
        private void Tour_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            DVTour_HienThi();
        }
    }
}
