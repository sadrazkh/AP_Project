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
using System.IO;
using Microsoft.Win32;
using AP_Project.Back_End.Func.Products;

namespace AP_Project.Front_End.Pages
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : UserControl
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void selectimg_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==true)
            {
                txtbx.Text = op.FileName;
            }
        }

        private void createbtn_click(object sender, RoutedEventArgs e)
        {
            Back_End.Func.Products.Product Pro = new Back_End.Func.Products.Product(prname.Text,Convert.ToInt32(prtedad.Text),"null",prexplanation.Text,"null",prcompani.Text, Convert.ToInt32(prbarcode.Text));
        }

        private void Prtedad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int a;
            if (int.TryParse(e.Text, out a) == false)
                e.Handled = true;
        }

        private void Prbarcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int a;
            if (int.TryParse(e.Text, out a) == false)
                e.Handled = true;
        }
    }
}
