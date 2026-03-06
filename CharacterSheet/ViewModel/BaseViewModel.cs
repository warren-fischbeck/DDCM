using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool _IsBusy;
        string _Title = string.Empty;

        public bool IsBusy
        {
            get => _IsBusy;
            set
            {
                if (_IsBusy == value) return;
                _IsBusy = value; OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _Title;
            set
            {
                if (_Title == value) return;
                _Title = value; OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}