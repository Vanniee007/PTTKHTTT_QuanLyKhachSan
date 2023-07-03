using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PTTKHTTT_QuanLyKhachSan
{
    internal class SupportFunction
    {
        public static void ShowError(System.Windows.Controls.Label label, string content)
        {
            label.Content = content;
            label.Foreground = Brushes.IndianRed;
            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(t =>
            {
                label.Content = string.Empty;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static void ShowSuccess(System.Windows.Controls.Label label, string content)
        {
            label.Content = content;
            label.Foreground = Brushes.Green;
            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(t =>
            {
                label.Content = string.Empty;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public static async Task HideLabelAfterDelay(System.Windows.Controls.Label label, int second)
        {
            await Task.Delay(TimeSpan.FromSeconds(second));
            label.Content = "";
        }
        public static string FormatShortDate(string dateTimeString)
        {
            try
            {
                DateTime dateTime;
                dateTime = DateTime.Parse(dateTimeString);
                if (DateTime.TryParse(dateTimeString, out dateTime))
                {
                    string dateString = dateTime.ToString("dd/MM/yyyy");
                    return dateString;
                }
                return dateTimeString;
            }
            catch
            {
                return "";
            }
            
        }

        public static string str(string str)
        {
            if (str == null)
                return "";
            return str;

        }

        public static string FormatDateSQL(string dateTimeString)
        {
            try
            {
                DateTime dateTime;
                dateTime = DateTime.Parse(dateTimeString);
                if (DateTime.TryParse(dateTimeString, out dateTime))
                {
                    string dateString = dateTime.ToString("yyyy-MM-dd");
                    return dateString;
                }
                return dateTimeString;
            }
            catch
            {
                return "";
            }

        }
    }
}
