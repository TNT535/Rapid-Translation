using RapidTranslationWPF_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {
        private readonly ExampleModel _exampleModel;
        public string UserInfoString
        {
            get { return _exampleModel.ExampleUserInfoString; }
            set { _exampleModel.ExampleUserInfoString = value; OnPropertyChanged(); }
        }
        public UserInfoViewModel()
        {
            _exampleModel = new ExampleModel();
            UserInfoString = "vm: user info user control window";
            UserInfoObj = new UserInfo();
        }

        private UserInfo _userInfoObj = new UserInfo();
        public UserInfo UserInfoObj
        {
            get
            {
                { return _userInfoObj; }
            }
            set
            {
                { _userInfoObj = value; OnPropertyChanged(); }
            }

        }
    }
}
