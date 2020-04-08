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
            if (_pc.character.Where(a => a.noteSpecificed).FirstOrDefault() != null)
            {
                List<Note> _notes = _pc.character.FirstOrDefault().note.ToList();
                foreach (Note n in _notes)
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
            _printablePlayerCharacter.BackStory = notes;
        }
    }
}
