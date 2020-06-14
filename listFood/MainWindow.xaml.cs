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
using System.Collections.ObjectModel;
using listFood.ListFood;

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
        }

        public Home()
        {
            InitializeComponent();
        }
        ObservableCollection<Food> listFood = new ObservableCollection<Food>();
        string dataFile = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder = folder.Remove(folder.IndexOf("bin"));
            dataFile = $"{folder}Data\\dataOfFood.txt";

            // Nạp danh sách món ăn đang có từ tập tin
            var items = File.ReadAllLines(dataFile).ToList();
            foreach (string item in items)
            {
                string[] entries = item.Split('~');
                Food newFood = new Food();
                newFood._nameOfFood = entries[0];
                listFood.Add(newFood);
            }
            ListBox_Food.ItemsSource = listFood;

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

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            DataContext = new Food1();
        }

        private void Button_Add2(object sender, RoutedEventArgs e)
        {
            DataContext = new Food2();
        }
        private void Button_Out(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

