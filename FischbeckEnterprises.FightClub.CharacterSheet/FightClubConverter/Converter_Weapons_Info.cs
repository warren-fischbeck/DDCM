using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Weapons()
        {
            try
            {
                List<Item> damageItems = _pc.character.FirstOrDefault().item.Where(x => x.damageTypeSpecified).OrderByDescending(x => x.slot).ToList();

                if (damageItems.Count >= 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    _printablePlayerCharacter.WeaponName1 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus1 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType1 = Damage(damageItems[i]);
                                    break;
                                }
                            case 1:
                                {
                                    _printablePlayerCharacter.WeaponName2 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus2 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType2 = Damage(damageItems[i]);
                                    break;
                                }
                            case 2:
                                {
                                    _printablePlayerCharacter.WeaponName3 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus3 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType3 = Damage(damageItems[i]);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < damageItems.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    _printablePlayerCharacter.WeaponName1 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus1 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType1 = Damage(damageItems[i]);
                                    break;
                                }
                            case 1:
                                {
                                    _printablePlayerCharacter.WeaponName2 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus2 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType2 = Damage(damageItems[i]);
                                    break;
                                }
                            case 2:
                                {
                                    _printablePlayerCharacter.WeaponName3 = damageItems[i].name;
                                    _printablePlayerCharacter.WeaponAttackBonus3 = AttackBonus(damageItems[i]);
                                    _printablePlayerCharacter.WeaponDamageAndType3 = Damage(damageItems[i]);
                                    break;
                                }
                            default:
                                break;
                        }
                    }

                }
            }
            catch
            {

            }
        }

        private string AttackBonus(Item Weapon)
        {
            int profBonus = _printablePlayerCharacter.ProficencyBonus;
            int strengthModifier = _printablePlayerCharacter.StrengthModifier;
            int dexterityModifier = _printablePlayerCharacter.DexterityModifier;
            int attackBonus = 0;
            List<int> Specials = new List<int>();
            _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(b => b.feat).ToList().ForEach(a => a.Where(b => (b.name.ToLower().Contains("fighting")) && (b.specialSpecified) && (b.special==0)).Select(c => c.special).ToList().ForEach(a => Specials.Add(a))));


            switch (Weapon.weaponProperty)
            {
                case 138:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        break;
                    }
                case 257:
                    {
                        attackBonus = profBonus + dexterityModifier;
                        if (Specials.Count > 0)
                            attackBonus += 2;
                        break;
                    }
                case 259:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        if (Specials.Count > 0)
                            attackBonus += 2;
                        break;
                    }
                case 512:
                    {
                        attackBonus = profBonus + strengthModifier;
                        break;
                    }
                case 1026:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        break;
                    }
                case 1283:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        if (Specials.Count > 0)
                            attackBonus += 2;
                        break;
                    }
                case 1285:
                    {
                        attackBonus = profBonus + dexterityModifier;
                        if (Specials.Count > 0)
                            attackBonus += 2;
                        break;
                    }
                case 1287:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        if (Specials.Count > 0)
                            attackBonus += 2;
                        break;
                    }
                default:
                    {
                        attackBonus = profBonus + strengthModifier;
                        break;
                    }
            }
            if (Weapon.mod != null)
            {
                foreach (Mod mod in Weapon.mod)
                {
                    switch (mod.type)
                    {
                        case 0: break;
                        case 1: break;
                        case 2: break;
                        case 3: { if(mod.category == 0) { attackBonus += mod.value; }break; }
                        case 4: break;
                        case 5: break;
                        default:
                            break;
                    }
                }
            }
            return $"+ {attackBonus}";
        }
    
        private string Damage(Item Weapon)
        {
            int strengthModifier = _printablePlayerCharacter.StrengthModifier;
            int dexterityModifier = _printablePlayerCharacter.DexterityModifier;
            int damageBonus = 0;
            string damage = string.Empty;
            string damagetype = string.Empty;
            List<int> Specials = new List<int>();
            _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(b => b.feat).ToList().ForEach(a => a.Where(b => (b.name.ToLower().Contains("fighting")) && (b.special == 2)).Select(c => c.special).ToList().ForEach(a => Specials.Add(a))));


            switch (Weapon.damageType)
            {
                case 0: { damagetype = "B"; break; }
                case 1: { damagetype = "B"; break; }
                case 2: { damagetype = "P"; break; }
                case 3: { damagetype = "S"; break; }
                default:
                    break;
            }


            switch (Weapon.weaponProperty)
            {
                case 138:
                    {
                        if (dexterityModifier > strengthModifier)
                            damageBonus =  dexterityModifier;
                        else
                            damageBonus =  strengthModifier;
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0)
                            damageBonus += 2;
                        break;
                    }
                case 292:
                    {
                        damageBonus = strengthModifier;
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0)
                            damageBonus += 2;
                        break;
                    }
                case 512:
                    {
                        damageBonus =  strengthModifier;
                        damage = $"{Weapon.damage1H} ({Weapon.damage2H})";
                        if (Specials.Count > 0)
                            damageBonus += 2;
                        break;
                    }
                case 1026:
                    {
                        if (dexterityModifier > strengthModifier)
                            damageBonus = dexterityModifier;
                        else
                            damageBonus = strengthModifier;
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0)
                            damageBonus += 2;
                        break;
                    }
                default:
                    {
                        damageBonus =  strengthModifier;
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0)
                            damageBonus += 2;
                        break;
                    }
            }

            if (Weapon.modSpecified)
            {
                foreach (Mod mod in Weapon.mod)
                {
                    switch (mod.type)
                    {
                        case 0: break;
                        case 1: break;
                        case 2: break;
                        case 3: break;
                        case 4: { if (mod.category == 0){ damageBonus += mod.value; } break; }
                        case 5: break;
                        default:
                            break;
                    }
                }
            }

            return $"{damage} + {damageBonus} / {damagetype}";
        }
    }
}