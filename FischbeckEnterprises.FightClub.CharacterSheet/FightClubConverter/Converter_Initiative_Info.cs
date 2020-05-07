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

                var collectionFeat = c.feat.Where(a => a.modSpecified).ToList();
                var CollectionMod = collectionFeat.Where(a => a.modSpecified).Select(a => a.mod.FirstOrDefault()).ToList();
                var collectionClassMod = c.@class.Where(a => a.featSpecified).Select(a => a.feat.Where(b => b.modSpecified)).FirstOrDefault().ToList();
                var objMod = CollectionMod.Where(a => a.type == 12).ToList();

                if (collectionClassMod.Count > 0)
                {
                    var test = collectionClassMod.FirstOrDefault().mod.Where(a => a.typeSpecified && a.type == 12).ToList();
                    if (test.Count > 0)
                    {
                        objMod.AddRange(test);
                    }
                }

                if (objMod.Count > 0)
                {
                    foreach (var item in objMod)
                    {
                        score += item.value;
                    }
                }
                List<Mod> Mod = GetModByType(12);
                if (Mod.Count > 0) { Mod.ForEach(e => score += e.value); }
                _printablePlayerCharacter.Inititive = score;
            }
        }
    }
}