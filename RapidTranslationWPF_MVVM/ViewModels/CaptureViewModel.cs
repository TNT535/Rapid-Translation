using RapidTranslationWPF_MVVM.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using RapidTranslationWPF_MVVM.Utilities;
using RapidTranslationWPF_MVVM.Models;
using System.Collections.ObjectModel;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class CaptureViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string CaptureString
        {
            get { return _exampleModel.ExampleCaptureString; }
            set { _exampleModel.ExampleCaptureString = value; OnPropertyChanged(); }
        }

        public CaptureViewModel()
        {
            _exampleModel = new ExampleModel();
            CaptureString = "capture user control window";
        }
    }
}
