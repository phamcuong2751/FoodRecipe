﻿using System;
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

            // Xuât list image
            //listImage.ItemsSource = newFood._images;
            // Hiện món yêu thích
            if (newFood._isFavorite == true)
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-red.png", UriKind.Relative));

            }
            else
            {
                ChangeColorFavorite.Source = new BitmapImage(new Uri(@"/img/heart-white.png", UriKind.Relative));
            }
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

    }
}
