using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using listFood.Dialog;
using MaterialDesignColors.Recommended;

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {

        public Home()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            this.Hide();
        }

        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            DataContext = new Infomation();
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

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
        private void Button_List(object sender, RoutedEventArgs e)
        {
            DataContext = new ListFood();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            DataContext = new AddFood();
        }
        private void DockPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var index = ListBox_Food.SelectedIndex;
            var food = listFood[index];
            //var screen = new OpenWindowOfFood(food);
            //if (screen.ShowDiaglog() == true)
            var openWindow = new OpenWindowFood(food);
            DataContext = openWindow;

        }

        private void Button_Out(object sender, RoutedEventArgs e)
        {
            var DR = MessageBox.Show("Bạn có muốn thoát", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (DR == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}

