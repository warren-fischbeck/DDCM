using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    class Converter
    {
        private pc _pc;
        public PrintablePlayerCharacter PrintablePlayerCharacter { get; private set; }
        public Converter()
        {
            this._pc = new pc();
            this.PrintablePlayerCharacter = new PrintablePlayerCharacter();
        }

        public Converter(pc PC)
        {
            if (PC.character != null)
                this._pc = PC;
            else
                this._pc = new pc();
            this.PrintablePlayerCharacter = new PrintablePlayerCharacter();

            _Build();
        }

        private void _Build()
        {
            ConvertBasicInfo();
        }

        public PrintablePlayerCharacter Build(pc PC)
        {
            if (PC.character != null)
                this._pc = PC;
            else
                this._pc = new pc();
            _Build();
            return PrintablePlayerCharacter;
        }

        private void ConvertBasicInfo()
        {
            if (this._pc.character.Length >= 0)
            {
                foreach (pcCharacter pcCharacter in this._pc.character)
                {
                    if (pcCharacter.name != null)
                    {
                        PrintablePlayerCharacter.CharacterName = pcCharacter.name;
                    }
                    if (pcCharacter.hpMax >= 0)
                        PrintablePlayerCharacter.HitPointMax = pcCharacter.hpMax;
                    if (pcCharacter.hpCurrent == pcCharacter.hpMax)
                        PrintablePlayerCharacter.HitPointCurrent = pcCharacter.hpCurrent;
                    if (pcCharacter.xp >= 0)
                        PrintablePlayerCharacter.ExperiencePoints = Convert.ToInt32(pcCharacter.xp);
                    if (pcCharacter.abilities != null)
                    {
                        string[] ability = pcCharacter.abilities.Split(',');
                        PrintablePlayerCharacter.Strength = Convert.ToInt32(ability[0]);
                        PrintablePlayerCharacter.StrengthModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Strength);
                        PrintablePlayerCharacter.Dexterity = Convert.ToInt32(ability[1]);
                        PrintablePlayerCharacter.DexterityModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Dexterity);
                        PrintablePlayerCharacter.Constitution = Convert.ToInt32(ability[2]);
                        PrintablePlayerCharacter.ConstitutionModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Constitution);
                        PrintablePlayerCharacter.Intelligence = Convert.ToInt32(ability[3]);
                        PrintablePlayerCharacter.IntelligenceModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Intelligence);
                        PrintablePlayerCharacter.Wisdom = Convert.ToInt32(ability[4]);
                        PrintablePlayerCharacter.WisdomModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Wisdom);
                        PrintablePlayerCharacter.Charisma = Convert.ToInt32(ability[5]);
                        PrintablePlayerCharacter.CharismaModifier = ConvertAbilitiyModifier(PrintablePlayerCharacter.Charisma);
                    }
                    if (pcCharacter.race.speed == 0)
                        PrintablePlayerCharacter.Speed = 30;
                    else
                        PrintablePlayerCharacter.Speed = pcCharacter.race.speed;
                    if (pcCharacter.race.name != null)
                        PrintablePlayerCharacter.Race = pcCharacter.race.name;
                    if (pcCharacter.race.hair != null)
                        PrintablePlayerCharacter.Hair = pcCharacter.race.hair;
                    if (pcCharacter.race.eyes != null)
                        PrintablePlayerCharacter.Eyes = pcCharacter.race.eyes;
                    if (pcCharacter.race.age != null)
                        PrintablePlayerCharacter.Age = pcCharacter.race.age;
                    if (pcCharacter.race.weight != null)
                        PrintablePlayerCharacter.Weight = pcCharacter.race.weight;
                    if (pcCharacter.race.height != null)
                        PrintablePlayerCharacter.Height = pcCharacter.race.height;
                    if (pcCharacter.race.skin != null)
                        PrintablePlayerCharacter.Skin = pcCharacter.race.skin;
                    if (pcCharacter.background.name != null)
                        PrintablePlayerCharacter.Background = pcCharacter.background.name;
                    if (pcCharacter.background.align != null)
                        PrintablePlayerCharacter.Alignment = pcCharacter.background.align;
                    if (pcCharacter.background.bonds != null)
                        PrintablePlayerCharacter.PersonalityBonds = pcCharacter.background.bonds;
                    if (pcCharacter.background.faction != null)
                        PrintablePlayerCharacter.FactionName = pcCharacter.background.faction;
                    if (pcCharacter.background.flaws != null)
                        PrintablePlayerCharacter.PersonalityFlaws = pcCharacter.background.flaws;
                    if (pcCharacter.background.ideals != null)
                        PrintablePlayerCharacter.PersonalityIdeals = pcCharacter.background.ideals;
                    if (pcCharacter.background.personality != null)
                        PrintablePlayerCharacter.PersonalityTraits = pcCharacter.background.personality;
                    ConvertSkills(pcCharacter);
                }
            }
        }

        private int ConvertAbilitiyModifier (int Score)
        {
                return (Score - 10) / 2;
        }

        private void ConvertSkills(pcCharacter pcCharacter)
        {
            List<byte> Skill = new List<byte>();
            foreach (byte _skill in pcCharacter.race.proficiency)
            {
                Skill.Add(_skill);
            }
            foreach(byte _skill in pcCharacter.background.proficiency)
            {
                Skill.Add(_skill);
            }
            foreach(pcCharacterClass pcCharacterClass in pcCharacter.@class)
            {
                foreach(byte _skill in pcCharacterClass.proficiency)
                {
                    Skill.Add(_skill);
                }
            }
            foreach(byte _skill in Skill)
            {
                switch (_skill)
                {
                    case 0: { PrintablePlayerCharacter.SaveThrowStrength = true; break; }
                    case 1: { PrintablePlayerCharacter.SaveThrowDexterity = true; break; }
                    case 2: { PrintablePlayerCharacter.SaveThrowConstitution = true; ; break; }
                    case 3: { PrintablePlayerCharacter.SaveThrowIntelligence = true; break; }
                    case 4: { PrintablePlayerCharacter.SaveThrowWisdom = true; break; }
                    case 5: { PrintablePlayerCharacter.SaveThrowCharisma = true; break; }
                    case 100: { PrintablePlayerCharacter.ProficencyAcrobatics = true; break; }
                    case 101: { PrintablePlayerCharacter.ProficencyAnimalHandling = true; break; }
                    case 102: { PrintablePlayerCharacter.ProficencyArcana = true; break; }
                    case 103: { PrintablePlayerCharacter.ProficencyAthletics = true; break; }
                    case 104: { PrintablePlayerCharacter.ProficencyDeception = true; break; }
                    case 105: { PrintablePlayerCharacter.ProficencyHistory = true; break; }
                    case 106: { PrintablePlayerCharacter.ProficencyInsight = true; break; }
                    case 107: { PrintablePlayerCharacter.ProficencyIntimidation = true; break; }
                    case 108: { PrintablePlayerCharacter.ProficencyInvestigation = true; break; }
                    case 109: { PrintablePlayerCharacter.ProficencyMedicine = true; break; }
                    case 110: { PrintablePlayerCharacter.ProficencyNature = true; break; }
                    case 111: { PrintablePlayerCharacter.ProficencyPerception = true; break; }
                    case 112: { PrintablePlayerCharacter.ProficencyPerformance = true; break; }
                    case 113: { PrintablePlayerCharacter.ProficencyPersuasion = true; break; }
                    case 114: { PrintablePlayerCharacter.ProficencyReligion = true; break; }
                    case 115: { PrintablePlayerCharacter.ProficencySlieghtOfHand = true; break; }
                    case 116: { PrintablePlayerCharacter.ProficencyStealth = true; break; }
                    case 117: { PrintablePlayerCharacter.ProficencySurvival = true; break; }
                    default:{
                    break; }
                }
            }
        }

        private void GenerateSkillModifiers()
        {
             PrintablePlayerCharacter.SaveThrowCharismaModifier =  PrintablePlayerCharacter.CharismaModifier;
            if ( PrintablePlayerCharacter.SaveThrowCharisma)
                 PrintablePlayerCharacter.SaveThrowCharismaModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowCharisma)
                 PrintablePlayerCharacter.SaveThrowCharismaModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SaveThrowConstitutionModifier =  PrintablePlayerCharacter.ConstitutionModifier;
            if ( PrintablePlayerCharacter.SaveThrowConstitution)
                 PrintablePlayerCharacter.SaveThrowConstitutionModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowConstitution)
                 PrintablePlayerCharacter.SaveThrowConstitutionModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SaveThrowDexterityModifier =  PrintablePlayerCharacter.DexterityModifier;
            if ( PrintablePlayerCharacter.SaveThrowDexterity)
                 PrintablePlayerCharacter.SaveThrowDexterityModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowDexterity)
                 PrintablePlayerCharacter.SaveThrowDexterityModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SaveThrowIntelligenceModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.SaveThrowIntelligence)
                 PrintablePlayerCharacter.SaveThrowIntelligenceModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowIntelligence)
                 PrintablePlayerCharacter.SaveThrowIntelligenceModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SaveThrowStrengthModifier =  PrintablePlayerCharacter.StrengthModifier;
            if ( PrintablePlayerCharacter.SaveThrowStrength)
                 PrintablePlayerCharacter.SaveThrowStrengthModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowStrength)
                 PrintablePlayerCharacter.SaveThrowStrengthModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SavethrowWisdomModifier =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.SaveThrowWisdom)
                 PrintablePlayerCharacter.SavethrowWisdomModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSaveThrowWisdom)
                 PrintablePlayerCharacter.SavethrowWisdomModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.AthleticsModifier =  PrintablePlayerCharacter.StrengthModifier;
            if ( PrintablePlayerCharacter.ProficencyAcrobatics)
                 PrintablePlayerCharacter.AthleticsModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseAthletics)
                 PrintablePlayerCharacter.AthleticsModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.AcobaticsModifier =  PrintablePlayerCharacter.DexterityModifier;
            if ( PrintablePlayerCharacter.ProficencyAcrobatics)
                 PrintablePlayerCharacter.AcobaticsModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseAcrobatics)
                 PrintablePlayerCharacter.AcobaticsModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SlieghtOfHandModifier =  PrintablePlayerCharacter.DexterityModifier;
            if ( PrintablePlayerCharacter.ProficencySlieghtOfHand)
                 PrintablePlayerCharacter.SlieghtOfHandModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSlieghtOfHand)
                 PrintablePlayerCharacter.SlieghtOfHandModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.StealthModifier =  PrintablePlayerCharacter.DexterityModifier;
            if ( PrintablePlayerCharacter.ProficencyStealth)
                 PrintablePlayerCharacter.StealthModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseStealth)
                 PrintablePlayerCharacter.StealthModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.ArcanaModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.ProficencyArcana)
                 PrintablePlayerCharacter.ArcanaModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseArcana)
                 PrintablePlayerCharacter.ArcanaModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.HistoryModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.ProficencyHistory)
                 PrintablePlayerCharacter.HistoryModifier =  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseHistory)
                 PrintablePlayerCharacter.HistoryModifier =  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.InvestigationModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.ProficencyInvestigation)
                 PrintablePlayerCharacter.InvestigationModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseInvestigation)
                 PrintablePlayerCharacter.InvestigationModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.NatureModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.ProficencyNature)
                 PrintablePlayerCharacter.NatureModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseNature)
                 PrintablePlayerCharacter.NatureModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.ReligionModifier =  PrintablePlayerCharacter.IntelligenceModifier;
            if ( PrintablePlayerCharacter.ProficencyReligion)
                 PrintablePlayerCharacter.ReligionModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseReligion)
                 PrintablePlayerCharacter.ReligionModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.AnimalHandlingModifier =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.ProficencyAnimalHandling)
                 PrintablePlayerCharacter.AnimalHandlingModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseAnimalHandling)
                 PrintablePlayerCharacter.AnimalHandlingModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.InsightModifier =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.ProficencyInsight)
                 PrintablePlayerCharacter.InsightModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseInsight)
                 PrintablePlayerCharacter.InsightModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.MedicineModifier =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.ProficencyMedicine)
                 PrintablePlayerCharacter.MedicineModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseMedicine)
                 PrintablePlayerCharacter.MedicineModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.PerceptionModifer =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.ProficencyPerception)
                 PrintablePlayerCharacter.PerceptionModifer +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertisePerception)
                 PrintablePlayerCharacter.PerceptionModifer +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.SurvivalModifier =  PrintablePlayerCharacter.WisdomModifier;
            if ( PrintablePlayerCharacter.ProficencySurvival)
                 PrintablePlayerCharacter.SurvivalModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseSurvival)
                 PrintablePlayerCharacter.SurvivalModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.DeceptionModifier =  PrintablePlayerCharacter.CharismaModifier;
            if ( PrintablePlayerCharacter.ProficencyDeception)
                 PrintablePlayerCharacter.DeceptionModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseDeception)
                 PrintablePlayerCharacter.DeceptionModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.IntimidationModifier =  PrintablePlayerCharacter.CharismaModifier;
            if ( PrintablePlayerCharacter.ProficencyIntimidation)
                 PrintablePlayerCharacter.IntimidationModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertiseIntimidation)
                 PrintablePlayerCharacter.IntimidationModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.PerformanceModifier =  PrintablePlayerCharacter.CharismaModifier;
            if ( PrintablePlayerCharacter.ProficencyPerformance)
                 PrintablePlayerCharacter.PerformanceModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertisePerformance)
                 PrintablePlayerCharacter.PerformanceModifier +=  PrintablePlayerCharacter.ProficencyBonus;

             PrintablePlayerCharacter.PersuasionModifier =  PrintablePlayerCharacter.CharismaModifier;
            if ( PrintablePlayerCharacter.ProficencyPersuasion)
                 PrintablePlayerCharacter.PersuasionModifier +=  PrintablePlayerCharacter.ProficencyBonus;
            if ( PrintablePlayerCharacter.ExpertisePersuasion)
                 PrintablePlayerCharacter.PersuasionModifier +=  PrintablePlayerCharacter.ProficencyBonus;
        }

    }
}