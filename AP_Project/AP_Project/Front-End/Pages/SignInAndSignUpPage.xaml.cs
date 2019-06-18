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
        public ProductsPage products = new ProductsPage();
        public management bossmanage = new management();
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.PersonLogin(UserName.Text, Password.Password))
                {
                    if (Back_End.MainRoot.AccesAccessLevel==1)
                    {
                        MainWindow win = (MainWindow)Window.GetWindow(this);
                        win.sign.Visibility = Visibility.Hidden;
                        win.body.Children.Add(products);
                    }
                    if (Back_End.MainRoot.AccesAccessLevel == 2)
                    {
                        MainWindow win = (MainWindow)Window.GetWindow(this);
                        win.sign.Visibility = Visibility.Hidden;
                        win.body.Children.Add(bossmanage);
                    }



                }
                
                   
            }
            catch { MessageBox.Show("something is wrong"); }
            
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person ob = new Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person(UserNameUp.Text, PasswordUp.Password,NameUp.Text, EmailUp.Text, PhoneUp.Text);
                Back_End.MainRoot.SetRoot(ob); 
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.sign.Visibility = Visibility.Hidden;
                win.body.Children.Add(products);
                
            }
            catch
            {
                MessageBox.Show("something is wrong");
            }

        }


        private void PhoneUp_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            int a;
            if (int.TryParse(e.Text, out a) == false)
                e.Handled = true;
        }
    }
}
