using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PTTKHTTT_QuanLyKhachSan.BUS
{
    public class SP_Func
    {
        public static List<string> GetSelectedIndexes(DataGrid dataGrid, int checkboxColumnIndex)
        {
            List<string> selectedValues = new List<string>();

            foreach (var item in dataGrid.Items)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(item);
                if (row != null)
                {
                    // Get the CheckBox control in the specified column of the row
                    var cellContent = dataGrid.Columns[checkboxColumnIndex].GetCellContent(row);
                    var checkBox = cellContent as CheckBox;

                    // If the CheckBox is checked, add the value of the first column to the list
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        var firstColumn = dataGrid.Columns[0].GetCellContent(row);
                        selectedValues.Add(((TextBlock)firstColumn).Text);
                    }
                }
            }
            return selectedValues;
        }
    }
}
