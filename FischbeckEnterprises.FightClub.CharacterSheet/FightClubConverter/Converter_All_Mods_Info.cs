using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void AllMods()
       {
            List<Mod> ListOfAllMods = new List<Mod>();
          string Name = _pc.character.FirstOrDefault().name;

            //Race.mod
            _pc.character.ForEach(e => e.race.mod.ToList().ForEach(a => ListOfAllMods.Add(a)));
            
            //race.feat.mod
            _pc.character.ForEach(e => e.race.feat.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));

            //Class.mod
            _pc.character.ForEach(e => e.@class.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));
           
            //class.feat.mod
            _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(a => a.feat).ToList().ForEach(a => a.Where(b => b.mod.Count > 0).Select(c => c.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a))));
           
            //feat.mod
            _pc.character.ForEach(e => e.feat.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));

            //background.Feat.mod
            _pc.character.ForEach(e => e.background.feat.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));

            //item.mod
            _pc.character.ForEach(e => e.item.Where(a => (a.mod.Count > 0) && a.slot > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));

            ApplyMods(ListOfAllMods);
        }

        private void ApplyMods(List<Mod> ListOfMods)
        {
            foreach(Mod mod in ListOfMods)
            {
                switch (mod.type)
                {
                    case 0:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Strength += mod.value;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Dexterity += mod.value;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Constitution += mod.value;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Intelligence += mod.value; 
                            }
                            break;
                        }
                    case 4:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Wisdom += mod.value; 
                            }
                            break;
                        }
                    case 5:
                        {
                            if (mod.category == 1 || (mod.nameSpecified && mod.name.ToLower().Contains("ability")))
                            {
                                _printablePlayerCharacter.Charisma += mod.value; 
                            }
                            break;
                        }
                    case 6: { break; }
                    case 7: { break; }
                    case 8: { break; }
                    case 9: { break; }
                    case 10: { _printablePlayerCharacter.ArmorClass += mod.value; break; }
                    case 11: { break; }
                    case 12: { break; }
                    case 13: { _printablePlayerCharacter.Speed += mod.value; break; }
                    case 14: { break; }
                    case 15: { break; }
                    default:
                        break;
                }
            }
            _printablePlayerCharacter.StrengthModifier = AbilityModifier(_printablePlayerCharacter.Strength);
            _printablePlayerCharacter.DexterityModifier = AbilityModifier(_printablePlayerCharacter.Dexterity);
            _printablePlayerCharacter.ConstitutionModifier = AbilityModifier(_printablePlayerCharacter.Constitution);
            _printablePlayerCharacter.IntelligenceModifier = AbilityModifier(_printablePlayerCharacter.Intelligence);
            _printablePlayerCharacter.WisdomModifier = AbilityModifier(_printablePlayerCharacter.Wisdom);
            _printablePlayerCharacter.CharismaModifier = AbilityModifier(_printablePlayerCharacter.Charisma);
        }
    }
}
