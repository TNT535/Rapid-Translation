using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string SettingsString
        {
            get { return _exampleModel.ExampleSettingsString; }
            set { _exampleModel.ExampleSettingsString = value; OnPropertyChanged(); }
        }
        public SettingsViewModel()
        {
            _exampleModel = new ExampleModel();
            SettingsString = "settings user control window";
        }
    }
}
