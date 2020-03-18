using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
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

                if (c.item != null)
                {
                    foreach(Item item in c.item)
                    {
                        if(item.mod!=null)
                        {
                            foreach(Mod mod in item.mod)
                            {
                                if (mod.type == 13 && item.slot != 0)
                                    _speed = _speed + mod.value;
                            }
                        }
                    }
                }
            }
            _printablePlayerCharacter.Speed = _speed;
        }
    }
}
