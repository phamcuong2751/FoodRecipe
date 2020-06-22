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
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Windows.Controls;
using System.Data.SqlClient;

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
            this.Close();
        }

        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            DataContext = new Infomation();
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        public class Recipe : INotifyPropertyChanged
        {
            public string Name;
            public string _name
            {
                get => Name; set
                {
                    Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_name"));
                }
            }
            private List<string> ingredients;
            public List<string> _ingredients
            {
                get => ingredients; set
                {
                    ingredients = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_ingredients"));
                }
            }
            private List<string> directions;
            public List<string> _directions
            {
                get => directions; set
                {
                    directions = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_directions"));
                }
            }
            private List<string> images;
            public List<string> _images
            {
                get => images; set
                {
                    images = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_images"));
                }
            }
            private bool isFavorite;
            public bool _isFavorite
            {
                get => isFavorite; set
                {
                    isFavorite = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_isFavorite"));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        public class Favorite
        {
            public Favorite(previewFood preview, int i)
            {
                recipe = preview;
                i = index;
            }
            public previewFood recipe { get; set; }
            public int index { get; set; }
        }
        public class previewFood : INotifyPropertyChanged
        {
            private string _name;
            public string Name
            {
                get => _name; set
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            private string ingredients;
            public string shortIngredient
            {
                get => ingredients; set
                {
                    ingredients = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("shortIngredient"));
                }
            }
            private string directions;
            public string shortDirection
            {
                get => directions; set
                {
                    directions = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("shortDirection"));
                }
            }
            private string images;
            public string Avatar
            {
                get => images; set
                {
                    images = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Avatar"));
                }
            }
            private bool Favorite;
            public bool isFavorite
            {
                get => Favorite; set
                {
                    Favorite = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isFavorite"));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        ObservableCollection<Recipe> _listFood = new ObservableCollection<Recipe>();
        ObservableCollection<previewFood> previewFoods = new ObservableCollection<previewFood>();
        ObservableCollection<Favorite> _listFavorite = new ObservableCollection<Favorite>();
        string dataFile = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder = folder.Remove(folder.IndexOf("bin"));
            dataFile = $"{folder}Data\\dataOfFood1.txt";

            var items = File.ReadAllLines(dataFile).ToList();
            // Lưu thông tin xem trước của món ăn
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
                if (newFood._directions.Count < 2 && newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0],
                        shortDirection = newFood._directions[0],
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else if (newFood._directions.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0] + '\n' + newFood._ingredients[1] + '\n' + "...",
                        shortDirection = newFood._directions[0],
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else if (newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0],
                        shortDirection = newFood._directions[0] + '\n' + newFood._directions[1] + '\n' + "...",
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else
                {
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


            }
            for (var i = 0; i < previewFoods.Count; i++)
            {
                Favorite temp = new Favorite(previewFoods[i], i);
                if (previewFoods[i].isFavorite == true)
                {
                    _listFavorite.Add(temp);
                }
            }
            {

            }

            List<previewFood> preFood = new List<previewFood>();
            foreach (Favorite itemFavorite in _listFavorite)
            {
                preFood.Add(itemFavorite.recipe);
            }
            ListBox_Food.ItemsSource = previewFoods;
            Random rdg = new Random();
            int index_rdg = rdg.Next(0, preFood.Count);
            if (preFood.Count > 0)
            {
                Box_Favorite1.ItemsSource = preFood;

            }
             
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var screen = new AddFood();
            string item;
            if (screen.ShowDialog() == true)
            {
                var newFood = screen.newFood;
                _listFood.Add(newFood);
                item = newFood._name + '~' + string.Join("\\", newFood._ingredients.ToArray()) + '~' + string.Join("\\", newFood._directions.ToArray()) + '~' + string.Join("\\", newFood._images.ToArray()) + '~' + newFood._isFavorite;
                File.AppendAllText(dataFile, '\n' + item);
                if (newFood._directions.Count < 2 && newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0],
                        shortDirection = newFood._directions[0],
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else if (newFood._directions.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0] + '\n' + newFood._ingredients[1] + '\n' + "...",
                        shortDirection = newFood._directions[0],
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else if (newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        Name = newFood._name,
                        shortIngredient = newFood._ingredients[0],
                        shortDirection = newFood._directions[0] + '\n' + newFood._directions[1] + '\n' + "...",
                        Avatar = newFood._images[0],
                        isFavorite = newFood._isFavorite
                    };
                    previewFoods.Add(food);
                }
                else
                {
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
            }
            ListBox_Food.ItemsSource = previewFoods;
        }

        private void DockPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var index = ListBox_Food.SelectedIndex;
            var food = _listFood[index];
            var openWindow = new OpenWindowFood(food);
            DataContext = openWindow;
        }
        public bool Checked { get; set; }
        private void Button_Out(object sender, RoutedEventArgs e)
        {
            var DR = MessageBox.Show("Bạn có muốn thoát", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (DR == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }


        private void Box_Favorite1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var indexFavorite = Box_Favorite1.SelectedIndex;
            var index  =_listFavorite[indexFavorite].index;
            var food = _listFood[index];
            var openWindow = new OpenWindowFood(food);
            DataContext = openWindow;
        }

        private void Search_button(object sender, RoutedEventArgs e)
        {
            var strings = previewFoods.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower()) || p.shortDirection.ToLower().Contains(Search.Text.ToLower()) || p.shortIngredient.ToLower().Contains(Search.Text.ToLower()));
            if(strings.Count() != 0)
            {
                ListBox_Food.ItemsSource = strings.ToList();
            }   
            else
            {
                MessageBox.Show("Không tìm thấy");
            }
        }
    }
}

