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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Drawing;
using System.Windows.Input;
using Image = System.Windows.Controls.Image;

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public class Recipe : INotifyPropertyChanged
        {
            public int ID;

            private string Name;
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

        public class previewFood : INotifyPropertyChanged
        {
            public int _id;
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
        ObservableCollection<previewFood> _listFavorite = new ObservableCollection<previewFood>();
        List<string> Garbage = new List<string>();
        public int TempNext = 0;
        public double div = 0.0;
        public int temp = 0;
        int totalPage;
        int currentPage = 1;
        string dataFile = "";
        public Home()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            timer.Start();
        }
        //Đồng hồ
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }
        // Trang chủ
        private void Button_Home(object sender, RoutedEventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            this.Close();

        }
        // Thông tin
        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            DataContext = new Infomation();

        }
        // Thêm món ăn
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var currentID = _listFood.Count();
            var screen = new AddFood(currentID);
            string item;
            if (screen.ShowDialog() == true)
            {
                var newFood = screen.newFood;
                _listFood.Add(newFood);
                item = newFood.ID.ToString() + '~' + newFood._name + '~' + string.Join("\\", newFood._ingredients.ToArray()) + '~' + string.Join("\\", newFood._directions.ToArray()) + '~' + string.Join("\\", newFood._images.ToArray()) + '~' + newFood._isFavorite;
                if (new FileInfo(dataFile).Length != 0)
                {
                    File.AppendAllText(dataFile, '\n' + item);

                }
                else
                {
                    File.AppendAllText(dataFile, item);

                }
                if (newFood._directions.Count < 2 && newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
            totalPage = totalPageCurrent(_listFood);
            numPage.Text = $"{currentPage.ToString()}/{totalPage}";
        }
        // Thoát ứng dụng
        private void Button_Out(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Khởi động app
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
                newFood.ID = Int32.Parse(entries[0]);
                newFood._name = entries[1];
                string[] entriesIngredients = entries[2].Split('\\');
                newFood._ingredients = new List<string>();
                for (var i = 0; i < entriesIngredients.Length; i++)
                {
                    newFood._ingredients.Add(entriesIngredients[i]);
                }
                string[] entriesDirections = entries[3].Split('\\');
                newFood._directions = new List<string>();
                for (var i = 0; i < entriesDirections.Length; i++)
                {
                    newFood._directions.Add(entriesDirections[i]);
                }
                string[] entriesImages = entries[4].Split('\\');
                newFood._images = new List<string>();
                for (var i = 0; i < entriesImages.Length; i++)
                {
                    newFood._images.Add(entriesImages[i]);
                }
                newFood._isFavorite = Boolean.Parse(entries[5]);
                _listFood.Add(newFood);
                if (newFood._directions.Count < 2 && newFood._ingredients.Count < 2)
                {
                    previewFood food = new previewFood()
                    {
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
                        _id = newFood.ID,
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
                previewFood temp = previewFoods[i];
                if (temp.isFavorite == true)
                {
                    _listFavorite.Add(previewFoods[i]);
                }
            }
            

            List<previewFood> preFood = new List<previewFood>();
            foreach (previewFood itemFavorite in _listFavorite)
            {
                preFood.Add(itemFavorite);
            }
            var str = previewFoods;
            ListBox_Food.ItemsSource = previewFoods.Take(4);
            TempNext = 4;
            Random rdg = new Random();
            int index_rdg = rdg.Next(0, preFood.Count);
            if (preFood.Count > 0)
            {
                Box_Favorite1.ItemsSource = preFood;

            }
            div = previewFoods.Count / 4.0;
            totalPage = (int)Math.Ceiling(div);
            if(totalPage > 0)
            {
                numPage.Text = $"{currentPage.ToString()}/{totalPage}";
            }
            else
            {
                numPage.Text = "0";
            }
            
        }

        public int totalPageCurrent(ObservableCollection<Recipe> recipes)
        {
            double temp = recipes.Count / 4.0;
            int toReturn = (int)Math.Ceiling(temp);
            return toReturn;
        }
        // Mở món ăn trong list 
        private void openFood_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int pos = ListBox_Food.SelectedIndex;
            if (pos != -1)
            {
                var newindexOfFood = ListBox_Food.SelectedItem as previewFood;
                var getID = newindexOfFood._id - 1;
                var food = _listFood[getID];
                var openWindow = new OpenFood(_listFood,getID,previewFoods,_listFavorite);

                if (openWindow.ShowDialog() == true)
                {
                    if (openWindow.status == 1)
                    {
                        _listFood[getID] = openWindow.newFood;
                        openWindow.Close();
                    }
                    else
                    {
                        _listFood = openWindow._listFood;
                        foreach(string item in openWindow.garbage)
                        {
                            Garbage.Add(item);
                        }
                    }
                    
                }
                ListBox_Food.ItemsSource = openWindow.previewFoods;
                Box_Favorite1.ItemsSource = openWindow.listFavorite;
            }
            pos = Box_Favorite1.SelectedIndex;
            if (pos != -1)
            {
                var newindexOfFood = Box_Favorite1.SelectedItem as previewFood;
                var getID = newindexOfFood._id - 1;
                var food = _listFood[getID];
                var openWindow = new OpenFood(_listFood, getID, previewFoods, _listFavorite);

                if (openWindow.ShowDialog() == true)
                {
                    
                    if(openWindow.status ==0)
                    {
                        _listFood = openWindow._listFood;
                        foreach (string item in openWindow.garbage)
                        {
                            Garbage.Add(item);
                        }
                    }
                    else
                    {
                        _listFood[getID] = openWindow.newFood;
                        openWindow.Close();
                    }
                    ListBox_Food.ItemsSource = openWindow.previewFoods;

                }
                ListBox_Food.ItemsSource = openWindow.previewFoods;
                Box_Favorite1.ItemsSource = openWindow.listFavorite;
            }

        }

        //Loại Tiếng Việt 
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        // Tìm kiếm món ăn
        private void Search_button(object sender, RoutedEventArgs e)
        {

            var strings = previewFoods.Where(p => convertToUnSign3(p.Name.ToLower()).Contains(convertToUnSign3(Search.Text.ToLower())));
            if (strings.Count() != 0)
            {
                ListBox_Food.ItemsSource = strings.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        // Lùi trang
        private void Button_Prev(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                numPage.Text = $"{currentPage.ToString()}/{totalPage}";
            }
            if (TempNext <= 4)
            {
                if (TempNext == 4)
                {
                    var prev = previewFoods.Skip(TempNext - 4).Take(4).ToList();
                    ListBox_Food.ItemsSource = prev.ToList();
                    temp = 0;

                }
                else
                {
                    temp = 0;
                }

            }
            else
            {
                var prev = previewFoods.Skip(TempNext - 8).Take(4).ToList();
                ListBox_Food.ItemsSource = prev.ToList();
                temp -= 1;
                if (temp >= 0)
                {
                    TempNext -= 4;
                }
            }

        }
        // Tiến trang
        private void Button_Next(object sender, RoutedEventArgs e)
        {
            if (currentPage <= div)
            {
                currentPage++;
                numPage.Text = $"{currentPage.ToString()}/{totalPage}";
            }

            if (TempNext >= previewFoods.Count)
            {
                temp = (int)div;
            }
            else
            {
                var next = previewFoods.Skip(TempNext).Take(4).ToList();
                ListBox_Food.ItemsSource = next.ToList();
                temp += 1;
                int tempint = (int)Math.Ceiling(div);

                if (temp <= tempint - 1)
                {
                    TempNext += 4;
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var resultDialog = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultDialog == MessageBoxResult.Yes)
            {
                File.WriteAllText(dataFile, String.Empty);
                for (int i = 0; i <_listFood.Count; i++)
                {
                    var newFood = _listFood[i];
                    var item= newFood.ID.ToString() + '~' + newFood._name + '~' + string.Join("\\", newFood._ingredients.ToArray()) + '~' + string.Join("\\", newFood._directions.ToArray()) + '~' + string.Join("\\", newFood._images.ToArray()) + '~' + newFood._isFavorite;
                    if (i != 0)
                    {
                        File.AppendAllText(dataFile, '\n' + item);

                    }
                    else
                    {
                        File.AppendAllText(dataFile,item);

                    }
                }
                if(Garbage.Count != 0)
                {
                    foreach(string path in Garbage)
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(path);
                    }
                }
            }

        }
    }
}
