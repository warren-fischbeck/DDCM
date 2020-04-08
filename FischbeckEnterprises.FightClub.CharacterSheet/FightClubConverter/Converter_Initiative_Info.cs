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

                // Feat featInfo = c.feat.Where(a => a.mod != null && a.mod.Where(b => b.type == 12) != null).FirstOrDefault();
                //if(featInfo!=null)
                //{
                //   score += featInfo.mod.Where(a => a.type == 12).ToList().FirstOrDefault().value;
                //}
                //List<Feat> charInfo = c.@class.Where(a => a.feat.Where(b => b.mod != null).ToList().FirstOrDefault() !=null).Select(a => a.feat).ToList().FirstOrDefault();
                //if (charInfo != null)
                // {
                //   var modList = charInfo.Where(a => a.mod != null).ToList().FirstOrDefault();
                // score += modList.mod.Where(a => a.type == 12).Select(a => a.value).FirstOrDefault();
                //}
                _printablePlayerCharacter.Inititive = score;
            }
        }
    }
}
