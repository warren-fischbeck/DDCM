using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.Mobile.DND.Models
{
    internal partial class Core
    {
        public string CharacterName { get; set; }
        public string CharacterLevel { get; set; }
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
        public string FactionImageFilePath { get; set; }

        public Core()
        {
            this.AcobaticsModifier = 0;
            this.Age = "0";
            this.Alignment = "LG";
            this.Allies = "";
            this.AnimalHandlingModifier = 0;
            this.ArcanaModifier = 0;
            this.ArmorClass = 10;
            this.AthleticsModifier = 0;
            this.AttackAndSpellCasting = "";
            this.Background = "";
            this.BackStory = "";
            this.CharacterImageFilePath = "";
            this.CharacterName = "";
            this.Charisma = 0;
            this.CharismaModifier = 0;
            this.ClassLevel = "0";
            this.Constitution = 0;
            this.ConstitutionModifier = 0;
            this.DeceptionModifier = 0;
            this.Dexterity = 0;
            this.DexterityModifier = 0;
            this.Equipment1 = "";
            this.Equipment2 = "";
            this.ExperiencePoints = 0;
            this.ExpertiseAcrobatics = false;
            this.ExpertiseAnimalHandling = false;
            this.ExpertiseArcana = false;
            this.ExpertiseAthletics = false;
            this.ExpertiseDeception = false;
            this.ExpertiseHistory = false;
            this.ExpertiseInsight = false;
            this.ExpertiseIntimidation = false;
            this.ExpertiseInvestigation = false;
            this.ExpertiseMedicine = false;
            this.ExpertiseNature = false;
            this.ExpertisePerception = false;
            this.ExpertisePerformance = false;
            this.ExpertisePersuasion = false;
            this.ExpertiseReligion = false;
            this.ExpertiseSaveThrowCharisma = false;
            this.ExpertiseSaveThrowConstitution = false;
            this.ExpertiseSaveThrowDexterity = false;
            this.ExpertiseSaveThrowIntelligence = false;
            this.ExpertiseSaveThrowStrength = false;
            this.ExpertiseSaveThrowWisdom = false;
            this.ExpertiseSlieghtOfHand = false;
            this.ExpertiseStealth = false;
            this.ExpertiseSurvival = false;
            this.Eyes = "";
            this.FactionName = "";
            this.FeatsAndTraits2 = "";
            this.FeaturesAndTraits1 = "";
            this.Hair = "";
            this.Height = "";
            this.HistoryModifier = 0;
            this.HitDice = "0";
            this.HitDiceTotal = "0";
            this.HitPointCurrent = 0;
            this.HitPointMax = 0;
            this.HitPointTemperary = 0;
            this.Inititive = 0;
            this.InsightModifier = 0;
            this.Inspiration = 0;
            this.Intelligence = 0;
            this.IntelligenceModifier = 0;
            this.IntimidationModifier = 0;
            this.InvestigationModifier = 0;
            this.MedicineModifier = 0;
            this.NatureModifier = 0;
            this.PassiveInititive = 0;
            this.PassiveInsight = 0;
            this.PassivePerception = 0;
            this.PerceptionModifer = 0;
            this.PerformanceModifier = 0;
            this.PersonalityBonds = "";
            this.PersonalityFlaws = "";
            this.PersonalityIdeals = "";
            this.PersonalityTraits = "";
            this.PersuasionModifier = 0;
            this.PlayerName = "";
            this.ProficencyAcrobatics = false;
            this.ProficencyAnimalHandling = false;
            this.ProficencyArcana = false;
            this.ProficencyAthletics = false;
            this.ProficencyBonus = 0;
            this.ProficencyDeception = false;
            this.ProficencyHistory = false;
            this.ProficencyInsight = false;
            this.ProficencyIntimidation = false;
            this.ProficencyInvestigation = false;
            this.ProficencyMedicine = false;
            this.ProficencyNature = false;
            this.ProficencyPerception = false;
            this.ProficencyPerformance = false;
            this.ProficencyPersuasion = false;
            this.ProficencyReligion = false;
            this.ProficencySlieghtOfHand = false;
            this.ProficencyStealth = false;
            this.ProficencySurvival = false;
            this.ProficiencesAndLanguages = "";
            this.Race = "N";
            this.ReligionModifier = 0;
            this.SaveThrowCharisma = false;
            this.SaveThrowCharismaModifier = 0;
            this.SaveThrowConstitution = false;
            this.SaveThrowConstitutionModifier = 0;
            this.SaveThrowDexterity = false;
            this.SaveThrowDexterityModifier = 0;
            this.SaveThrowIntelligence = false;
            this.SaveThrowIntelligenceModifier = 0;
            this.SaveThrowStrength = false;
            this.SaveThrowStrengthModifier = 0;
            this.SaveThrowWisdom = false;
            this.SavethrowWisdomModifier = 0;
            this.Skin = "";
            this.SlieghtOfHandModifier = 0;
            this.Speed = 0;
            this.StealthModifier = 0;
            this.Strength = 0;
            this.StrengthModifier = 0;
            this.SurvivalModifier = 0;
            this.WeaponAttackBonus1 = "";
            this.WeaponAttackBonus2 = "";
            this.WeaponAttackBonus3 = "";
            this.WeaponDamageAndType1 = "";
            this.WeaponDamageAndType2 = "";
            this.WeaponDamageAndType3 = "";
            this.WeaponName1 = "";
            this.WeaponName2 = "";
            this.WeaponName3 = "";
            this.Weight = "";
            this.Wisdom = 0;
            this.WisdomModifier = 0;
            this.SpellCasting = new List<SpellCasting>();
        }
    }
    internal partial class SpellCasting
    {
        public string SpellCastingClass { get; set; }
        public string AbilityScore { get; set; }
        public int SpellAttachBonus { get; set; }
        public int SpellDC { get; set; }
        public List<Spell> SpellsKnown { get; set; }
        public int CantripsKnown { get; set; }
        public int _1stLevelSlots { get; set; }
        public int _2ndLevelSlots { get; set; }
        public int _3rdLevelSlots { get; set; }
        public int _4thLevelSlots { get; set; }
        public int _5thLevelSlots { get; set; }
        public int _6thLevelSlots { get; set; }
        public int _7thLevelSlots { get; set; }
        public int _8thLevelSlots { get; set; }
        public int _9thLevelSlots { get; set; }
        public int _10thLevelSlots { get; set; }
        public int SpellsPrepaired { get; set; }

        public SpellCasting()
        {
            this.SpellsKnown = new List<Spell>();
        }
    }

    internal partial class Spell
    {
        public bool prepared { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public School School { get; set; }
        public bool Ritual { get; set; }
        public string Time { get; set; }
        public string Range { get; set; }
        public List<Component> Component { get; set; }
        public string MaterialComponent { get; set; }
        public string Duration { get; set; }
        public string Text { get; set; }
        public Dice[] Roll { get; set; }
        public List<string> Class { get; set; }
    }

    public enum Attribute
    {
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
    }

    public enum School
    { A = 1, C, D, EN, EV, I, N, T }

    public enum ItemType
    { LA, MA, HA, S, M, R, A, RD, ST, WD, RG, P, SC, W, G, MO }

    public enum DamageType
    { P, S, B }

    public enum ItemProperty
    {
        A, F, H, L, LD, R, S, T, HH, V, M
    }

    public enum Dice
    {
        d0, d4, d6, d8, d10, d12, d20, d100
    }

    public enum Component
    {
        V = 1, S, M
    }

}
