using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using FischbeckEnterprises.FightClub.CharacterSheet.Printable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Converter
{
    partial class XMLConverter
    {
        private pc _pc;
        private PrintablePlayerCharacter _printablePlayerCharacter;
        private List<PrintablePlayerCharacter> ListToPrint = new List<PrintablePlayerCharacter>();

        public PrintablePlayerCharacter PrintablePlayerCharacter 
        { 
            get { return this._printablePlayerCharacter; } 
            set { this._printablePlayerCharacter = value; } 
        }

        public XMLConverter()
        {
            this._pc = new pc();
            this._printablePlayerCharacter = new PrintablePlayerCharacter();
            Convert();
        }

        public XMLConverter(pc playerCharacter)
        {
            if (playerCharacter != null)
                this._pc = playerCharacter;
            this._printablePlayerCharacter = new PrintablePlayerCharacter();
            Convert();
        }

        public XMLConverter(data playerCharacters)
        {
            this._pc = new pc()
            {
                character = playerCharacters.character,
                imageData = playerCharacters.imageData,
                version = playerCharacters.version
            };
        }

        private void Convert()
        {
            Step1();
            new PDFCreator(_printablePlayerCharacter);
        }

        private void Step1()
        {
            CharacterName();
            ClassAndLevel();
        }
    }
}
