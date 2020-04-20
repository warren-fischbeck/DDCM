using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Languages()
        {
            foreach (Character c in _pc.character)
            {
                string lang = c.feat.Where(x => x.name.ToLower().Contains("language")).Select(x => x.text).ToList().FirstOrDefault();
                string race = c.race.feat.Where(a => a.name.ToLower().Contains("language")).Select(b => b.text).ToList().FirstOrDefault();
                string armor = c.@class.FirstOrDefault().armor;
                string weapons = c.@class.FirstOrDefault().weapons;
                string la = string.Empty;
                PcClass classinfo = c.@class.Where(a => a.feat.Where(b => b.name.ToLower().Contains("language")).ToList().FirstOrDefault() != null).ToList().FirstOrDefault();
                if (classinfo != null)
                {
                    la = classinfo.feat.Where(a => a.name.ToLower().Contains("language")).ToList().FirstOrDefault().text;
                }
                if (string.IsNullOrEmpty(_printablePlayerCharacter.ProficiencesAndLanguages))
                    _printablePlayerCharacter.ProficiencesAndLanguages = $"{_printablePlayerCharacter.ProficiencesAndLanguages}\n{lang} {race} {la} \nArmor: {armor}\nWeapons: {weapons}";
                else
                    _printablePlayerCharacter.ProficiencesAndLanguages = $"{lang} {race} {la}\nArmor: {armor}\nWeapons: {weapons}";
            }
        }
    }
}