using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace listFood
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : Window
    {
        public Home.Recipe newFood { get; set; }
        public AddFood()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] entriesIngredients = Regex.Split(ingredients.Text, "\r\n");
            List<string> Ingredients = new List<string>();
            for (var i = 0; i < entriesIngredients.Length; i++)
            {
                Ingredients.Add(entriesIngredients[i]);
            };
            string[] entriesDirections = Regex.Split(directions.Text, "\r\n");
            List<string> Directions = new List<string>();
            for (var i = 0; i < entriesDirections.Length; i++)
            {
                Directions.Add(entriesDirections[i]);
            };
            // ------------------------------------------------------------------------
            List<string> Images = new List<string>();
            var info = new FileInfo(fileName);
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder += "/data/img/imgFood/";
            string name = Guid.NewGuid().ToString();
            File.Copy(fileName, folder + name + info.Extension);
            Images.Add($"data/img/imgFood/{name}{info.Extension}");

            // -------------------------------------------------------------------------
            newFood = new Home.Recipe()
            {
                _name = nameFood.Text,
                _ingredients = Ingredients,
                _directions = Directions,
                _images = Images,
                _isFavorite = false
            };
            DialogResult = true;

        }
        string fileName = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                fileName = screen.FileName;
                var bitmap = new BitmapImage(new Uri(screen.FileName, UriKind.Absolute));
                image_1.Source = bitmap;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                fileName = screen.FileName;
                var bitmap = new BitmapImage(new Uri(screen.FileName, UriKind.Absolute));
                image_2.Source = bitmap;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                fileName = screen.FileName;
                var bitmap = new BitmapImage(new Uri(screen.FileName, UriKind.Absolute));
                image_3.Source = bitmap;
            }
        }
    }
}
