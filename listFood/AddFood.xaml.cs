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
        public string[] checkBreakLine(string[] a)
        {
           List<string> b = new List<string>(a);
            for(int i =0; i < b.Count-1; i++)
            {
               if(b[i] == "")
                {
                    b.RemoveAt(i);
                }
            }
            if (b[b.Count-1] == "")
            {
                b.RemoveAt(b.Count-1);
            }
            a = b.ToArray();
            return a;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] entriesIngredients = Regex.Split(ingredients.Text, "\r\n");
            entriesIngredients = checkBreakLine(entriesIngredients);
            List<string> Ingredients = new List<string>();
            for (var i = 0; i < entriesIngredients.Length; i++)
            {
                Ingredients.Add(entriesIngredients[i]);
            };
            string[] entriesDirections = Regex.Split(directions.Text, "\r\n");
            entriesDirections = checkBreakLine(entriesDirections);
            List<string> Directions = new List<string>();
            for (var i = 0; i < entriesDirections.Length; i++)
            {
                Directions.Add(entriesDirections[i]);
            };
            // ------------------------------------------------------------------------
            List<string> Images = new List<string>();
            foreach(string item in listPathImage)
            {
                var info = new FileInfo(item);
                string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
                folder += "/data/img/imgFood/";
                string name = Guid.NewGuid().ToString();
                File.Copy(item, folder + name + info.Extension);
                Images.Add($"data/img/imgFood/{name}{info.Extension}");
            };
           

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
        List<string> listPathImage = new List<string>();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(ofd.ShowDialog() == true)
            {
                foreach(string item in ofd.FileNames)
                {
                    listPathImage.Add(item);
                }
            }
            listImages.ItemsSource = listPathImage;
        }
    }
}
