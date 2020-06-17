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
        private Home.Recipe newFood;

        public OpenWindowFood(Home.Recipe food)
        {
            InitializeComponent();
            this.newFood = food;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
            listImage.ItemsSource = newFood._images;

        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
