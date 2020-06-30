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
using System.Windows.Shapes;

namespace listFood
{
    /// <summary>
    /// Interaction logic for Youtube.xaml
    /// </summary>
    public partial class Youtube : Window
    {
        private string linkytb;

        public Youtube()
        {
            InitializeComponent();

        }

        public Youtube(string link)
        {
            this.linkytb = link;
        }

        private void playClick(object sender, RoutedEventArgs e)
        {
            //linkytb = linkytb.Split('=')[1];
            //string iframe = $"https://www.youtube-nocookie.com/embed/{linkytb}?rel=0&amp;showinfo=0";
            //this.ytbBrowser.Navigate(linkytb);
        }
    }
}
