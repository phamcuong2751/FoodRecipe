using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace listFood.Dialog
{
    /// <summary>
    /// Interaction logic for AddFood.xaml
    /// </summary>
    public partial class AddFood : UserControl
    {
        public Home.Recipe newFood { get; set; } = null;

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
                Ingredients.Add(entriesIngredients[i]);
            };
            newFood = new Home.Recipe()
            {
                _name = nameFood.Text,
                _ingredients = Ingredients,
                _directions = Directions,
                _images = Ingredients,
                _isFavorite = false
            };
        }
    }
}
