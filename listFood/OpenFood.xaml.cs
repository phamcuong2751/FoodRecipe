using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Test_Splash_Screen;
namespace listFood
{
    /// <summary>
    /// Interaction logic for OpenFood.xaml
    /// </summary>
    public partial class OpenFood : Window
    {
        public Home.Recipe newFood;
        public Home.Recipe foodReturn;
        public Home.previewFood preview;
        public int getID;
        public int status;
        // status = 1 món ăn được chỉnh sửa
        // status = 0 món ăn bị xoá
        public int TempNext = 1;
        public double div = 0;
        public int temp = 0;
        public List<string> garbage = new List<string>();
        public ObservableCollection<Home.Recipe> _listFood;
        public ObservableCollection<Home.previewFood> previewFoods;
        public ObservableCollection<Home.previewFood> listFavorite;
        public OpenFood(ObservableCollection<Home.Recipe> listFood, int getID, ObservableCollection<Home.previewFood> previewFoods, ObservableCollection<Home.previewFood> listFavorite)
        {
            InitializeComponent();
            this.newFood = listFood[getID];
            this.getID = getID;
            this._listFood = listFood;
            this.previewFoods = previewFoods;
            this.listFavorite = listFavorite;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = newFood;
            nameOfFood.Text = newFood._name;
            // Hiện thị từng bước làm
            listBox_Direction.ItemsSource = newFood._directions;
            // Xuất avatar cho món ăn
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = baseFolder + newFood._images[0];
            Uri uri = new Uri(imagePath, UriKind.Absolute);
            BitmapImage bitmap = new BitmapImage(uri);
            mainImage.Source = bitmap;
            // Thành phần món ăn
            listBox_Ingredients.ItemsSource = newFood._ingredients;

            //Xuât list image
            listImage.ItemsSource = newFood._images.Take(2);
            // Hiện món yêu thích
            if (newFood._isFavorite == true)
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-red.png", UriKind.Relative));

            }
            else
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-white.png", UriKind.Relative));
            }
            div = newFood._images.Count / 1;
        }

        private void Click_Favorite(object sender, RoutedEventArgs e)
        {
            if (newFood._isFavorite == true)
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-white.png", UriKind.Relative));
                newFood._isFavorite = false;
                foreach(Home.previewFood item in listFavorite)
                {
                    if (item._id == getID + 1)
                    {
                        listFavorite.Remove(item);
                        break;
                    }
                }

            }
            else
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-red.png", UriKind.Relative));
                newFood._isFavorite = true;
                Home.previewFood temp = previewFoods[newFood.ID - 1];
                listFavorite.Add(temp);
            }

        }

        private void Button_Prev_Food(object sender, RoutedEventArgs e)
        {
            if (TempNext <= 1)
            {
                if (TempNext == 1)
                {
                    var prev = newFood._images.Skip(TempNext - 2).Take(2).ToList();
                    listImage.ItemsSource = prev.ToList();
                    temp = 0;
                }
                else
                {
                    temp = 0;
                }

            }
            else
            {
                var prev = newFood._images.Skip(TempNext - 2).Take(2).ToList();
                listImage.ItemsSource = prev.ToList();
                temp -= 1;
                if (temp >= 0)
                {
                    TempNext -= 1;
                }
            }
        }

        private void Button_Next_Food(object sender, RoutedEventArgs e)
        {
            if (TempNext >= newFood._images.Count)
            {
                temp = (int)div;
            }
            else
            {
                var next = newFood._images.Skip(TempNext).Take(2).ToList();
                listImage.ItemsSource = next.ToList();
                temp += 1;
                int tempint = (int)Math.Ceiling(div);

                if (temp <= tempint - 1)
                {
                    TempNext += 1;
                }
            }

        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            foodReturn = new Home.Recipe()
            {
                _name = newFood._name,
                _directions = newFood._directions,
                _images = newFood._images,
                _ingredients = newFood._ingredients,
                ID = newFood.ID,
                _isFavorite = newFood._isFavorite
            };
  
           
            DialogResult = true;
        }

        private void deleteButton(object sender, RoutedEventArgs e)
        {
            
            var result = MessageBox.Show($"Bạn có chắc sẽ xoá món {newFood._name}", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                status = 0;
                var totalFood = _listFood.Count;
                int i = getID;
                string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
                foreach(string path in _listFood[getID]._images)
                {
                    garbage.Add(baseFolder + path);
                }
                _listFood.RemoveAt(getID);
                previewFoods.RemoveAt(getID);
                if (getID != totalFood - 1)
                {
                    for (i = i; i < _listFood.Count; i++)
                    {
                        _listFood[i].ID = _listFood[i].ID - 1;
                        previewFoods[i]._id = previewFoods[i]._id - 1;
                    }
                }
                foreach(Home.previewFood item in listFavorite)
                {
                    if(item._id == getID + 1)
                    {
                        listFavorite.Remove(item);
                        break;
                    }
                }
                DialogResult = true;
            }

        }


      
    }
}
