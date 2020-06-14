using listFood;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;

namespace Test_Splash_Screen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        ObservableCollection<string> newChecked = new ObservableCollection<string>();
        string dataFile = "";
        public class Food : INotifyPropertyChanged
        {
            private string _nameFood;
            public string Name
            {
                get => _nameFood; set
                {
                    _nameFood = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            private string _avatar;
            public string AVT
            {
                get => _avatar; set
                {
                    _avatar = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AVT"));

                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public MainWindow()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory; // "C:\Users\dev\"
            folder = folder.Remove(folder.IndexOf("bin"));
            dataFile = $"{folder}Data\\data.txt";
            var isChecked = File.ReadAllText(dataFile);
            InitializeComponent();
            if (isChecked == "true")
            {
                Home hr = new Home();
                hr.Show();
                this.Close();
            }
            else
            {
                dt.Tick += new EventHandler(dT_Tick);
                dt.Interval = new TimeSpan(0, 0, 8);
                dt.Start();
            }

        }
        private void dT_Tick(object sender, EventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            dt.Stop();
            this.Close();
        }
        private void Check(object sender, RoutedEventArgs e)
        {
            if (Change.IsChecked == true)
            {
                string newData = "true";
                File.WriteAllText(dataFile, newData);
            }
            else
            {
                string newData = "fasle";
                File.WriteAllText(dataFile, newData);
            }
        }
        BindingList<Food> _list;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random rgn = new Random();
            _list = new BindingList<Food>()
            {
                new Food() { Name = "THỊT TRÂU GÁC BẾP (HÀ GIANG)",AVT="/data/img/splashscreen/food_1.jpg"},
                new Food() { Name = "MÓN NƯỚNG SAPA – LÀO CAI", AVT="/data/img/splashscreen/food_2.jpg"},
                new Food() { Name = "PHỞ CHUA LẠNG SƠN",AVT="/data/img/splashscreen/food_3.jpg"},
                new Food() { Name = "LỢN CẮP NÁCH LAI CHÂU", AVT="/data/img/splashscreen/food_4.jpg"},
                new Food() { Name = "XÔI CHIM MƯỜNG THANH – ĐIỆN BIÊN", AVT="/data/img/splashscreen/food_5.jpg"},
                new Food() { Name = "CÁ SÔNG ĐÀ NƯỚNG/ĐỒ – HÒA BÌNH", AVT="/data/img/splashscreen/food_6.jpg"},
                new Food() { Name = "CHẢ GÀ TIỂU QUAN – HƯNG YÊN",AVT="/data/img/splashscreen/food_7.jpg" },
                new Food() { Name = "CHÈ KHO NAM ĐỊNH", AVT="/data/img/splashscreen/food_8.jpg"},
                new Food() { Name = "TU HÀI QUẢNG NINH",AVT="/data/img/splashscreen/food_9.jpg" },
                new Food() { Name = "BÁNH ĐẬU XANH HẢI DƯƠNG", AVT="/data/img/splashscreen/food_10.jpg"},
                new Food() { Name = "BÁNH MỲ CAY HẢI PHÒNG",AVT="/data/img/splashscreen/food_11.jpg"},
                new Food() { Name = "PHỞ HÀ NỘI", AVT="/data/img/splashscreen/food_12.jpg"},
                new Food() { Name = "THỊT DÊ NINH BÌNH",AVT="/data/img/splashscreen/food_13.jpg"},
                new Food() { Name = "NEM CHUA THANH HÓA", AVT="/data/img/splashscreen/food_14.jpg"},
                new Food() { Name = "CHÁO LƯƠN XỨ NGHỆ", AVT="/data/img/splashscreen/food_15.jpg"},
                new Food() { Name = "CU ĐƠ HÀ TĨNH", AVT="/data/img/splashscreen/food_16.jpg"},
                new Food() { Name = "CƠM ÂM PHỦ HUẾ",AVT="/data/img/splashscreen/food_17.jpg" },
                new Food() { Name = "MÌ QUẢNG ĐÀ NẴNG", AVT="/data/img/splashscreen/food_18.jpg"},
                new Food() { Name = "DON QUẢNG NGÃI",AVT="/data/img/splashscreen/food_19.jpg" },
                new Food() { Name = "THỊT NAI ĐẮK LẮK", AVT="/data/img/splashscreen/food_20.jpg"},
                new Food() { Name = "CÁ LĂNG NƯỚNG THAN ĐẮK NÔNG",AVT="/data/img/splashscreen/food_21.jpg"},
                new Food() { Name = "BÚN SỨA NHA TRANG (KHÁNH HÒA)", AVT="/data/img/splashscreen/food_22.jpg"},
                new Food() { Name = "BÁNH TRÁNG NƯỚNG ĐÀ LẠT (LÂM ĐỒNG)",AVT="/data/img/splashscreen/food_23.jpg"},
                new Food() { Name = "BÁNH XÈO PHAN THIẾT (BÌNH THUẬN)", AVT="/data/img/splashscreen/food_24.jpg"},
                new Food() { Name = "BÁNH TRÁNG ME TÂY NINH", AVT="/data/img/splashscreen/food_25.jpg"},
                new Food() { Name = "CƠM TẤM SÀI GÒN", AVT="/data/img/splashscreen/food_26.jpg"},
                new Food() { Name = "GÀ QUAY XÔI PHỒNG BÌNH DƯƠNG",AVT="/data/img/splashscreen/food_27.jpg" },
                new Food() { Name = "GỎI SẦU ĐÂU CHÂU ĐỐC (AN GIANG)", AVT="/data/img/splashscreen/food_28.jpg"},
                new Food() { Name = "GỎI BA KHÍA BẠC LIÊU",AVT="/data/img/splashscreen/food_29.jpg" },
                new Food() { Name = "BÁNH PÍA SÓC TRĂNG (BÒ NƯỚNG XẺNG)", AVT="/data/img/splashscreen/food_30.jpg"},
                new Food() { Name = "CHUỘT ĐỒNG, CHUỘT CỐNG NHUM CAO LÃNH – ĐỒNG THÁP",AVT="/data/img/splashscreen/food_31.jpg" },
                new Food() { Name = "BÁNH KHỌT VŨNG TÀU", AVT="/data/img/splashscreen/food_32.jpg"}
            };
            DataContext = _list[rgn.Next(32)];
        }
    }
}
