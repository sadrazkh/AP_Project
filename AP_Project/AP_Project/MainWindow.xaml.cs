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
using AP_Project.Front_End.Pages;

namespace AP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SignInAndSignUpPage sad = new SignInAndSignUpPage();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //head.Visibility = Visibility.Hidden;
            //UserManagement sign = new UserManagement();
            //body.Children.Add(sign);
            body.Children.Add(sad);
        }


        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {

        }

        public  void RemoveUserControler(UserControl Page)
        {
            body.Children.Remove(Page);
        }
    }
}
