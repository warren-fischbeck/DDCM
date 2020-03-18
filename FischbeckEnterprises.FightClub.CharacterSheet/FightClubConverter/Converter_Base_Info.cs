using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        public void BaseInfo()
        {
            foreach (Character c in _pc.character)
            {
                if (c.name != null)
                    _printablePlayerCharacter.CharacterName = c.name;
                if (c.race.name != null)
                    _printablePlayerCharacter.Race = c.race.name;
                if (c.race.age != null)
                    _printablePlayerCharacter.Age = c.race.age;
                if (c.background.align != null)
                    _printablePlayerCharacter.Alignment = c.background.align;
                if (c.background.name != null)
                    _printablePlayerCharacter.Background = c.background.name;
                if (c.background.bonds != null)
                    _printablePlayerCharacter.PersonalityBonds = c.background.bonds;
                if (c.background.faction != null)
                    _printablePlayerCharacter.FactionName = c.background.faction;
                if (c.background.flaws != null)
                    _printablePlayerCharacter.PersonalityFlaws = c.background.flaws;
                if (c.background.ideals != null)
                    _printablePlayerCharacter.PersonalityIdeals = c.background.ideals;
                if (c.background.personality != null)
                    _printablePlayerCharacter.PersonalityTraits = c.background.personality;
                if (c.xp >= 0)
                    _printablePlayerCharacter.ExperiencePoints = c.xp;
                if (c.race.eyes != null)
                    _printablePlayerCharacter.Eyes = c.race.eyes;
                if (c.race.hair != null)
                    _printablePlayerCharacter.Hair = c.race.hair;
                if (c.race.height != null)
                    _printablePlayerCharacter.Height = c.race.height;
                if (c.race.skin != null)
                    _printablePlayerCharacter.Skin = c.race.skin;
                if (c.race.weight != null)
                    _printablePlayerCharacter.Weight = c.race.weight;
                if (c.hpCurrent >= 0)
                    _printablePlayerCharacter.HitPointCurrent = c.hpCurrent;
                if (c.hpMax >= 0)
                    _printablePlayerCharacter.HitPointMax = c.hpMax;
                
                foreach(PcClass pcClass in c.@class)
                {
                    if (pcClass.level == 0)
                        pcClass.level++;
                }
            }
        }
    }
}
