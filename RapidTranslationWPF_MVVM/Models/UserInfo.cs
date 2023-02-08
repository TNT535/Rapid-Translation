using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidTranslationWPF_MVVM.Models
{
    public class UserInfo : ObservableObject
    {
        private static string _Name = "Default name";
        private static string _surName = "";
        private static string _Patronimic = "";
        private static DateTime _DateOfBirth = DateTime.Now;
        private static string _gender = "not detected";
        private static string _education = "";
        private static string _description = "";

        private static Bitmap _avatar = new Bitmap(@"Image\avatar.png");

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged("Name"); }
        }
        public string SurName
        {
            get { return _surName; }
            set { _surName = value; RaisePropertyChanged("SurName"); }
        }
        public string Patronimic
        {
            get { return _Patronimic; }
            set { _Patronimic = value; RaisePropertyChanged("Patronimic"); }
        }
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; RaisePropertyChanged("DateOfBirth"); }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; RaisePropertyChanged("Gender"); }
        }

        public string Education
        {
            get { return _education; }
            set { _education = value; RaisePropertyChanged("Education"); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        public Bitmap Avatar
        {
            get { return _avatar; }
            set { _avatar = value; RaisePropertyChanged("Avatar"); }
        }
    }
}
