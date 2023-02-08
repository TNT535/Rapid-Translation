using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//Copy from old MainWindow.xaml.cs
using Form1 = WinFormsApp1.Form1;
using OCR = WinFormsApp1.OCR;
using Form = System.Windows.Forms.Form;

//using Stitcher = OpenCvSharp.Stitcher;
using FormApplication = System.Windows.Forms.Application;
using Bitmap = System.Drawing.Bitmap;

using System.Windows.Media.Imaging;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class CaptureProgressViewModel : ViewModelBase
    {
        private string _captureProgress = "progress";
        public string CaptureProgress
        {
            get { return _captureProgress; }
            set { _captureProgress = value; OnPropertyChanged(); }
        }
        public CaptureProgressViewModel()
        {
            CaptureProgress = "capture progress user control window";
            AddTextSampleCommand = new RelayCommand(AddTextSample);
            CaptureActionCommand = new RelayCommand(CaptureAction);
            SelectWordCommand = new RelayCommand(SelectWord);
            SearchWordRightClickCommand = new RelayCommand(RightClickWord);

            ProcessingOnFile();
        }

        private Capture _captureObject = new Capture();
        public Capture CaptureObject
        {
            get { return _captureObject; }
            set { _captureObject = value; OnPropertyChanged(); }
        }

        public ICommand AddTextSampleCommand { get; set; }
        public ICommand CaptureActionCommand { get; set; }
        public ICommand SelectWordCommand { get; set; }
        public ICommand SearchWordRightClickCommand { get; set; }

        private void AddTextSample(object obj) => CaptureObject.OCRWordList.Add("test command");

        //public ObservableCollection<string> OCRWordList
        //{
        //    get { return _captureObject.OCRWordList; }
        //    set { _captureObject.OCRWordList = value; OnPropertyChanged(); }
        //}

        private void CaptureAction(object obj)
        {
            Bitmap localImage = null;
            //Bitmap localImage = (Bitmap)CaptureObject.CaptureImage.Clone() == null?null: (Bitmap)CaptureObject.CaptureImage.Clone();
            if (localImage == null)
            {
                if (obj != null)
                {
                    Window wind = obj as Window;
                    wind.WindowState = WindowState.Minimized;
                }

                CaptureObject.CaptureWindowState = System.Windows.WindowState.Minimized;
                Form form1 = new Form1();
                FormApplication.Run(form1);
                //Bitmap img;
                //if (!form1.Created)
                //    FormApplication.Run(form1);
                //else
                //{
                //    form1.Show();
                //}
                if (form1.Capture == null)
                {
                    CaptureObject.CaptureWindowState = System.Windows.WindowState.Normal;
                    return;
                }

                string ans = OCR.ImageToText(Form1.capture, 0);
                // get list of line text
                List<string> listSentence = ans.Split('\n').ToList();
                List<string> listSentenceProcessed = new List<string>() { "" };
                foreach (string _line in listSentence)
                {
                    string line = String.Join(" ", _line.Split());
                    List<string> listWord = new List<string>(line.Split());

                    listSentenceProcessed.AddRange(listWord);
                }
                //if (listSentenceProcessed.Count > 1)
                //    listSentenceProcessed.RemoveAt(0);

                CaptureObject.OCRWordList = new ObservableCollection<string>(listSentenceProcessed);
                bool[] selectedWord = new bool[listSentenceProcessed.Count];
                for (int i = 0; i < selectedWord.Length; i++) { selectedWord[i] = true; }
                CaptureObject.SelectedWord = new ObservableCollection<bool>(selectedWord);

                List<WordInfo> listWordInfo = new List<WordInfo>();
                foreach (string word in CaptureObject.OCRWordList)
                {
                    listWordInfo.Add(new WordInfo() { Word = word, Selected = true });
                }
                CaptureObject.WordInfoList = new ObservableCollection<WordInfo>(listWordInfo);


                string textToPrint = OCR.ImageToText(Form1.capture, 0).Replace("\n", System.Environment.NewLine);
                //CaptureObject.CaptureImage = loadBitmap(Form1.capture);
                CaptureObject.CaptureImage = Form1.capture;

                //form1.Hide();
                CaptureObject.CaptureWindowState = System.Windows.WindowState.Normal;
                if (obj != null)
                {
                    Window wind = obj as Window;
                    //wind.WindowState = WindowState.Normal;
                    //wind.Show();
                    SystemCommands.RestoreWindow(wind);
                    Unminimize(wind);
                }

            }
            else
            {
                string ans = OCR.ImageToText(localImage, 0);
                string[] listSentence = ans.Split('\n');
                CaptureObject.OCRWordList = new ObservableCollection<string>(listSentence);

                string textToPrint = OCR.ImageToText(localImage, 0).Replace("\n", System.Environment.NewLine);
                //ScreenShot.Source = loadBitmap(localImage);
                CaptureObject.CaptureImage = Form1.capture;


                //form1.Hide();
                CaptureObject.CaptureWindowState = System.Windows.WindowState.Normal;

            }

        }

        public static void Unminimize(Window window)
        {
            var hwnd = (HwndSource.FromVisual(window) as HwndSource).Handle;
            ShowWindow(hwnd, ShowWindowCommands.Restore);
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        private enum ShowWindowCommands : int
        {
            /// <summary>
            /// Activates and displays the window. If the window is minimized or 
            /// maximized, the system restores it to its original size and position. 
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            Restore = 9,
        }

        public static BitmapSource loadBitmap(System.Drawing.Bitmap source)
        {
            IntPtr ip = source.GetHbitmap();
            BitmapSource bs = null;
            {
                bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip,
                   IntPtr.Zero, Int32Rect.Empty,
                   System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
            return bs;
        }

        private void SelectWord(object obj)
        {
            WordInfo wordInfo = obj as WordInfo;
            wordInfo.Selected = !wordInfo.Selected;
        }

        private void RightClickWord(object obj)
        {
            WordInfo wordInfo = obj as WordInfo;
            CaptureObject.WordInfoRightClick = wordInfo;
        }

        private void ProcessingOnFile()
        {
            //Bitmap localImage = null;
            //Bitmap localImage = CaptureObject.CaptureImage == null ? null : (Bitmap)CaptureObject.CaptureImage.Clone();
            Bitmap localImage = new Bitmap(CaptureObject.CaptureImage);

            if (localImage != null)
            {
                string ans = OCRCustom.ImageToText(localImage, 0);

                // get list of line text
                List<string> listSentence = ans.Split('\n').ToList();
                List<string> listSentenceProcessed = new List<string>() { "" };
                foreach (string _line in listSentence)
                {
                    string line = String.Join(" ", _line.Split());
                    List<string> listWord = new List<string>(line.Split());

                    listSentenceProcessed.AddRange(listWord);
                }
                //if (listSentenceProcessed.Count > 1)
                //    listSentenceProcessed.RemoveAt(0);

                CaptureObject.OCRWordList = new ObservableCollection<string>(listSentenceProcessed);
                bool[] selectedWord = new bool[listSentenceProcessed.Count];
                for (int i = 0; i < selectedWord.Length; i++) { selectedWord[i] = true; }
                CaptureObject.SelectedWord = new ObservableCollection<bool>(selectedWord);

                List<WordInfo> listWordInfo = new List<WordInfo>();
                foreach (string word in CaptureObject.OCRWordList)
                {
                    listWordInfo.Add(new WordInfo() { Word = word, Selected = true });
                }
                CaptureObject.WordInfoList = new ObservableCollection<WordInfo>(listWordInfo);


                string textToPrint = OCRCustom.ImageToText(localImage, 0).Replace("\n", System.Environment.NewLine);
                //CaptureObject.CaptureImage = loadBitmap(Form1.capture);
                CaptureObject.CaptureImage = localImage;

                //form1.Hide();
                CaptureObject.CaptureWindowState = System.Windows.WindowState.Normal;
            }
        }
    }
}
