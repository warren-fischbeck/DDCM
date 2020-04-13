using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Proficiencies()
        {
            GenerateProficienyBonus();
            List<int> ListofProficiencies = new List<int>();
            _pc.character.ForEach(e => e.race.proficiency.ToList().ForEach(a => ListofProficiencies.Add(a)));
            foreach(Character c in _pc.character)
            {
                List<int> _proficiencies = new List<int>();

                var feats = c.feat.Where(x => x.proficiency != null).Select(s => s.proficiency).ToList().FirstOrDefault();
                var classes = c.@class.Where(x => x.feat.Where(b => b.proficiency != null) != null).Select(s => s.proficiency).ToList().FirstOrDefault();
                
                if (feats != null)
                    _proficiencies.AddRange(feats);
                if (classes != null)
                    _proficiencies.AddRange(classes);
                if (c.race.proficiency != null)
                    _proficiencies.AddRange(c.race.proficiency);
                if (c.background.proficiency != null)
                    _proficiencies.AddRange(c.background.proficiency);

                foreach (int item in _proficiencies)
                {
                    switch (item)
                    {
                        case 0: { _printablePlayerCharacter.SaveThrowStrength = true; break; }
                        case 1: { _printablePlayerCharacter.SaveThrowDexterity = true; break; }
                        case 2: { _printablePlayerCharacter.SaveThrowConstitution = true; ; break; }
                        case 3: { _printablePlayerCharacter.SaveThrowIntelligence = true; break; }
                        case 4: { _printablePlayerCharacter.SaveThrowWisdom = true; break; }
                        case 5: { _printablePlayerCharacter.SaveThrowCharisma = true; break; }
                        case 100: { _printablePlayerCharacter.ProficencyAcrobatics = true; break; }
                        case 101: { _printablePlayerCharacter.ProficencyAnimalHandling = true; break; }
                        case 102: { _printablePlayerCharacter.ProficencyArcana = true; break; }
                        case 103: { _printablePlayerCharacter.ProficencyAthletics = true; break; }
                        case 104: { _printablePlayerCharacter.ProficencyDeception = true; break; }
                        case 105: { _printablePlayerCharacter.ProficencyHistory = true; break; }
                        case 106: { _printablePlayerCharacter.ProficencyInsight = true; break; }
                        case 107: { _printablePlayerCharacter.ProficencyIntimidation = true; break; }
                        case 108: { _printablePlayerCharacter.ProficencyInvestigation = true; break; }
                        case 109: { _printablePlayerCharacter.ProficencyMedicine = true; break; }
                        case 110: { _printablePlayerCharacter.ProficencyNature = true; break; }
                        case 111: { _printablePlayerCharacter.ProficencyPerception = true; break; }
                        case 112: { _printablePlayerCharacter.ProficencyPerformance = true; break; }
                        case 113: { _printablePlayerCharacter.ProficencyPersuasion = true; break; }
                        case 114: { _printablePlayerCharacter.ProficencyReligion = true; break; }
                        case 115: { _printablePlayerCharacter.ProficencySlieghtOfHand = true; break; }
                        case 116: { _printablePlayerCharacter.ProficencyStealth = true; break; }
                        case 117: { _printablePlayerCharacter.ProficencySurvival = true; break; }
                        default: break;
                    }
                }
            }
            GenerateSkillModifiers();
        }

        private void GenerateProficienyBonus()
        {
            int _level = 0;
            int _XP = _printablePlayerCharacter.ExperiencePoints;
            int _proficencyBonus;
            switch (_XP)
            {
                case int n when (_XP > 0 && _XP <= 299): _level = 1; _proficencyBonus = 2; break;
                case int n when (_XP > 300 && _XP <= 899): _level = 2; _proficencyBonus = 2; break;
                case int n when (_XP > 900 && _XP <= 2799): _level = 3; _proficencyBonus = 2; break;
                case int n when (_XP > 2700 && _XP <= 6499): _level = 4; _proficencyBonus = 2; break;
                case int n when (_XP > 6500 && _XP <= 13999): _level = 5; _proficencyBonus = 3; break;
                case int n when (_XP > 14000 && _XP <= 22999): _level = 6; _proficencyBonus = 3; break;
                case int n when (_XP > 23000 && _XP <= 33999): _level = 7; _proficencyBonus = 3; break;
                case int n when (_XP > 34000 && _XP <= 47999): _level = 8; _proficencyBonus = 3; break;
                case int n when (_XP > 48000 && _XP <= 63999): _level = 9; _proficencyBonus = 4; break;
                case int n when (_XP > 64000 && _XP <= 84999): _level = 10; _proficencyBonus = 4; break;
                case int n when (_XP > 85000 && _XP <= 99999): _level = 11; _proficencyBonus = 4; break;
                case int n when (_XP > 100000 && _XP <= 119999): _level = 12; _proficencyBonus = 4; break;
                case int n when (_XP > 120000 && _XP <= 139999): _level = 13; _proficencyBonus = 5; break;
                case int n when (_XP > 140000 && _XP <= 164999): _level = 14; _proficencyBonus = 5; break;
                case int n when (_XP > 165000 && _XP <= 194999): _level = 15; _proficencyBonus = 5; break;
                case int n when (_XP > 195000 && _XP <= 224999): _level = 16; _proficencyBonus = 5; break;
                case int n when (_XP > 225000 && _XP <= 164999): _level = 17; _proficencyBonus = 6; break;
                case int n when (_XP > 265000 && _XP <= 304999): _level = 18; _proficencyBonus = 6; break;
                case int n when (_XP > 305000 && _XP <= 354999): _level = 19; _proficencyBonus = 6; break;
                case int n when (_XP > 355000): _level = 20; _proficencyBonus = 6; break;
                default: _level = 0; _proficencyBonus = 2; break;
            }
            _printablePlayerCharacter.ProficencyBonus = _proficencyBonus;
        }
    }
}
