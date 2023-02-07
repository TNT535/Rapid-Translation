using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public HistoryViewModel()
        {
            GetFullInfomationCommand = new RelayCommand(GetFullInformation);
            //ListWordHistoryObj.SaveToFile();
            ListWordHistoryObj.LoadFromFile();
        }

        private static ListWordHistory _listWordHistoryObj = new ListWordHistory();
        public ListWordHistory ListWordHistoryObj
        {
            get { return _listWordHistoryObj; }
            set { _listWordHistoryObj = value; OnPropertyChanged(); }
        }

        public ICommand GetFullInfomationCommand { get; set; }

        private void GetFullInformation(object obj)
        {

        }
    }
}
