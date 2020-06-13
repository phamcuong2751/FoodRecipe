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
using OpenQA.Selenium.Remote;

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public class Food
        {
            public int ID { get; set; }
            public string nameOfFood { get; set; }
            public string howToFood { get; set; }
        }
        public Home()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Food> listFoods = new List<Food>();
            //using Excel = Microsoft.Office.Interop.Excel;
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"sandbox_test.xlsx");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

        }
        private void Button_Out(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            this.Hide();
        }

        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            Infomation info = new Infomation();
            info.Show();
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}

