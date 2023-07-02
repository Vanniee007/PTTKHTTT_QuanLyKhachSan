using PTTKHTTT_QuanLyKhachSan.BUS;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for LeTan_ThemPhieuDatPhong.xaml
    /// </summary>
    public partial class LeTan_ThemPhieuDatPhong : Window
    {
        public LeTan_ThemPhieuDatPhong()
        {
            InitializeComponent();
        }

        private void DP_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            Phong_HienThi();
        }
        private void Phong_HienThi()
        {
            DP_datagird_Phong.ItemsSource = Phong.PDP_DSPhong_TheoNgay(SupportFunction.FormatShortDate(tb_NgayNhan.Text), SupportFunction.FormatShortDate(tb_NgayTra.Text));
        }

        private void TimKiemPhong_Click(object sender, RoutedEventArgs e)
        {
            Phong_HienThi();
        }
    }
}
