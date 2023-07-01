using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using PTTKHTTT_QuanLyKhachSan.BUS;

namespace PTTKHTTT_QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for LoginWindows.xaml
    /// </summary>       
    public partial class Login_Window : Window
    {
        public Login_Window(string username)
        {
            InitializeComponent();
            tb_username.Text = username;
            tb_username.Focus();
        }

        //animation cửa số đăng nhập
        private void tb_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_username.Text) && tb_username.Text.Length > 0)
            {
                lb_username.Visibility = Visibility.Collapsed;
            }
            else
            {
                lb_username.Visibility = Visibility.Visible;
            }
        }
        private void Login()
        {
            int CuaSo = TaiKhoan.CheckLogin(tb_username.Text,tb_password.Password);
            if (CuaSo == 1)
            {
                //Cửa sổ admin
            }
            else if (CuaSo == 2)
            {
                //Cửa sổ nhân viên
            }
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void DangNhap_Click(object sender, RoutedEventArgs e)
        {
            Login();

        }

        private void tb_password_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_password.Password) && tb_password.Password.Length > 0)
            {
                lb_password.Visibility = Visibility.Collapsed;
            }
            else
            {
                lb_password.Visibility = Visibility.Visible;
            }
        }

        private void bt_mini_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void bt_close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
