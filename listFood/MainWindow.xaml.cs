using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;
<<<<<<< Updated upstream
using OpenQA.Selenium.Remote;
using System.Data.OleDb;
using System.Collections.ObjectModel;
using Aspose.Cells;
using System.Diagnostics;
=======
using System.Collections.ObjectModel;
>>>>>>> Stashed changes

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public class Food
        {
            public string _nameOfFood { get; set; }
            public string _howToFood { get; set; }
            public int _rating { get; set; }
            public string _cover { get; set; }
            public string _material { get; set; }
        }
      
        public Home()
        {
            InitializeComponent();
        }
<<<<<<< Updated upstream

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// new code



        Workbook wb;
        Worksheet sheet;
        Food food;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

=======
        ObservableCollection<Food> listFood = new ObservableCollection<Food>();
        string dataFile = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder = folder.Remove(folder.IndexOf("bin"));
            dataFile = $"{folder}Data\\dataOfFood.txt";

            // Nạp danh sách món ăn đang có từ tập tin
            var items = File.ReadAllLines(dataFile).ToList();
            foreach(string item in items)
            {
                string[] entries = item.Split('~');
                Food newFood = new Food();
                newFood._nameOfFood = entries[0];
                newFood._howToFood = entries[1];
                newFood._cover = entries[2];
                newFood._rating = int.Parse(entries[3]);
                newFood._material = entries[4];
                listFood.Add(newFood);
            }
            ListBox_Food.ItemsSource = listFood;
        }
        private void Button_Out(object sender, RoutedEventArgs e)
        {
        }
>>>>>>> Stashed changes

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = true;

            string fileName = "C:\\sampleExcelFile.xlsx";

            //open the workbook
            Workbook workbook = _excelApp.Workbooks.Open(fileName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            //select the first sheet        
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            //find the used range in worksheet
            Range excelRange = worksheet.UsedRange;

            //get an object array of all of the cells in the worksheet (their values)
            object[,] valueArray = (object[,])excelRange.get_Value(
                        XlRangeValueDataType.xlRangeValueDefault);

            //access the cells
            for (int row = 1; row <= worksheet.UsedRange.Rows.Count; ++row)
            {
                for (int col = 1; col <= worksheet.UsedRange.Columns.Count; ++col)
                {
                    //access each cell
                    Debug.Print(valueArray[row, col].ToString());
                }
            }

            //clean up stuffs
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.ReleaseComObject(workbook);

            _excelApp.Quit();
            Marshal.FinalReleaseComObject(_excelApp);
        }
    }
}

