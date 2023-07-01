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
            HienThi();
        }
        private void HienThi()
        {

            DP_datagird.ItemsSource = PhieuDatPhong.LayDanhSachPDP();
        }

        private void DP_tb_Them_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lb_information_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
