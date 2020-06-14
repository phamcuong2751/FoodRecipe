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

namespace listFood.ListFood
{
    /// <summary>
    /// Interaction logic for Food1.xaml
    /// </summary>
    public partial class Food1 : UserControl
    {
        public Food1()
        {
            InitializeComponent();
        }
        public class Food
        {
            public string _nameOfFood { get; set; }
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            this.Hide();
        }

        private void Hide()
        {
            throw new NotImplementedException();
        }

        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            Infomation info = new Infomation();
            info.Show();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            DataContext = new Food1();
        }

        private void Button_Add2(object sender, RoutedEventArgs e)
        {
            DataContext = new Food2();
        }
        private void Button_Out(object sender, RoutedEventArgs e)
        {

        }
    }
}
