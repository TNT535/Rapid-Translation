using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class VocabularyViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string VocabularyString
        {
            get { return _exampleModel.ExampleVocabularyString; }
            set { _exampleModel.ExampleVocabularyString = value; OnPropertyChanged(); }
        }
        public VocabularyViewModel()
        {
            _exampleModel = new ExampleModel();
            VocabularyString = "vocabulary user control window";
        }
    }
}
