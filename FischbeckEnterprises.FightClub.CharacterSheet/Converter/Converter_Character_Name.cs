using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Converter
{
    partial class XMLConverter
    {
        private void CharacterName()
        {
            _printablePlayerCharacter.CharacterName = _pc.character.FirstOrDefault().name;
        }
    }
}
