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
using System.Windows.Shapes;

namespace WelcomedotNET6
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        string UserName;

        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserName = textbox1.Text;

            //System.IO.StreamWriter writer = new System.IO.StreamWriter("Name.txt");
            //writer.Write(UserName);
            //writer.Close();
            //writer.Dispose();
            //this.Close();
        }

        private void textbox1_MouseEnter(object sender, MouseEventArgs e)
        {
            textbox1.Text = "";
            textbox1.Foreground = Brushes.Black;
        }

    }
}
