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
        private Home.Food newFood;

        public OpenWindowFood(Home.Food food)
        {
            InitializeComponent();
            this.newFood = food;
            this.newFood._rating++;
            DataContext = newFood;
        }
    }
}
