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
    /// Interaction logic for LeTan_DVTour_XemTour_DoiTac.xaml
    /// </summary>
    public partial class LeTan_DVTour_XemTour_DoiTac : Window
    {
        public LeTan_DVTour_XemTour_DoiTac()
        {
            InitializeComponent();
        }

        private void DVTour_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            DVTour_datagird.ItemsSource = Tour.DVTour_LayDSTour();
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
