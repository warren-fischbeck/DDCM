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
            _pc.character.ForEach(e => e.feat.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));

            //item.mod
            _pc.character.ForEach(e => e.item.Where(a => a.mod.Count > 0).Select(a => a.mod).ToList().ForEach(a => ListOfAllMods.AddRange(a)));
        }

        private void ApplyMods(List<Mod> ListOfMods)
        {
            foreach(Mod mod in ListOfMods)
            {
                switch (mod.type)
                {
                    case 0: { break; }
                    case 1: { break; }
                    case 2: { break; }
                    case 3: { break; }
                    case 4: { break; }
                    case 5: { break; }
                    case 6: { break; }
                    case 7: { break; }
                    case 8: { break; }
                    case 9: { break; }
                    case 10: { break; }
                    case 11: { break; }
                    case 12: { break; }
                    case 13: { break; }
                    case 14: { break; }
                    case 15: { break; }
                    default:
                        break;
                }
            }
        }
    }
}
