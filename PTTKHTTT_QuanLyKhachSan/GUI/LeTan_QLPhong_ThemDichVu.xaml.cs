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
        public int MaPDP_=-1;
        public int MaDV_=-1;
        public LeTan_QLPhong_ThemDichVu(int MaPDP_v)
        {
            MaPDP_ = MaPDP_v;
            InitializeComponent();
        }

        public void DVDat_HienThi()
        {
            try
            {
                DVDat_datagird.ItemsSource = DichVu.TT_LayDSDichVu_PDP(MaPDP_);
            }
            catch
            {

            }

        }
        private void DVDat_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            DVDat_HienThi();
        }
        public void DV_HienThi()
        {
            try
            {
                lb_title.Content = "Dịch vụ của PDP: " + MaPDP_.ToString();
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
                    MaDV_ = row.MADV;
                    
                    DV_tb_tendv.Text = row.TENDV;

                }
            }
            catch
            { }
        }

        private void DV_bt_dat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Chưa chọn dịch vụ
                if ((DV_tb_tendv.Text).Length == 0)
                {
                    SupportFunction.ShowError(lb_error, "Bạn chưa chọn dịch vụ");
                    return;
                }
                else
                {
                    //Số lượng không hợp lệ
                    if (!InputValidation.ValidNumberic(DV_tb_soluong.Text))
                    {
                        SupportFunction.ShowError(lb_error, "Số lượng bạn nhập không hợp lệ");
                        return;
                    }
                        PDP_DichVu dv = new PDP_DichVu
                    {
                        MADV = MaDV_,
                        MAPDP = MaPDP_,
                        SOLUONG = int.Parse(DV_tb_soluong.Text),
                        THOIGIAN = DV_tb_thoigian.Text,
                    };
                    if (PDP_DichVu.QLPhong_DatDV(dv) == true)
                    {
                        SupportFunction.ShowSuccess(lb_error, "Đặt thành công");
                        DVDat_HienThi();
                    }
                    else
                    {
                        SupportFunction.ShowError(lb_error, "Đặt thất bại");
                    }
                }
            }
            catch
            {

            }
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
