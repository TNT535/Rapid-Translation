using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using RapidTranslationWPF_MVVM.Models;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class CaptureViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string CaptureString
        {
            get { return _exampleModel.ExampleCaptureString; }
            set { _exampleModel.ExampleCaptureString = value;OnPropertyChanged(); }
        }

        public CaptureViewModel()
        {
            _exampleModel = new ExampleModel();
            CaptureString = "capture user control window";
        }
    }
}
