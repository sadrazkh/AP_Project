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
using AP_Project.Back_End;

namespace AP_Project.Front_End.Pages
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : UserControl
    {
       
        public UserManagement()
        {
            InitializeComponent();
            
        }
        //public ProductsPage pr1 = new ProductsPage();


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(MainRoot.AccesAccessLevel==2)
            {
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.body.Children.Remove(this);
                management mg3 = new management();
                win.body.Children.Add(mg3);
                Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.ChangePersonalInfo(MainRoot.UserName, newEmailtxtbx.Text, newfullNameTxt.Text, newphonenumber.Text);
            }
            else
            {
                MainWindow win = (MainWindow)Window.GetWindow(this);
                win.body.Children.Remove(this);
                ProductsPage pr1 = new ProductsPage();
                win.body.Children.Add(pr1);
                Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.ChangePersonalInfo(MainRoot.UserName, newEmailtxtbx.Text, newfullNameTxt.Text, newphonenumber.Text);
            }
           
            
        }

        private void showinfobtn_Click(object sender, RoutedEventArgs e)
        {
            Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.PersonLogin(MainRoot.UserName, MainRoot.Password);
            Back_End.Func.ConectionToDb.dbreload();
            newfullNameTxt.Text = MainRoot.FullName;
            newusernametxtbx.Text = MainRoot.UserName;
            newEmailtxtbx.Text = MainRoot.Email;
            newphonenumber.Text = MainRoot.PhoneNumber;
           

        }
    }
}
