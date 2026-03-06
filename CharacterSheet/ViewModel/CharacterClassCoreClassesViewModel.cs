using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.ViewModel
{
    public class CharacterClassCoreClassesViewModel : BaseViewModel
    {
        string _ClassPrimaryAbility = string.Empty;
        string _ClassHitPointDie = string.Empty;
        string _ClassSavingThrowProficiencies = string.Empty;
        string _SkillProficiencies = string.Empty;
        string _WeaponProficienceies = string.Empty;
        string _ArmorTraining = string.Empty;
        string _StartingEquipment = string.Empty;
        string _BecomingFirstLevel = string.Empty;
        string _BecomingMultiClass = string.Empty;

        public string ClassPrimaryAbility
        {
            get => _ClassHitPointDie;
            set
            {
                if (_ClassPrimaryAbility == value) return;
                _ClassPrimaryAbility = value; OnPropertyChanged();
            }
        }
        public string ClassHitPointDie
        {
            get => _ClassHitPointDie;
            set
            {
                if (_ClassHitPointDie == value) return;
                _ClassHitPointDie = value; OnPropertyChanged();
            }
        }
        public string ClassSavingThrowProficiencies
        {
            get => _ClassSavingThrowProficiencies;
            set
            {
                if (_ClassSavingThrowProficiencies == value) return;
                _ClassSavingThrowProficiencies = value; OnPropertyChanged();
            }
        }
        public string SkillProficiencies
        {
            get => _SkillProficiencies;
            set
            {
                if (_SkillProficiencies == value) return;
                _SkillProficiencies = value; OnPropertyChanged();
            }
        }
        public string WeaponProficienceis
        {
            get => _WeaponProficienceies; set
            {
                if (_WeaponProficienceies == value) return;
                _WeaponProficienceies = value; OnPropertyChanged();
            }
        }
        public string ArmorTraining
        {
            get => _ArmorTraining;
            set
            {
                if (_ArmorTraining == value) return;
                _ArmorTraining = value; OnPropertyChanged();
            }
        }
        public string StartingEquipment
        {
            get => _StartingEquipment;
            set
            {
                if (_StartingEquipment == value) return;
                _StartingEquipment = value; OnPropertyChanged();
            }
        }
        public string BecomingFirstLevel
        {
            get => _BecomingFirstLevel; set
            {
                if (_BecomingFirstLevel == value) return;
                _BecomingFirstLevel = value; OnPropertyChanged();
            }
        }
        public string BecomingMultiClass
        {
            get => _BecomingMultiClass; set
            {
                if (_BecomingMultiClass == value) return;
                _BecomingMultiClass = value; OnPropertyChanged();
            }
        }
    }
}