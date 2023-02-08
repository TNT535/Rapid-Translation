﻿using RapidTranslationWPF_MVVM.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using RapidTranslationWPF_MVVM.Utilities;
using RapidTranslationWPF_MVVM.Models;

namespace RapidTranslationWPF_MVVM.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CaptureCommand { get; set; }
        public ICommand StatisticCommand { get; set; }
        public ICommand VocabularyCommand { get; set; }
        public ICommand TranslateSentenceCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void Capture(object obj) => CurrentView = new CaptureModeSelectionViewModel();
        //private void Capture(object obj) => CurrentView = new CaptureViewModel();
        private void Statistic(object obj) => CurrentView = new StatisticViewModel();
        private void Vocabulary(object obj) => CurrentView = new VocabularyViewModel();
        private void TranslateSentence(object obj) => CurrentView = new TranslationSentencePageViewModel();
        private void History(object obj) => CurrentView = new HistoryViewModel();
        private void Setting(object obj) => CurrentView = new SettingsViewModel();

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            CaptureCommand = new RelayCommand(Capture);
            StatisticCommand = new RelayCommand(Statistic);
            VocabularyCommand = new RelayCommand(Vocabulary);
            TranslateSentenceCommand = new RelayCommand(TranslateSentence);
            HistoryCommand = new RelayCommand(History);
            SettingsCommand = new RelayCommand(Setting);

            CaptureModeSelectCommand = new RelayCommand(CaptureModeSelect);
            CaptureImageModeCommand = new RelayCommand(ImageMode);
            SearchWordCaptureCommand = new RelayCommand(SearchWordCapture);

            // Startup Page
            CurrentView = new CaptureModeSelectionViewModel();
        }

        public ICommand CaptureModeSelectCommand { get; set; }
        public ICommand CaptureImageModeCommand { get; set; }
        public ICommand SearchWordCaptureCommand { get; set; }

        private void CaptureModeSelect(object obj) => CurrentView = new CaptureModeSelectionViewModel();
        private void ImageMode(object obj) => CurrentView = new CaptureProgressViewModel();
        private void SearchWordCapture(object obj) => CurrentView = new SearchWordCaptureViewModel();


        //Capture
        private Capture _captureObject = new Models.Capture();
        public Capture CaptureObject
        {
            get { return _captureObject; }
            set { _captureObject = value;OnPropertyChanged(); }
        }
    }

}
