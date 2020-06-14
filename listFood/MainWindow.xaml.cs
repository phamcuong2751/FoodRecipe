using System;
using System.IO;
using System.Linq;
using System.Windows;
<<<<<<< HEAD
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
=======
using System.Windows.Threading;
>>>>>>> phucuong
using System.Collections.ObjectModel;

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
<<<<<<< HEAD
        public class Food
        {
            public string _nameOfFood { get; set; }
            public string _howToFood { get; set; }
            public int _rating { get; set; }
            public string _cover { get; set; }
            public string _material { get; set; }
        }

=======
    
>>>>>>> phucuong
        public Home()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
<<<<<<< HEAD
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
                newFood._howToFood = entries[1];
                newFood._cover = entries[2];
                newFood._rating = int.Parse(entries[3]);
                newFood._material = entries[4];
                listFood.Add(newFood);
            }
            ListBox_Food.ItemsSource = listFood;
=======

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Button_Out(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
>>>>>>> phucuong

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


<<<<<<< HEAD
=======
        }
        public class Food
        {
            public string _nameOfFood { get; set; }
            public string _howToFood { get; set; }
            public int _rating { get; set; }
            public string _cover { get; set; }
            public string _material { get; set; }
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
                newFood._howToFood = entries[1];
                newFood._cover = entries[2];
                newFood._rating = int.Parse(entries[3]);
                newFood._material = entries[4];
                listFood.Add(newFood);
            }
            ListBox_Food.ItemsSource = listFood;

        }
       
>>>>>>> phucuong
    }
}

