using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    internal class CaptureModeSelectionViewModel : ViewModelBase
    {
        private string _captureMode = "mode selection";
        public string CaptureMode
        {
            get { return _captureMode; }
            set { _captureMode = value; OnPropertyChanged(); }
        }

        private Capture _captureObject = new Capture();
        public Capture CaptureObject
        {
            get { return _captureObject; }
            set { _captureObject = value; OnPropertyChanged(); }
        }

        private bool _stateNext = false;
        public bool StateNext
        {
            get { return _stateNext; }
            set { _stateNext = value; OnPropertyChanged(); }
        }


        public CaptureModeSelectionViewModel()
        {
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        public ICommand OpenFileCommand { get; set; }
        
        private void OpenFile(object obj)
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
                CaptureObject.CaptureImage = local;
                StateNext = true;
                
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                //mainWindow.Focus();
                //this.Hide();
                //this.Close();
                //mainWindow.CaptureScreen(local);
            }

        }
    }
}
