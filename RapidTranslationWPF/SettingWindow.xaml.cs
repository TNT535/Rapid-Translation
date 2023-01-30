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

namespace RapidTranslationWPF
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }  
        private void OnChangedNameBox(object sender, TextChangedEventArgs e)
        {
            if (this.NameBox.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"/Resources/BoxName.png", UriKind.Relative));

                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                this.NameBox.Background = textImageBrush;
            }
            else
            {
                this.NameBox.Background = null;
            }
        }

        private void OnChangedSurnameBox(object sender, TextChangedEventArgs e)
        {
            if (this.SurnameBox.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"/Resources/BoxSurname.png", UriKind.Relative));

                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                this.SurnameBox.Background = textImageBrush;
            }
            else
            {
                this.SurnameBox.Background = null;
            }
        }

        private void OnChangedPatronymicBox(object sender, TextChangedEventArgs e)
        {
            if (this.PatronymicBox.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource = new BitmapImage(new Uri(@"/Resources/BoxSurname.png", UriKind.Relative));

                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                this.PatronymicBox.Background = textImageBrush;
            }
            else
            {
                this.PatronymicBox.Background = null;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            // TODO: Write code to save user data.
        }
    }
}
