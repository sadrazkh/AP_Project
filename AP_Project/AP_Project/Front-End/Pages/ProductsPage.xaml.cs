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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : UserControl
    {
        public UserManagement manager = new UserManagement();
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void Profilebtn(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.body.Children.Add(manager);
        }

        private void SignOutbtn_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
