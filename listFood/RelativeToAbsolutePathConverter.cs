using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

<<<<<<< HEAD
namespace Test_Splash_Screen
=======
namespace listFood
>>>>>>> phucuong
{
    class RelativeToAbsolutePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var relative = (string)value;
<<<<<<< HEAD
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
=======
            var baseFolder = AppDomain.CurrentDomain.BaseDirectory;
>>>>>>> phucuong
            var absolute = $"{baseFolder}{relative}";
            return absolute;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
