using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private pc _pc;
        private PrintablePlayerCharacter _printablePlayerCharacter;

        public Converter()
        {
            this._pc = new pc();
            this._printablePlayerCharacter = new PrintablePlayerCharacter();
        }

        public Converter(pc playerCharacter)
        {
            if (playerCharacter != null)
                this._pc = playerCharacter;
            this._printablePlayerCharacter = new PrintablePlayerCharacter();
        }

        public PrintablePlayerCharacter Build()
        {
            BaseInfo();
            Abilities();
            Proficiencies();
            CharacterLevel();
            Equipment();
            Speed(); 
            Features();
            Languages();
            Inititive();
            Weapons();
            Notes();
            AC();
            PCImage();
            FactionImage();
            BuildSpellCasting();
            return _printablePlayerCharacter;
        }
    }
}