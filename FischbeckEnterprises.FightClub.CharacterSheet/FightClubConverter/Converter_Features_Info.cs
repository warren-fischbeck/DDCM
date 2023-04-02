using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Features()
        {
            foreach (Character c in _pc.character)
            {
                string _feature = string.Empty;
                string _feature2 = string.Empty;
                if (c.@class != null)
                {
                    var features = c.@class.Where(a => a.feat != null).Select(a => a.feat).ToList().FirstOrDefault();
                    foreach (Feat f in features)
                    {
                        if (f.name != null && !f.name.ToLower().Contains("starting"))
                        {
                            if (string.IsNullOrEmpty(_feature))
                            {
                                _feature = $"*** {f.name} ***";
                            }
                            else
                            {
                                _feature = $"{_feature}\n*** {f.name} ***";
                            }
                            if (f.text != null)
                            {
                                if (f.text.Length > 200)
                                {
                                    // _feature = $"{_feature}\n{f.text.Substring(0, 200)} <More>";
                                    if (f.text.ToLower().IndexOf("source", 0) != -1)
                                    {
                                        int start = f.text.ToLower().IndexOf("source", 0);
                                        string Source = f.text.Substring(start, f.text.Length - start);
                                        _feature = $"{_feature}\n     {Source}";
                                    }
                                }
                                else
                                {
                                    // _feature = $"{_feature}\n{f.text}";
                                }
                            }
                        }
                    }
                }
                List<Feat> _raceFeat = _pc.character.FirstOrDefault().race.feat.ToList();
                List<Feat> _featFeat = _pc.character.FirstOrDefault().feat.ToList();

                foreach (Feat feat in _raceFeat)
                {
                    if ((feat.name != null)
                        && (feat.name.ToLower() != "languages")
                        && (!feat.name.ToLower().Contains("ability"))
                        && (!feat.name.ToLower().Contains("feat"))
                        && (!feat.name.ToLower().Contains("skills")))
                    {
                        if (string.IsNullOrEmpty(_feature2))
                            _feature2 = $"*** {feat.name} ***";
                        else
                            _feature2 += $"\n*** {feat.name} ***";
                        if (feat.text.ToLower().IndexOf("source", 0) != -1)
                        {
                            int start = feat.text.ToLower().IndexOf("source", 0);
                            string Source = feat.text.Substring(start, feat.text.Length - start);
                            _feature2 += $"\n     {Source}";
                        }
                    }
                }
                foreach (Feat feat in _featFeat)
                {
                    if (feat.name != null)
                    {
                        if (string.IsNullOrEmpty(_feature2))
                            _feature2 = $"*** {feat.name} ***";
                        else
                            _feature2 += $"\n*** {feat.name} ***";
                        if (feat.text.ToLower().IndexOf("source", 0) != -1)
                        {
                            int start = feat.text.ToLower().IndexOf("source", 0);
                            string Source = feat.text.Substring(start, feat.text.Length - start);
                            _feature2 += $"\n     {Source}";
                        }
                    }
                }
                _printablePlayerCharacter.FeaturesAndTraits1 = _feature;
                _printablePlayerCharacter.FeatsAndTraits2 = _feature2;
            }
        }
    }
}