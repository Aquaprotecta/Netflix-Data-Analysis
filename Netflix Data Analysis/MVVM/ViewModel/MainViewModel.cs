using System;
using Netflix_Data_Analysis.Core;

namespace Netflix_Data_Analysis.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public SettingsViewModel SettingsVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel() 
        {
            HomeVm = new HomeViewModel();
            SettingsVm = new SettingsViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVm;
            });
        }
    }
}
