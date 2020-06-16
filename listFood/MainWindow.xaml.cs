using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using listFood.Dialog;
using MaterialDesignColors.Recommended;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        public class Recipe
        {
            public string _name { get; set; }
            public List<string> _ingredients { get; set; } = null; // Thành phần món ăn
            public List<string> _directions { get; set; } = null; // Các bước hướng dẫn
            public List<string> _images { get; set; } = null;
            public bool _isFavorite { get; set; }
        }
        public class previewFood
        {
            public string Name { get; set; }
            public string shortIngredient { get; set; }
            public string shortDirection { get; set; }
            public string Avatar { get; set; }
            public bool isFavorite { get; set; }

        }
        public class Food
        {
            public string _nameOfFood { get; set; }
            public string _howToFood { get; set; }
            public int _rating { get; set; }
            public string _cover { get; set; }
            public string _material { get; set; }
        }

        ObservableCollection<Recipe> _listFood = new ObservableCollection<Recipe>();
        ObservableCollection<Food> listFood = new ObservableCollection<Food>();
        string dataFile = "";
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
        //    folder = folder.Remove(folder.IndexOf("bin"));
        //    dataFile = $"{folder}Data\\dataOfFood.txt";

        //    // Nạp danh sách món ăn đang có từ tập tin
        //    var items = File.ReadAllLines(dataFile).ToList();
        //    foreach (string item in items)
        //    {
        //        string[] entries = item.Split('~');
        //        Food newFood = new Food();
        //        newFood._nameOfFood = entries[0];
        //        newFood._howToFood = entries[1];
        //        newFood._cover = entries[2];
        //        newFood._rating = int.Parse(entries[3]);
        //        newFood._material = entries[4];
        //        listFood.Add(newFood);
        //    }
        //    ListBox_Food.ItemsSource = listFood;
        //}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder = folder.Remove(folder.IndexOf("bin"));
            dataFile = $"{folder}Data\\dataOfFood1.txt";

            var items = File.ReadAllLines(dataFile).ToList();
            List<previewFood> previewFoods = new List<previewFood>(); // Lưu thông tin xem trước của món ăn
            foreach (string item in items)
            {
                string[] entries = item.Split('~');
                Recipe newFood = new Recipe();
                newFood._name = entries[0];
                string[] entriesIngredients = entries[1].Split('\\');
                newFood._ingredients = new List<string>();
                for (var i = 0; i < entriesIngredients.Length; i++)
                {
                    newFood._ingredients.Add(entriesIngredients[i]);
                }
                string[] entriesDirections = entries[2].Split('\\');
                newFood._directions = new List<string>();
                for (var i = 0; i < entriesDirections.Length; i++)
                {
                    newFood._directions.Add(entriesDirections[i]);
                }
                string[] entriesImages = entries[3].Split('\\');
                newFood._images = new List<string>();
                for (var i = 0; i < entriesImages.Length; i++)
                {
                    newFood._images.Add(entriesImages[i]);
                }
                newFood._isFavorite = Boolean.Parse(entries[4]);
                _listFood.Add(newFood);
                previewFood food = new previewFood()
                {
                    Name = newFood._name,
                    shortIngredient = newFood._ingredients[0] + '\n' + newFood._ingredients[1] + '\n' + "...",
                    shortDirection = newFood._directions[0] + '\n' + newFood._directions[1] + '\n' + "...",
                    Avatar = newFood._images[0],
                    isFavorite = newFood._isFavorite
                };
                previewFoods.Add(food);
            }

            ListBox_Food.ItemsSource = previewFoods;
            Box_Favorite1.ItemsSource = previewFoods;
            Box_Favorited2.ItemsSource = previewFoods;
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
            var food = _listFood[index];
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

