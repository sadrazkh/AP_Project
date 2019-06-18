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

namespace AP_Project.Front_End.Pages
{
    /// <summary>
    /// Interaction logic for management.xaml
    /// </summary>
    public partial class management : UserControl
    {
        public CreateProduct cproduct = new CreateProduct();
        public management()
        {
            InitializeComponent();
        }

        private void addproduct(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
      
            win.body.Children.Add(cproduct);
        }

        private void editproductsbtn(object sender, RoutedEventArgs e)
        {

        }

        private void showallusersbtn(object sender, RoutedEventArgs e)
        {

        }

        private void editusersinformation(object sender, RoutedEventArgs e)
        {

        }

        private void createuserbtn(object sender, RoutedEventArgs e)
        {

        }
    }
}
