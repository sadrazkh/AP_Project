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
    /// Interaction logic for SignInAndSignUpPage.xaml
    /// </summary>
    public partial class SignInAndSignUpPage : UserControl
    {
        public SignInAndSignUpPage()
        {
            InitializeComponent();
        }
        public UserManagement manager = new UserManagement();
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {

            if (Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.PersonLogin(UserName.Text, Password.Password)) 
            {
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.Visibility = Visibility.Visible;
                win.sign.Visibility = Visibility.Hidden;
                win.body.Children.Add(manager);
            }
            else
            {
                MessageBox.Show("Validation failed");
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
