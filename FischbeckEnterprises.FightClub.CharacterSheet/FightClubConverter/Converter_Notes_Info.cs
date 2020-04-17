using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Notes()
        {
            string notes = string.Empty;
            List<Note> _notes = new List<Note>();
            _pc.character.ForEach(e => e.note.ToList().ForEach(a => _notes.Add(a)));

            if (_notes.Count > 0)
            {
                foreach (Note n in _notes)
                {
                    if (n.name.ToLower() == _printablePlayerCharacter.FactionName.ToLower())
                    {
                        _printablePlayerCharacter.Allies = n.text;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(notes))
                        {
                            notes = $"*** {n.name} ***\n{n.text}";
                        }
                        else
                        {
                            notes += $"\n\n*** {n.name} ***\n{n.text}";
                        }
                    }
                }
            }
            _printablePlayerCharacter.BackStory = notes;
        }
    }
}
