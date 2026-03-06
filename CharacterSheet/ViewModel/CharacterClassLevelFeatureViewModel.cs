using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.ViewModel
{
    public class CharacterClassLevelFeatureViewModel : BaseViewModel
    {
        int _ClassFeatureLevel = 0;
        CharacterClassModifierViewModel? _ClassLevelModifier = null;
        string _ClassLevelFeatureName = string.Empty;
        string _ClassLevelFeatureDescription = string.Empty;

        public int ClassFeatureLevel
        {
            get => _ClassFeatureLevel;
            set
            {
                if (_ClassFeatureLevel == value) return;
                _ClassFeatureLevel = value; OnPropertyChanged();
            }
        }
        public CharacterClassModifierViewModel? ClassLevelModifier
        {
            get
            {
                if (_ClassLevelModifier != null) { return _ClassLevelModifier; }
                else { return null; }
            }
            set
            {
                if (_ClassLevelModifier == value) return;
                _ClassLevelModifier = value; OnPropertyChanged();
            }
        }
        public string ClassLevelFeatureName
        {
            get => _ClassLevelFeatureName;
            set
            {
                if (_ClassLevelFeatureName == value) return;
                _ClassLevelFeatureName = value; OnPropertyChanged();
            }
        }
        public string ClassLevelFeatureDescription
        {
            get => _ClassLevelFeatureDescription;
            set
            {
                if (_ClassLevelFeatureDescription == value) return;
                _ClassLevelFeatureDescription = value; OnPropertyChanged();
            }
        }
    }
}