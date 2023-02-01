using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class StatisticViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string StatisticString
        {
            get { return _exampleModel.ExampleStatisticString; }
            set { _exampleModel.ExampleStatisticString = value; OnPropertyChanged(); }
        }
        public StatisticViewModel()
        {
            _exampleModel = new ExampleModel();
            StatisticString = "statistic user control window";
        }
    }
}
