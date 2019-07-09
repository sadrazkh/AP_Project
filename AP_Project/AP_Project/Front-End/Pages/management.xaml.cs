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
            UserManagement mg = new UserManagement();
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.body.Children.Remove(this);
            win.body.Children.Add(mg);
        }

        private void createuserbtn(object sender, RoutedEventArgs e)
        {
            CreateUserPage cr = new CreateUserPage();
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.body.Children.Remove(this);
            win.body.Children.Add(cr);
        }

        private void signoutbtn_Click(object sender, RoutedEventArgs e)
        {
            Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.LogOut();
            SignInAndSignUpPage sign2 = new SignInAndSignUpPage();
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.body.Children.Remove(this);
            win.body.Children.Add(sign2);
        }
    }
}
