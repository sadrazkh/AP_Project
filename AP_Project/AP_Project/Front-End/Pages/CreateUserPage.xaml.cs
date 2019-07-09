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
    /// Interaction logic for CreateUserPage.xaml
    /// </summary>
    public partial class CreateUserPage : UserControl
    {
        public CreateUserPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Back_End.Func.Persons.AP_Project.Back_End.Func.Persons.Person.PersonGen(300,20);
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
           management mg4 = new management();
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.body.Children.Remove(this);
            win.body.Children.Add(mg4);
        }
    }
}
