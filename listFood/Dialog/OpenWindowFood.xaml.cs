using System;
using System.Collections.Generic;
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

namespace listFood.Dialog
{
    /// <summary>
    /// Interaction logic for OpenWindowFood.xaml
    /// </summary>
    public partial class OpenWindowFood : UserControl
    {
        public Home.Recipe newFood;
        public int TempNext = 1;
        public double div = 0;
        public int temp = 0;
        public OpenWindowFood(Home.Recipe food)
        {
            InitializeComponent();
            this.newFood = food;
            

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            nameOfFood.Text = newFood._name;
            // Hiện thị từng bước làm
            listBox_Direction.ItemsSource = newFood._directions;
            // Xuất avatar cho món ăn
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = baseFolder+newFood._images[0];
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

            }
            else
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-red.png", UriKind.Relative));
                newFood._isFavorite = true;
            }

        }

        private void Button_Prev_Food(object sender, RoutedEventArgs e)
        {
            if (TempNext <= 1)
            {
                if (TempNext == 1)
                {
                    var prev = newFood._images.Skip(TempNext-2).Take(2).ToList();
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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
