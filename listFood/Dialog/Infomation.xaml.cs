using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Info : INotifyPropertyChanged
    {
        private string _HUONGDAN;
        public string HuongDan
        {
            get => _HUONGDAN; set
            {
                _HUONGDAN = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Huongdan"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Control : INotifyPropertyChanged
    {
        private string _Control;
        public string CONTROL
        {
            get => _Control; set
            {
                _Control = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CONTROL"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Name : INotifyPropertyChanged
    {
        private string _Name;
        public string NAME
        {
            get => _Name; set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    /// <summary>
    /// Interaction logic for Infomation.xaml
    /// </summary>
    public partial class Infomation : UserControl
    {
        
        public Infomation()
        {
            InitializeComponent();
        }
        BindingList<Info> _list;
        BindingList<Control> _list2;
        BindingList<Name> _list3;
        private void Info_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new BindingList<Info>()
            {
                new Info() {HuongDan ="Trang chủ: ......................................................................."},
                new Info() {HuongDan ="Trang chủ: ............"},
                new Info() {HuongDan ="Trang chủ: ................................................"},
                new Info() {HuongDan ="Trang chủ: ............................................................"},
                new Info() {HuongDan ="Trang chủ: ........................................................"},
                new Info() {HuongDan ="Trang chủ: ...................................................."},
                new Info() {HuongDan ="Trang chủ: ............................................."},
                new Info() {HuongDan ="Trang chủ: ...................................."},
                new Info() {HuongDan ="Trang chủ: ......................................................."},
            };
            View_Info.ItemsSource = _list;
            _list2 = new BindingList<Control>()
            {
                new Control() {CONTROL ="Trang chủ: ......................................................................."},
                new Control() {CONTROL ="Trang chủ: ............"},
                new Control() {CONTROL ="Trang chủ: ................................................"},
                new Control() {CONTROL ="Trang chủ: ............................................................"},
                new Control() {CONTROL ="Trang chủ: ........................................................"},
                new Control() {CONTROL ="Trang chủ: ...................................................."},
                new Control() {CONTROL ="Trang chủ: ............................................."},
                new Control() {CONTROL ="Trang chủ: ...................................."},
                new Control() {CONTROL ="Trang chủ: ......................................................."},
            };
            View_Control.ItemsSource = _list2;
            View_Name.ItemsSource = _list3;
            _list3 = new BindingList<Name>()
            {
                new Name() {NAME ="18600011 - Nguyễn Trọng Quyết"},
                new Name() {NAME ="18600014 - Ngô Tất Tố"},
                new Name() {NAME ="18600038 - Phạm Phong Phú Cường"},
            };
            View_Name.ItemsSource = _list3;
        }
    }
}
