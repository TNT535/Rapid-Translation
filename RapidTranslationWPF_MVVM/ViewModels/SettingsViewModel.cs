using RapidTranslationWPF_MVVM.Models;
using RapidTranslationWPF_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

            SaveInfoCommand = new RelayCommand(SaveInfo);
            UserInfo.Name = "test name 2";
            UserInfo.Gender = "Male";
        }

        private UserInfo _userInfo = new UserInfo() { Name="test name", Gender="Female"};
        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; OnPropertyChanged(); }
        }

        public ICommand SaveInfoCommand { get; set; }
        
        private void SaveInfo(object obj)
        {
            
        }
    }
}
