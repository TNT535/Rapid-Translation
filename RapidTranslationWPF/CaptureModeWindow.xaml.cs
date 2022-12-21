using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for CaptureModeWindow.xaml
    /// </summary>
    public partial class CaptureModeWindow : Window
    {
        public CaptureModeWindow()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.Focus();
            this.Hide();
            this.Close();
            mainWindow.CaptureScreen();
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            Bitmap local;

            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "image"; // Default file name
            dialog.DefaultExt = ".jpeg"; // Default file extension
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.JPEG)|*.BMP;*.JPG;*.PNG;*.JPEG|All files (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                local = new Bitmap(filename);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.Focus();
                this.Hide();
                this.Close();
                mainWindow.CaptureScreen(local);
            }

        }
    }
}
