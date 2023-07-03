using PTTKHTTT_QuanLyKhachSan.BUS;
using PTTKHTTT_QuanLyKhachSan.DB;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PTTKHTTT_QuanLyKhachSan.GUI
{
    /// <summary>
    /// Interaction logic for LeTan_ThemPhieuDatPhong.xaml
    /// </summary>
    public partial class LeTan_ThemPhieuDatPhong : Window
    {
        int MaNhanVien = 1;
        public LeTan_ThemPhieuDatPhong()
        {
            InitializeComponent();
        }

        private void DataGridRow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var dataGridRow = sender as DataGridRow;
            var checkBox = FindVisualChild<CheckBox>(dataGridRow);

            if (checkBox != null)
            {
                checkBox.IsChecked = !checkBox.IsChecked;
                e.Handled = true;
            }
        }
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindVisualChild<T>(child);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        private void DP_datagird_Loaded(object sender, RoutedEventArgs e)
        {
            Phong_HienThi();
        }
        private void Phong_HienThi()
        {
            DP_datagird_Phong.ItemsSource = Phong.PDP_DSPhong_TheoNgay(SupportFunction.FormatShortDate(tb_NgayNhan.Text), SupportFunction.FormatShortDate(tb_NgayTra.Text));
            tb_NgayNhan.Text = DateTime.Now.ToString();
            tb_NgayTra.Text = DateTime.Now.AddDays(1).ToString();
        }

        private void TimKiemPhong_Click(object sender, RoutedEventArgs e)
        {
            Phong_HienThi();
        }

        private void Button_DatPhong_Click(object sender, RoutedEventArgs e)
        {
            KhachHang k = new KhachHang { };
            KhachHang kh = new KhachHang { MAKH = -1, HOTEN = tb_hoten.Text, CCCD = tb_cccd.Text, SDT = tb_sdt.Text, EMAIL = tb_email.Text, DIACHI = tb_diachi.Text, FAXID =tb_faxid.Text };
            if (!KhachHang.PDP_KiemTraThongTinKhach(kh))
            {
                SupportFunction.ShowError(lb_error, "Thông tin khách hàng không hợp lệ"); return;
            }
            PhieuDatPhong phieu = new PhieuDatPhong { NGAYNHANPHONG = tb_NgayNhan.Text, NGAYTRAPHONG = tb_NgayTra.Text, MANV = MaNhanVien };

            if (!PhieuDatPhong.PDP_KiemTraThongTinPhieu(phieu))
            {
                SupportFunction.ShowError(lb_error, "Thời gian đặt không hợp lệ"); return;
            }
            int MaLoi = PhieuDatPhong.PDP_ThemPhieuDatPhong(kh, phieu, DP_datagird_Phong);
            switch (MaLoi)
            {
                case 1:
                    SupportFunction.ShowError(lb_error, "Thêm thành công"); break;
                case -2:
                    SupportFunction.ShowError(lb_error, "Chọn tối thiểu 1 phòng"); break;
            }
        }

        private void bt_TimKiemKH_Click(object sender, RoutedEventArgs e)
        {
            HienThiThongTinKH(tb_thongtin_KH.Text);
        }
        private void HienThiThongTinKH(string keysearch)
        {
            KhachHang kh = KhachHang.PDP_LayThongTinKhach(keysearch);
            if (kh != null)
            {
                tb_hoten.Text = kh.HOTEN;
                tb_cccd.Text = kh.CCCD;
                tb_sdt.Text = kh.SDT;
                tb_email.Text = kh.EMAIL;
                tb_diachi.Text = kh.DIACHI;
                tb_faxid.Text = kh.FAXID.ToString();
            }
            else
            {
                tb_hoten.Text = "";
                tb_cccd.Text = "";
                tb_sdt.Text = "";
                tb_email.Text = "";
                tb_diachi.Text = "";
                tb_faxid.Text = "";
            }
        }
    }
}
