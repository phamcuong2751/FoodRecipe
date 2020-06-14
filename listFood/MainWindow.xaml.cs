using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Globalization;
using OpenQA.Selenium.Remote;
using System.ComponentModel;
using System.Windows.Threading;

namespace listFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        private BindingList<Book> _list;

        public class Food
        {
            public int ID { get; set; }
            public string nameOfFood { get; set; }
            public string howToFood { get; set; }
        }
        public Home()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Button_Out(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            Home hr = new Home();
            hr.Show();
            this.Hide();
        }

        private void Button_Infomation(object sender, RoutedEventArgs e)
        {
            Infomation info = new Infomation();
            info.Show();
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new BindingList<Book>()
            {
                new Book() {  Name = "Vẽ em  bằng màu của nỗi nhớ", Author ="Phạm Minh Tâm", ImageBook = "/img/bia01.jpg", Year = 2013  },
                new Book() {  Name = "Đừng Lựa Chọn An Nhàn Khi Còn Trẻ", Author ="Cảnh Thiên, Đặng Quân (Dịch)", ImageBook = "/img/bia02.jpg", Year = 2019  },
                new Book() {  Name = "Tuổi Trẻ Đáng Giá Bao Nhiêu", Author ="Rosie Nguyễn", ImageBook = "/img/bia03.jpg", Year = 2016  },
                new Book() {  Name = "Nhà Giả Kim", Author ="Paulo Ceolho", ImageBook = "/img/bia04.jpg", Year = 1988 },
                new Book() {  Name = "Tôi Quyết Định Sống Cho Chính Tôi", Author ="Kim Suhyun", ImageBook = "/img/bia05.jpg", Year = 2016  },
                new Book() {  Name = "Tôi, Tương Lai Và Thế Giới", Author ="Nguyễn Phi Vân", ImageBook = "/img/bia06.jpg", Year = 2018 },
                new Book() {  Name = "Đàn Ông Sao Hỏa Đàn Bà Sao Kim", Author ="John Gray", ImageBook = "/img/bia07.jpg", Year = 1992 },
                new Book() {  Name = "Tìm Mình Trong Thế Giới Hậu Tuổi Thơ", Author ="Đặng Hoàng Giang", ImageBook = "/img/bia08.jpg", Year = 2019 },
                new Book() {  Name = "Chuyến Tàu Một Chiều Không Trở Lại", Author ="Kiên Trần", ImageBook = "/img/bia09.jpg", Year = 2019 },
                new Book() {  Name = "Sống Thực Tế Giữa Đời Thực Dụng", Author ="Mễ Mông", ImageBook = "/img/bia10.jpg", Year = 2018 },
            };

            View_Box.ItemsSource = _list;
        }

        
    }
}

public class Book : INotifyPropertyChanged
{
    private string _imagebook;
    public string ImageBook
    {
        get => _imagebook;
        set
        {
            _imagebook = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageBook"));
        }
    }

    private string _namebook;
    public string Name
    {
        get => _namebook; set
        {
            _namebook = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameBook"));
        }
    }

    private string _authorbook;
    public string Author
    {
        get => _authorbook;
        set
        {
            _authorbook = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Author"));
        }
    }

    private int _yearbook;
    public int Year
    {
        get => _yearbook;
        set
        {
            _yearbook = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Year"));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

}