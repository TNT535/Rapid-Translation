using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string HomeString
        {
            get { return _exampleModel.ExampleHomeString; }
            set { _exampleModel.ExampleHomeString = value; OnPropertyChanged(); }
        }
        public HomeViewModel()
        {
            _exampleModel = new ExampleModel();
            HomeString = "home user control window";
        }
    }
}
