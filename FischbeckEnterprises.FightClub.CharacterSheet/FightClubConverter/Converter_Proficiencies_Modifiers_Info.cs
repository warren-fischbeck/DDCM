using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void GenerateSkillModifiers()
        {
            _printablePlayerCharacter.SaveThrowCharismaModifier = _printablePlayerCharacter.CharismaModifier;
            if (_printablePlayerCharacter.SaveThrowCharisma)
                _printablePlayerCharacter.SaveThrowCharismaModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowCharisma)
                _printablePlayerCharacter.SaveThrowCharismaModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SaveThrowConstitutionModifier = _printablePlayerCharacter.ConstitutionModifier;
            if (_printablePlayerCharacter.SaveThrowConstitution)
                _printablePlayerCharacter.SaveThrowConstitutionModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowConstitution)
                _printablePlayerCharacter.SaveThrowConstitutionModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SaveThrowDexterityModifier = _printablePlayerCharacter.DexterityModifier;
            if (_printablePlayerCharacter.SaveThrowDexterity)
                _printablePlayerCharacter.SaveThrowDexterityModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowDexterity)
                _printablePlayerCharacter.SaveThrowDexterityModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SaveThrowIntelligenceModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.SaveThrowIntelligence)
                _printablePlayerCharacter.SaveThrowIntelligenceModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowIntelligence)
                _printablePlayerCharacter.SaveThrowIntelligenceModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SaveThrowStrengthModifier = _printablePlayerCharacter.StrengthModifier;
            if (_printablePlayerCharacter.SaveThrowStrength)
                _printablePlayerCharacter.SaveThrowStrengthModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowStrength)
                _printablePlayerCharacter.SaveThrowStrengthModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SavethrowWisdomModifier = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.SaveThrowWisdom)
                _printablePlayerCharacter.SavethrowWisdomModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSaveThrowWisdom)
                _printablePlayerCharacter.SavethrowWisdomModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.AthleticsModifier = _printablePlayerCharacter.StrengthModifier;
            if (_printablePlayerCharacter.ProficencyAcrobatics)
                _printablePlayerCharacter.AthleticsModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseAthletics)
                _printablePlayerCharacter.AthleticsModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.AcobaticsModifier = _printablePlayerCharacter.DexterityModifier;
            if (_printablePlayerCharacter.ProficencyAcrobatics)
                _printablePlayerCharacter.AcobaticsModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseAcrobatics)
                _printablePlayerCharacter.AcobaticsModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.SlieghtOfHandModifier = _printablePlayerCharacter.DexterityModifier;
            if (_printablePlayerCharacter.ProficencySlieghtOfHand)
                _printablePlayerCharacter.SlieghtOfHandModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSlieghtOfHand)
                _printablePlayerCharacter.SlieghtOfHandModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.StealthModifier = _printablePlayerCharacter.DexterityModifier;
            if (_printablePlayerCharacter.ProficencyStealth)
                _printablePlayerCharacter.StealthModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseStealth)
                _printablePlayerCharacter.StealthModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.ArcanaModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.ProficencyArcana)
                _printablePlayerCharacter.ArcanaModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseArcana)
                _printablePlayerCharacter.ArcanaModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.HistoryModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.ProficencyHistory)
                _printablePlayerCharacter.HistoryModifier = _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseHistory)
                _printablePlayerCharacter.HistoryModifier = _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.InvestigationModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.ProficencyInvestigation)
                _printablePlayerCharacter.InvestigationModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseInvestigation)
                _printablePlayerCharacter.InvestigationModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.NatureModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.ProficencyNature)
                _printablePlayerCharacter.NatureModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseNature)
                _printablePlayerCharacter.NatureModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.ReligionModifier = _printablePlayerCharacter.IntelligenceModifier;
            if (_printablePlayerCharacter.ProficencyReligion)
                _printablePlayerCharacter.ReligionModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseReligion)
                _printablePlayerCharacter.ReligionModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.AnimalHandlingModifier = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.ProficencyAnimalHandling)
                _printablePlayerCharacter.AnimalHandlingModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseAnimalHandling)
                _printablePlayerCharacter.AnimalHandlingModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.InsightModifier = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.ProficencyInsight)
                _printablePlayerCharacter.InsightModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseInsight)
                _printablePlayerCharacter.InsightModifier += _printablePlayerCharacter.ProficencyBonus;
            _printablePlayerCharacter.PassiveInsight = _printablePlayerCharacter.InsightModifier + 10;

            _printablePlayerCharacter.MedicineModifier = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.ProficencyMedicine)
                _printablePlayerCharacter.MedicineModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseMedicine)
                _printablePlayerCharacter.MedicineModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.PerceptionModifer = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.ProficencyPerception)
                _printablePlayerCharacter.PerceptionModifer += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertisePerception)
                _printablePlayerCharacter.PerceptionModifer += _printablePlayerCharacter.ProficencyBonus;
            _printablePlayerCharacter.PassivePerception = _printablePlayerCharacter.PerceptionModifer + 10;

            _printablePlayerCharacter.SurvivalModifier = _printablePlayerCharacter.WisdomModifier;
            if (_printablePlayerCharacter.ProficencySurvival)
                _printablePlayerCharacter.SurvivalModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseSurvival)
                _printablePlayerCharacter.SurvivalModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.DeceptionModifier = _printablePlayerCharacter.CharismaModifier;
            if (_printablePlayerCharacter.ProficencyDeception)
                _printablePlayerCharacter.DeceptionModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseDeception)
                _printablePlayerCharacter.DeceptionModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.IntimidationModifier = _printablePlayerCharacter.CharismaModifier;
            if (_printablePlayerCharacter.ProficencyIntimidation)
                _printablePlayerCharacter.IntimidationModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertiseIntimidation)
                _printablePlayerCharacter.IntimidationModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.PerformanceModifier = _printablePlayerCharacter.CharismaModifier;
            if (_printablePlayerCharacter.ProficencyPerformance)
                _printablePlayerCharacter.PerformanceModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertisePerformance)
                _printablePlayerCharacter.PerformanceModifier += _printablePlayerCharacter.ProficencyBonus;

            _printablePlayerCharacter.PersuasionModifier = _printablePlayerCharacter.CharismaModifier;
            if (_printablePlayerCharacter.ProficencyPersuasion)
                _printablePlayerCharacter.PersuasionModifier += _printablePlayerCharacter.ProficencyBonus;
            if (_printablePlayerCharacter.ExpertisePersuasion)
                _printablePlayerCharacter.PersuasionModifier += _printablePlayerCharacter.ProficencyBonus;
        }
    }
}