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
                List<Item> damageItems = _pc.character.FirstOrDefault().item
                    .Where(x => x.damageTypeSpecified).OrderByDescending(x => x.slot).ThenBy(a => a.name).ToList();
                bool OnlyOneEquipedWeapon = true;

                if (damageItems.Where(a => a.slot > 0).Select(a => a).ToList().Count > 1)
                {
                    _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(b => b.feat).ToList()
                        .ForEach(a => a.Where(b => (b.name.ToLower().Contains("fighting")) && (b.special == 2))
                            .Select(c => c).FirstOrDefault().special = 0));
                    OnlyOneEquipedWeapon = false;
                }
                for (int i = 0; i < damageItems.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                _printablePlayerCharacter.WeaponName1 = damageItems[i].name;
                                _printablePlayerCharacter.WeaponAttackBonus1 = AttackBonus(damageItems[i]);
                                _printablePlayerCharacter.WeaponDamageAndType1 = Damage(damageItems[i], OnlyOneEquipedWeapon);
                                if (damageItems[i].weaponRangeSpecified)
                                    _printablePlayerCharacter.WeaponName1 += $" ({damageItems[i].weaponRange}\\{damageItems[i].weaponLongRange})";
                                break;
                            }
                        case 1:
                            {
                                _printablePlayerCharacter.WeaponName2 = damageItems[i].name;
                                _printablePlayerCharacter.WeaponAttackBonus2 = AttackBonus(damageItems[i]);
                                _printablePlayerCharacter.WeaponDamageAndType2 = Damage(damageItems[i], OnlyOneEquipedWeapon);
                                if (damageItems[i].weaponRangeSpecified)
                                    _printablePlayerCharacter.WeaponName2 += $" ({damageItems[i].weaponRange}\\{damageItems[i].weaponLongRange})";
                                break;
                            }
                        case 2:
                            {
                                _printablePlayerCharacter.WeaponName3 = damageItems[i].name;
                                _printablePlayerCharacter.WeaponAttackBonus3 = AttackBonus(damageItems[i]);
                                _printablePlayerCharacter.WeaponDamageAndType3 = Damage(damageItems[i], OnlyOneEquipedWeapon);
                                if (damageItems[i].weaponRangeSpecified)
                                    _printablePlayerCharacter.WeaponName2 += $" ({damageItems[i].weaponRange}\\{damageItems[i].weaponLongRange})";
                                break;
                            }
                        default:
                            break;
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
            bool isProficient = false;

            List<string> weaponProficiencies = new List<string>();
            _pc.character.ForEach(e => e.@class.ToList().ForEach(a => weaponProficiencies.AddRange(a.weapons.ToLower().Split(','))));
            weaponProficiencies.ForEach(e => e.Trim());
            weaponProficiencies = weaponProficiencies.Distinct().ToList();

            List<int> Specials = new List<int>();

            _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(b => b.feat).ToList()
                .ForEach(a => a.Where(b => (b.name.ToLower().Contains("fighting")) && (b.specialSpecified) && (b.special == 0))
                    .Select(c => c.special).ToList().ForEach(a => Specials.Add(a))));

            switch (IsFinesseWeapon(Weapon.weaponProperty))
            {
                case true:
                    {
                        if (dexterityModifier > strengthModifier)
                            attackBonus = profBonus + dexterityModifier;
                        else
                            attackBonus = profBonus + strengthModifier;
                        break;
                    }
                default:
                    {
                        if (!Weapon.name.ToLower().Contains("bow"))
                        {
                            attackBonus = profBonus + strengthModifier;
                        }
                        else
                        {
                            attackBonus = profBonus + dexterityModifier;
                        }
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
                        case 1: { if (mod.category == 0) { attackBonus += mod.value; } break; }
                        case 2: break;
                        case 3: { if (mod.category == 0) { attackBonus += mod.value; } break; }
                        case 4: break;
                        case 5: { if (mod.category == 0) { attackBonus += mod.value; } break; }
                        default:
                            break;
                    }
                }
            }
            if (Weapon.weaponRangeSpecified && !IsThrownWeapon(Weapon.weaponProperty))
            {
                foreach (int i in Specials)
                {
                    if (i == 0)
                    {
                        attackBonus += 2;
                    }
                }
            }

            foreach (var prof in weaponProficiencies)
            {
                if (prof.Contains(Weapon.name.ToLower()) || Weapon.name.ToLower().Contains(prof)) { isProficient = true; break; }
                if (IsMartialWeapon(Weapon.weaponProperty) && prof.Contains("martial weapons")) { isProficient = true; break; }
                else if (!IsMartialWeapon(Weapon.weaponProperty) && prof.Contains("simple weapons")) { isProficient = true; break; }
            }
            if (!isProficient) { attackBonus -= profBonus; }
            return $"+ {attackBonus}";
        }

        private string Damage(Item Weapon, bool OnlyOneWeapon)
        {
            int strengthModifier = _printablePlayerCharacter.StrengthModifier;
            int dexterityModifier = _printablePlayerCharacter.DexterityModifier;
            int damageBonus = 0;
            string damage = string.Empty;
            string damagetype = string.Empty;
            List<int> Specials = new List<int>();

            _pc.character.ForEach(e => e.@class.Where(a => a.feat.Count > 0).Select(b => b.feat).ToList()
                .ForEach(a => a.Where(b => (b.name.ToLower().Contains("fighting")) && (b.special == 2))
                    .Select(c => c.special).ToList().ForEach(a => Specials.Add(a))));


            switch (Weapon.damageType)
            {
                case 0: { damagetype = "B"; break; }
                case 1: { damagetype = "B"; break; }
                case 2: { damagetype = "P"; break; }
                case 3: { damagetype = "S"; break; }
                default:
                    break;
            }

            switch (IsFinesseWeapon(Weapon.weaponProperty))
            {
                case true:
                    {
                        if (Weapon.slot != 2)
                        {
                            if (dexterityModifier > strengthModifier)
                                damageBonus = dexterityModifier;
                            else
                                damageBonus = strengthModifier;
                        }
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0 && Weapon.slot != 2)
                            damageBonus += 2;
                        break;
                    }
                default:
                    {
                        if (Weapon.slot != 2 || OnlyOneWeapon)
                        {
                            damageBonus = strengthModifier;
                        }
                        if (Weapon.name.ToLower().Contains("bow"))
                        {
                            damageBonus = dexterityModifier;
                        }
                        damage = $"{Weapon.damage1H}";
                        if (Specials.Count > 0 && Weapon.slot != 2)
                            damageBonus += 2;
                        break;
                    }
            }

            if (IsTwoHandedWeapon(Weapon.weaponProperty))
                if (Weapon.damage2HSpecified)
                    damage = $"{Weapon.damage2H}";
                else
                    damage = $"{Weapon.damage1H}";

            if (IsVersitileWeapon(Weapon.weaponProperty))
                damage += $" ({Weapon.damage2H})";


            if (Weapon.modSpecified)
            {
                foreach (Mod mod in Weapon.mod)
                {
                    switch (mod.type)
                    {
                        case 0: break;
                        case 1: break;
                        case 2: { if (mod.category == 0) { damageBonus += mod.value; } break; }
                        case 3: break;
                        case 4: { if (mod.category == 0) { damageBonus += mod.value; } break; }
                        case 5: break;
                        case 6: { if (mod.category == 0) { damageBonus += mod.value; } break; }
                        default:
                            break;
                    }
                }
            }
            return $"{damage} + {damageBonus} / {damagetype}";
        }

        private bool IsAmmoWeapon(int weaponProp) { return (weaponProp & (1 << 0)) != 0; }

        private bool IsFinesseWeapon(int weaponprop) { return (weaponprop & (1 << 1)) != 0; }

        private bool IsHeavyWeapon(int weaponProp) { return (weaponProp & (1 << 2)) != 0; }

        private bool IsLightWeapon(int weaponProp) { return (weaponProp & (1 << 3)) != 0; }

        private bool IsLoadingWeapon(int weaponProp) { return (weaponProp & (1 << 4)) != 0; }

        private bool IsReachWeapon(int weaponProp) { return (weaponProp & (1 << 5)) != 0; }

        private bool IsSpecialWeapon(int weaponProp) { return (weaponProp & (1 << 6)) != 0; }

        private bool IsThrownWeapon(int weaponProp) { return (weaponProp & (1 << 7)) != 0; }

        private bool IsTwoHandedWeapon(int weaponProp) { return (weaponProp & (1 << 8)) != 0; }

        private bool IsVersitileWeapon(int weaponprop) { return (weaponprop & (1 << 9)) != 0; }

        private bool IsMartialWeapon(int weaponProp) { return (weaponProp & (1 << 10)) != 0; }
    }
}