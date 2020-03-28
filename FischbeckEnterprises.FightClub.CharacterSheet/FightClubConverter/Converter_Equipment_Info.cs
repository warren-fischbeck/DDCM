using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Equipment()
        {
            string equipment = string.Empty;
            List<Item> equipmentItems = _pc.character.Where(x => x.item != null).FirstOrDefault().item.ToList();
            foreach(Item item in equipmentItems)
            {
                if (string.IsNullOrEmpty(equipment))
                {
                    equipment = item.name;
                }
                else
                {
                    equipment += $", {item.name}";
                }
            }

            _printablePlayerCharacter.Equipment1 = equipment;
        }
    }
}