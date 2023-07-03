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
    /// Interaction logic for LeTan_QLPhong_ThemDichVu.xaml
    /// </summary>
    /// 
    public partial class LeTan_QLPhong_ThemDichVu : Window
    {
        public int MaPhong;
        public LeTan_QLPhong_ThemDichVu(int MaPhong_)
        {
            MaPhong = MaPhong_;
            InitializeComponent();
        }

        public void DVDat_HienThi()
        {
            try
            {
              
            }
            catch
            {

            }

        }
        private void DVDat_datagird_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void DV_HienThi()
        {
            try
            {
                lb_title.Content = "Dịch vụ phòng: " + MaPhong.ToString();
                DV_datagird.ItemsSource = DichVu.QLPhong_tdv_LayDSDichVu();
            }
            catch
            {

            }

        }
        private void DV_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            DV_HienThi();
        }

        private void DV_datagird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DV_datagird.SelectedItem != null)
                {
                    DichVu row = (DichVu)DV_datagird.SelectedItem;

                    
                    DV_tb_tendv.Text = row.TENDV;

                }
            }
            catch
            { }
        }

        private void DV_bt_dat_Click(object sender, RoutedEventArgs e)
        {

        }
      
        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

       
    }
}
