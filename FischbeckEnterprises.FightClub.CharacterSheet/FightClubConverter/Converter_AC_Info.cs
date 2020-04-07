﻿using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void AC()
        {
            var _class = _pc.character.FirstOrDefault().@class.ToList();
            List<Feat> features = new List<Feat>();
            int AC = 0;

            foreach (PcClass pcClass in _class)
            {
                features.AddRange(pcClass.feat.Where(a => a.specialSpecified == true).ToList());
            }
            foreach (Feat feat in features)
            {
                switch (feat.special)
                {
                    case 6:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.WisdomModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.WisdomModifier;
                            break;
                        }
                    case 7:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.DexterityModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.DexterityModifier;
                            break;
                        }
                    case 8:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.ConstitutionModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.ConstitutionModifier;
                            break;
                        }
                    case 9:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.IntelligenceModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.IntelligenceModifier;
                            break;
                        }
                    case 10:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.WisdomModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.WisdomModifier;
                            break;
                        }
                    case 11:
                        {
                            if ((10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.CharismaModifier) > AC)
                                AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.CharismaModifier;
                            break;
                        }
                    case 5:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    case 4:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    case 3:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    case 2:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    case 1:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    case 0:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier + _printablePlayerCharacter.StrengthModifier;
                            break;
                        }
                    default:
                        {
                            AC = 10 + _printablePlayerCharacter.DexterityModifier;
                            break;
                        }
                }
            }
            if (_pc.character.FirstOrDefault().item != null)
            {
                List<Item> items = new List<Item>();
                items.AddRange(_pc.character.FirstOrDefault().item.ToList().Where(a => a.slot == 4 || a.slot == 5));
                if (items.Count > 0)
                    AC = 0;
                foreach (Item i in items)
                {
                    if (i.ac > 0)
                        AC += i.ac;
                    if (i.type == 1)
                        AC += _printablePlayerCharacter.DexterityModifier;
                    if (i.type == 2)
                    {
                        if (_printablePlayerCharacter.DexterityModifier >= 2)
                            AC += 2;
                        else
                            AC += _printablePlayerCharacter.DexterityModifier;
                    }
                }
            }
            _printablePlayerCharacter.ArmorClass = AC;
        }
    }
}