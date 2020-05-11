using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Internal
{
    class Schema_Internal_Enumerations
    {
    }

    public enum Slot
    {
        Not = 0, Equpiped, Armor, Shield, PrimaryHand, OffHand
    }

    public enum DamgeType
    {
        Bludgening, Piercing, Slashing, Acid, Cold, Fire, Force, Lightning, Necrotic, Poison, Radiant, Thunder
    }

    public enum ItemProperty
    {
       Ammunition, Finesse, Heavy, Light, Loading, Reach, Special, Thrown, TwoHanded, Versatile, Martial, Simple
    }

    public enum ItemType
    {
        LightArmor, MediumArmor, HeavyArmor, Shield, MeleeWeapon, RangedWeapon, Ammunition, Rod, Staff, Wand, Ring, Potion, Scroll, WonderousItem, AdventeringGear, Money
    }

    public enum FCItemType
    {
        LA, MA, HA, S, M, R, A, RD, ST, WD, RG, P, SC, W, G
    }
}
