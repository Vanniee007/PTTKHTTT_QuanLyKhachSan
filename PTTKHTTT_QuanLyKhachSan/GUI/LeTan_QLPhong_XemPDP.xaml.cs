using PTTKHTTT_QuanLyKhachSan.BUS;
using System;
using System.Collections.Generic;
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

namespace PTTKHTTT_QuanLyKhachSan.GUI
{
    /// <summary>
    /// Interaction logic for LeTan_QLPhong_XemPDP.xaml
    /// </summary>
    public partial class LeTan_QLPhong_XemPDP : Window
    {
        public int MaPhong;
        public LeTan_QLPhong_XemPDP(int MaPhong_)
        {
            MaPhong = MaPhong_;
            InitializeComponent();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        public void QLPhong_xempdp_HienThi()
        {
            try
            {
                lb_title.Content = "Bảng phiếu đặt phòng: " + MaPhong.ToString();
                QLPhong_xempdp_datagird.ItemsSource = PhieuDatPhong.QLPhong_xempdp_LayDanhSachPDP(MaPhong);
            }
            catch { }
        }
        private void QLPhong_xempdp_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            QLPhong_xempdp_HienThi();
        }
    }
}
