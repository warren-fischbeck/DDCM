using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.DDCM.Types
{
    enum Sense
    {
        Standard = 1,
        Blindsight,
        Darkvision,
        Truesight
    }

    enum Condition
    {
        Blinded = 1,
        Charmed,
        Deafened,
        Frightened,
        Grappled,
        Incapacitated,
        Invisible,
        Paralyzed,
        Petrified,
        Poisoned,
        Prone,
        Restrained,
        Stunned,
        Unconscious,
        Exhaustion_Level_1,
        Exhaustion_Level_2,
        Exhaustion_Level_3,
        Exhaustion_Level_4,
        Exhaustion_Level_5,
        Exhaustion_Level_6
    }

    enum Modifier_Category
    {
        Ability_Score=1,
        Speed,
        Saving_Throw,
        Ability_Check,
        Attack,
        Damage
    }

    enum Modifier_Type
    {
        Proficiency=1,
        Advantage,
        Disadvantage,
        Strength,
        Strength_Save,
        Dexterity,
        Dexterity_Save,
        Constitution,
        Constitution_Save,
        Intelligence,
        Intelligence_Save,
        Wisdom,
        Wisdom_Save,
        Charisma,
        Charisma_Save,
        Athletics,
        Acrobatics,
        Sleight_of_Hand,
        Stealth,
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        Animal_Handling,
        Insight,
        Medicine,
        Perception,
        Survival,
        Deception,
        Intimidation,
        Performanace,
        Persuasion,
        Attack_Modifier,
        Damage_Modifier,
        Encumbered,
        Heavily_Encumbered,
        Hit_Points,
        Temporary_Hit_Points,
        Resistance,
        Vulnerability
    }

    enum Damage_Type
    {
        Acid=1,
        Bludgeoning,
        Cold,
        Fire,
        Force,
        Lightning,
        Necrotic,
        Piercing,
        Poison,
        Psychic,
        Radiant,
        Slashing,
        Thunder
    }

    enum Item_Property
    {
        Finesse=1,
        Light,
        Heavy,
        Ranged,
        Thrown,
        Two_Handed,
        Reach,
        Versatile,
        Ammunition
    }

    enum Item_Category
    {
        Adventuring_Gear=1,
        Container,
        Goods,
        Wealth,
        Light_Armor,
        Medium_Armor,
        Heavy_Armor,
        Shield,
        Melee_Weapon,
        Ranged_Weapon,
        Ammunition,
        Rod,
        Staff,
        Wand,
        Ring,
        Potion,
        Scroll,
        Wonderous_Item
    }
}
