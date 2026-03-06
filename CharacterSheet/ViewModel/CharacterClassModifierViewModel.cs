using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.ViewModel
{
    public class CharacterClassModifierViewModel : BaseViewModel
    {
        string _ModifierName = string.Empty;
        string _ModifierDescription = string.Empty;
        ModifierEnumViewModel _ModifierType = ModifierEnumViewModel.None;
        int _ModifierValue = 0;

        public string ModifierName
        {
            get => _ModifierName;
            set
            {
                if (_ModifierName == value) return;
                _ModifierName = value; OnPropertyChanged();
            }
        }
        public string ModifierDescription
        {
            get => _ModifierDescription;
            set
            {
                if (_ModifierDescription == value) return;
                _ModifierDescription = value; OnPropertyChanged();
            }
        }
        public ModifierEnumViewModel ModifierType
        {
            get => _ModifierType;
            set
            {
                if (_ModifierType == value) return;
                _ModifierType = value; OnPropertyChanged();
            }
        }
        public int ModifierValue
        {
            get => _ModifierValue;
            set
            {
                if (_ModifierValue == value) return;
                _ModifierValue = value; OnPropertyChanged();
            }
        }
    }
}
