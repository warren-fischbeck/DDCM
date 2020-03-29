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
            string equipment2 = string.Empty;
            List<Item> equipmentItems = _pc.character.Where(x => x.item != null).FirstOrDefault().item.ToList();
            foreach(Item item in equipmentItems)
            {
                switch (item.type)
                {
                    case 0:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 1:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 2:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 3:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 4:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 5:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 6:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 7:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 8:
                        {
                            if (string.IsNullOrEmpty(equipment2))
                            {
                                equipment2 = item.name;
                            }
                            else
                            {
                                equipment2 += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment2 += $" - ({item.quantity})";
                            }
                            break; }
                    case 9:
                        {
                            if (string.IsNullOrEmpty(equipment2))
                            {
                                equipment2 = item.name;
                            }
                            else
                            {
                                equipment2 += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment2 += $" - ({item.quantity})";
                            }
                            break; }
                    case 10:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 11:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 12:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 13:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 14:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 15:
                        {
                            if (string.IsNullOrEmpty(equipment2))
                            {
                                equipment2 = item.name;
                            }
                            else
                            {
                                equipment2 += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment2 += $" - ({item.quantity})";
                            }
                            break;
                        }
                    case 16:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 17:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 18:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 19:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    case 20:
                        {
                            if (string.IsNullOrEmpty(equipment))
                            {
                                equipment = item.name;
                            }
                            else
                            {
                                equipment += $", {item.name}";
                            }
                            if (item.quantity > 0)
                            {
                                equipment += $" - ({item.quantity})";
                            }
                            break; }
                    default:
                        break;
                }
            }
            _printablePlayerCharacter.Equipment1 = equipment;
            _printablePlayerCharacter.Equipment2 = equipment2;
        }
    }
}