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

namespace PTTKHTTT_QuanLyKhachSan.GUI
{
    /// <summary>
    /// </summary>
    public partial class LeTan_Main : Window
    {
        string username;
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

                }
            }
            catch
            { }
        }
        private void TT_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            TT_datagird.ItemsSource = HoaDon.LayDanhSachHoaDon();
        }

        private void TT_CT_datagird_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TT_tb_Them_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
