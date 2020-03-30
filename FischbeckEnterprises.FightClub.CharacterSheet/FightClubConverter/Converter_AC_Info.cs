using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void AC()
        {
            List<Feat> feats = (_pc.character.FirstOrDefault().@class.ToList().Where(a => a.feat != null).Select(x => x.feat.Where(b=>b.specialSpecified)).ToList().FirstOrDefault().ToList());
        }
    }
}
