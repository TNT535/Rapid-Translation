using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RapidTranslationWPF_MVVM.Models
{
    public class Capture : ObservableObject
    {
        private static string _captureMode = "mode selection";
        public string CaptureMode
        {
            get { return _captureMode; }
            set
            {
                _captureMode = value;
                RaisePropertyChanged("CaptureMode");
            }
        }

        private static ObservableCollection<string> _OCRWordList = new ObservableCollection<string>(new List<string> { "test1", "test2", "test3" });
        public ObservableCollection<string> OCRWordList
        {
            get { return _OCRWordList; }
            set
            {
                _OCRWordList = value;
                RaisePropertyChanged("OCRWordList");
            }
        }
        
        private static ObservableCollection<bool> _selectedWord = new ObservableCollection<bool>(new List<bool> { true, true , false});
        public ObservableCollection<bool> SelectedWord
        {
            get { return _selectedWord; }
            set
            {
                _selectedWord = value;
                RaisePropertyChanged("SelectedWord");
            }
        }

        private static ObservableCollection<WordInfo> _wordInfoList = new ObservableCollection<WordInfo>(new List<WordInfo> { new WordInfo { Word = "test1", Selected = true }, new WordInfo { Word = "test2", Selected = true }, new WordInfo { Word = "test3", Selected = false } });
        public ObservableCollection<WordInfo> WordInfoList
        {
            get { return _wordInfoList; }
            set
            {
                _wordInfoList = value;
                RaisePropertyChanged("WordInfoList");
            }
        }

        private static Bitmap _captureImage = new Bitmap(@"\Test_Img_RT_Application.png");
        public Bitmap CaptureImage
        {
            get { return _captureImage; }
            set
            {
                _captureImage = value;
                RaisePropertyChanged("CaptureImage");
            }
        }
        
        private static WindowState _captureWindowState = WindowState.Normal;
        public WindowState CaptureWindowState
        {
            get { return _captureWindowState; }
            set
            {
                _captureWindowState = value;
                RaisePropertyChanged("WindowState");
            }
        }
    }

}
