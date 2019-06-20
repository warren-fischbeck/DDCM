using FischbeckEnterprises.XML.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Working
{

    partial class PrintablePlayerCharacter
    {

        public string CharacterName { get; set; }
        public string ClassLevel { get; set; }
        public string Background { get; set; }
        public string PlayerName { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public int ExperiencePoints { get; set; }


        public int ProficencyBonus { get; set; }
        public int Inspiration { get; set; }
        public int Strength { get; set; }
        public int StrengthModifier { get; set; }
        public int Dexterity { get; set; }
        public int DexterityModifier { get; set; }
        public int Constitution { get; set; }
        public int ConstitutionModifier { get; set; }
        public int Intelligence { get; set; }
        public int IntelligenceModifier { get; set; }
        public int Wisdom { get; set; }
        public int WisdomModifier { get; set; }
        public int Charisma { get; set; }
        public int CharismaModifier { get; set; }
        public int PassivePerception { get; set; }
        public bool SaveThrowStrength { get; set; }
        public int SaveThrowStrengthModifier { get; set; }
        public bool ExpertiseSaveThrowStrength { get; set; }
        public bool SaveThrowDexterity { get; set; }
        public int SaveThrowDexterityModifier { get; set; }
        public bool ExpertiseSaveThrowDexterity { get; set; }
        public bool SaveThrowConstitution { get; set; }
        public int SaveThrowConstitutionModifier { get; set; }
        public bool ExpertiseSaveThrowConstitution { get; set; }
        public bool SaveThrowIntelligence { get; set; }
        public int SaveThrowIntelligenceModifier { get; set; }
        public bool ExpertiseSaveThrowIntelligence { get; set; }
        public bool SaveThrowWisdom { get; set; }
        public int SavethrowWisdomModifier { get; set; }
        public bool ExpertiseSaveThrowWisdom { get; set; }
        public bool SaveThrowCharisma { get; set; }
        public int SaveThrowCharismaModifier { get; set; }
        public bool ExpertiseSaveThrowCharisma { get; set; }
        public bool ProficencyAcrobatics { get; set; }
        public int AcobaticsModifier { get; set; }
        public bool ExpertiseAcrobatics { get; set; }
        public bool ProficencyAnimalHandling { get; set; }
        public int AnimalHandlingModifier { get; set; }
        public bool ExpertiseAnimalHandling { get; set; }
        public bool ProficencyArcana { get; set; }
        public int ArcanaModifier { get; set; }
        public bool ExpertiseArcana { get; set; }
        public bool ProficencyAthletics { get; set; }
        public int AthleticsModifier { get; set; }
        public bool ExpertiseAthletics { get; set; }
        public bool ProficencyDeception { get; set; }
        public int DeceptionModifier { get; set; }
        public bool ExpertiseDeception { get; set; }
        public bool ProficencyHistory { get; set; }
        public int HistoryModifier { get; set; }
        public bool ExpertiseHistory { get; set; }
        public bool ProficencyInsight { get; set; }
        public int InsightModifier { get; set; }
        public bool ExpertiseInsight { get; set; }
        public bool ProficencyIntimidation { get; set; }
        public int IntimidationModifier { get; set; }
        public bool ExpertiseIntimidation { get; set; }
        public bool ProficencyInvestigation { get; set; }
        public int InvestigationModifier { get; set; }
        public bool ExpertiseInvestigation { get; set; }
        public bool ProficencyMedicine { get; set; }
        public int MedicineModifier { get; set; }
        public bool ExpertiseMedicine { get; set; }
        public bool ProficencyNature { get; set; }
        public int NatureModifier { get; set; }
        public bool ExpertiseNature { get; set; }
        public bool ProficencyPerception { get; set; }
        public int PerceptionModifer { get; set; }
        public bool ExpertisePerception { get; set; }
        public bool ProficencyPerformance { get; set; }
        public int PerformanceModifier { get; set; }
        public bool ExpertisePerformance { get; set; }
        public bool ProficencyPersuasion { get; set; }
        public int PersuasionModifier { get; set; }
        public bool ExpertisePersuasion { get; set; }
        public bool ProficencyReligion { get; set; }
        public int ReligionModifier { get; set; }
        public bool ExpertiseReligion { get; set; }
        public bool ProficencySlieghtOfHand { get; set; }
        public int SlieghtOfHandModifier { get; set; }
        public bool ExpertiseSlieghtOfHand { get; set; }
        public bool ProficencyStealth { get; set; }
        public int StealthModifier { get; set; }
        public bool ExpertiseStealth { get; set; }
        public bool ProficencySurvival { get; set; }
        public int SurvivalModifier { get; set; }
        public bool ExpertiseSurvival { get; set; }
        public int PassiveInititive { get; set; }
        public int PassiveInsight { get; set; }


        public int ArmorClass { get; set; }
        public int Inititive { get; set; }
        public int Speed { get; set; }
        public int HitPointMax { get; set; }
        public int HitPointCurrent { get; set; }
        public int HitPointTemperary { get; set; }
        public string HitDice { get; set; }
        public string HitDiceTotal { get; set; }
        public string WeaponName1 { get; set; }
        public string WeaponName2 { get; set; }
        public string WeaponName3 { get; set; }
        public string WeaponAttackBonus1 { get; set; }
        public string WeaponAttackBonus2 { get; set; }
        public string WeaponAttackBonus3 { get; set; }
        public string WeaponDamageAndType1 { get; set; }
        public string WeaponDamageAndType2 { get; set; }
        public string WeaponDamageAndType3 { get; set; }
        public string AttackAndSpellCasting { get; set; }


        public string PersonalityTraits { get; set; }
        public string PersonalityBonds { get; set; }
        public string PersonalityIdeals { get; set; }
        public string PersonalityFlaws { get; set; }
        public string FeaturesAndTraits1 { get; set; }

        public string ProficiencesAndLanguages { get; set; }
        public string Equipment1 { get; set; }

        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Eyes { get; set; }
        public string Skin { get; set; }
        public string Hair { get; set; }
        public string Allies { get; set; }
        public string FactionName { get; set; }
        public string BackStory { get; set; }
        public string FeatsAndTraits2 { get; set; }
        public string Equipment2 { get; set; }
        public List<SpellCasting> SpellCasting { get; set; }
        public string CharacterImageFilePath { get; set; }

        public PrintablePlayerCharacter() { this.SpellCasting = new List<SpellCasting>(); }

        public void BuildTest()
        {
            this.CharacterName = "Test Character";
            this.AcobaticsModifier = 1;
            this.Alignment = "Neutral Good";
            this.AnimalHandlingModifier = 2;
            this.ArcanaModifier = 3;
            this.ArmorClass = 15;
            this.AttackAndSpellCasting = "Attack and \nSpell Casting\nEven more information.  Lots of data.  Lots of data.  Lots of data";
            this.Background = "Background";
            this.Charisma = 10;
            this.CharismaModifier = 0;
            this.ClassLevel = "Bard(1) Fighter(10)";
            this.Constitution = 10;
            this.ConstitutionModifier = 6;
            this.ProficencyAthletics = true;
            this.AthleticsModifier = 15;
            this.Age = "15";
            this.Weight = "195 lbs";
            this.Equipment2 = "All kinds of things can go in here.";
            this.BackStory = "This is for all kinds of cool shit.";
        }
    }

}
