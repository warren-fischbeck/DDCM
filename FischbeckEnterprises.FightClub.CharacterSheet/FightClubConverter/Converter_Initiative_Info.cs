using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Inititive()
        {
            foreach (Character c in _pc.character)
            {
                int score = 0;
                score = _printablePlayerCharacter.DexterityModifier;

                Feat featInfo = c.feat.Where(a => a.mod != null && a.mod.Where(b => b.type == 12) != null).FirstOrDefault();
                if(featInfo!=null)
                {
                    score += featInfo.mod.Where(a => a.type == 12).ToList().FirstOrDefault().value;
                }
                Feat[] charInfo = c.@class.Where(a => a.feat.Where(b => b.mod != null).ToList().FirstOrDefault() !=null).Select(a => a.feat).ToList().FirstOrDefault();
                if (charInfo != null)
                {
                    var modList = charInfo.Where(a => a.mod != null).ToList().FirstOrDefault();
                    score += modList.mod.Where(a => a.type == 12).Select(a => a.value).FirstOrDefault();
                }
                _printablePlayerCharacter.Inititive = score;
            }
        }
    }
}
