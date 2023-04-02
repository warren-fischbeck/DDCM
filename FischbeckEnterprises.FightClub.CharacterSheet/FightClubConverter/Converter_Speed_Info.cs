using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Speed()
        {
            int _speed = 0;
            foreach (Character c in _pc.character)
            {
                if (c.race.feat != null)
                {
                    _speed = 30;
                    foreach (var feat in c.race.feat)
                    {
                        if (feat.mod != null)
                        {
                            foreach (Mod m in feat.mod)
                            {
                                if (m.type == 13)
                                    _speed = _speed + m.value;
                            }
                        }
                    }
                }
                List<Feat> charInfo = c.@class.Where(a => a.feat.Where(b => b.mod != null).ToList().FirstOrDefault() != null).Select(a => a.feat).ToList().FirstOrDefault();
                if (charInfo != null)
                {
                    var speedMod = charInfo.Where(a => a.mod != null).ToList().FirstOrDefault();
                    _speed += speedMod.mod.Where(x => x.type == 13).Select(a => a.value).FirstOrDefault();
                }
            }
            _printablePlayerCharacter.Speed = _speed;
        }
    }
}