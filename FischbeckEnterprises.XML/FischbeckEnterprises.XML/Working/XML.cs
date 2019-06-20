using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using FischbeckEnterprises.XML.Core;

namespace FischbeckEnterprises.XML.Working
{
    partial class XMLConvertFightClub
    {
        readonly XElement _sourceDoc;
        public PrintablePlayerCharacter _printablePlayerCharacter { get; private set; }

        public XMLConvertFightClub() { _printablePlayerCharacter = new PrintablePlayerCharacter(); }
        public XMLConvertFightClub(string XMLPath)
        {
            FileInfo _file = new FileInfo(XMLPath);
            if (_file != null)
            {
                _sourceDoc = XElement.Load(XMLPath);
                _printablePlayerCharacter = new PrintablePlayerCharacter();
            }
        }

        public void Read()
        {
            if (_sourceDoc.Descendants("imageData").FirstOrDefault() != null)
                _printablePlayerCharacter.CharacterImageFilePath = _sourceDoc.Descendants("imageData").FirstOrDefault().Value;
            else _printablePlayerCharacter.CharacterImageFilePath = "0000.jpeg";
            _printablePlayerCharacter.CharacterName = _sourceDoc.Descendants("name").First().Value;
            _printablePlayerCharacter.ExperiencePoints = ReturnValue(_sourceDoc.Descendants("xp").FirstOrDefault());
            _printablePlayerCharacter.HitPointMax = ReturnValue(_sourceDoc.Descendants("character").Elements("hpMax").FirstOrDefault());
            _printablePlayerCharacter.HitPointCurrent = ReturnValue(_sourceDoc.Descendants("character").Elements("hpCurrent").FirstOrDefault());
            _printablePlayerCharacter.Equipment1 = ReturnString(_sourceDoc.Descendants("item").ToList());
            GenerateRaicalInfo(_printablePlayerCharacter, _sourceDoc.Descendants("race").ToList());
            WriteBackgroundInfo(_printablePlayerCharacter, _sourceDoc.Descendants());
            ReturnAttributes(_printablePlayerCharacter, _sourceDoc.Descendants());
            GenerateSkillProficiency(_printablePlayerCharacter, _sourceDoc.Descendants("proficiency").ToList(), _sourceDoc.Descendants("mod").ToList());
            _printablePlayerCharacter.PassivePerception = _printablePlayerCharacter.PerceptionModifer + 10;
            _printablePlayerCharacter.Inititive = _printablePlayerCharacter.DexterityModifier;
            GenerateFeatsAndTraits(_printablePlayerCharacter, _sourceDoc.Descendants("character").Elements("feat").ToList());
            GenerateFeatsAndTraits(_printablePlayerCharacter, _sourceDoc.Descendants("class").Elements("feat").ToList());
            GenerateClassAndLevel(_printablePlayerCharacter, _sourceDoc.Descendants("class").ToList());
            GenerateHitDice(_printablePlayerCharacter, _sourceDoc.Descendants("class").ToList());
            GenerateLanguagesAndProficencies(_printablePlayerCharacter, _sourceDoc.Descendants("character").ToList());
            GenerateTreasure(_printablePlayerCharacter, _sourceDoc.Descendants("item").ToList());
            GenerateWeapons(_printablePlayerCharacter, _sourceDoc.Descendants("item").ToList());
            GenerateSpeed(_printablePlayerCharacter, _sourceDoc.Descendants().ToList());
            GenerateAC(_printablePlayerCharacter, _sourceDoc.Descendants("item").ToList());
            if (_printablePlayerCharacter.ArmorClass == 0)
                UnarmoredDefense(_printablePlayerCharacter, _sourceDoc.Descendants().ToList());
            if (_sourceDoc.Descendants("race").Elements("spell").FirstOrDefault() != null)
            {
                SpellCasting casting = new SpellCasting();
                casting.SpellCastingClass = "Racial/Feat Spells";
                casting.SpellsKnown = XmlSpellConverter(_sourceDoc.Descendants("race").Elements("spell").ToList());
                XmlSpellAbility(casting, _sourceDoc.Descendants("race").Elements("spellAbility").FirstOrDefault().Value);
                if (casting.SpellsKnown.Count > 0)
                    _printablePlayerCharacter.SpellCasting.Add(casting);
            }
            if(_sourceDoc.Descendants("class").Elements("slots").ToList() != null)
            {
                var _SpellClasses = _sourceDoc.Descendants("class").Elements("slots").ToList();
                foreach (var _class in _SpellClasses)
                {
                    SpellCasting spellCasting = new SpellCasting();
                    spellCasting.SpellCastingClass = _class.Parent.Descendants("name").FirstOrDefault().Value;
                    spellCasting.SpellsKnown = XmlSpellConverter(_class.Parent.Descendants("spell").ToList());
                    XmlSlotConverter(spellCasting, _class.Value.Split(','));
                    XmlSpellAbility(spellCasting, _class.Parent.Descendants("spellAbility").FirstOrDefault().Value);
                    if (spellCasting.SpellsKnown.Count > 0)
                        _printablePlayerCharacter.SpellCasting.Add(spellCasting);
                }
            }
        }

        private void XmlSlotConverter(SpellCasting spellCasting, string[] SpellSlots)
        {
            for (int i = 0; i < SpellSlots.Length; i++)
            {
                if (string.IsNullOrEmpty(SpellSlots[i])) { SpellSlots[i] = "0"; }
                int number = Convert.ToInt16(SpellSlots[i]);
                switch (i)
                {
                    case 0: { spellCasting.CantripsKnown = number; break; }
                    case 1: { spellCasting._1stLevelSlots = number; break; }
                    case 2: { spellCasting._2ndLevelSlots = number; break; }
                    case 3: { spellCasting._3rdLevelSlots = number; break; }
                    case 4: { spellCasting._4thLevelSlots = number; break; }
                    case 5: { spellCasting._5thLevelSlots = number; break; }
                    case 6: { spellCasting._6thLevelSlots = number; break; }
                    case 7: { spellCasting._7thLevelSlots = number; break; }
                    case 8: { spellCasting._8thLevelSlots = number; break; }
                    case 9: { spellCasting._9thLevelSlots = number; break; }
                    case 10: { spellCasting._10thLevelSlots = number; break; }
                    default:
                        break;
                }
            }
        }

        private void XmlSpellAbility(SpellCasting spellCasting, string spellAbility)
        {
            switch (spellAbility)
            {
                case "0":
                    {
                        spellCasting.AbilityScore = "strength";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.StrengthModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.StrengthModifier;
                        break;
                    }
                case "1":
                    {
                        spellCasting.AbilityScore = "Dexterity";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.DexterityModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.DexterityModifier;
                        break;
                    }
                case "2":
                    {
                        spellCasting.AbilityScore = "Constitution";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.ConstitutionModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.ConstitutionModifier;
                        break;
                    }
                case "3":
                    {
                        spellCasting.AbilityScore = "Intelligence";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.IntelligenceModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.IntelligenceModifier;
                        break;
                    }
                case "4":
                    {
                        spellCasting.AbilityScore = "Wisdom";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.WisdomModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.WisdomModifier;
                        break;
                    }
                case "5":
                    {
                        spellCasting.AbilityScore = "Charisma";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.CharismaModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.CharismaModifier;
                        break;
                    }
                default: break;
            }
        }

        private List<Spell> XmlSpellConverter(IEnumerable<XElement> Spells)
        {
            List<Spell> _spells = new List<Spell>();

            foreach (XElement s in Spells)
            {
                Spell Spell = new Spell();
                List<Component> component = new List<Component>();
                List<string> _class = new List<string>();
                if (s.Element("name") != null) { Spell.Name = s.Element("name").Value; }
                if (s.Element("level") != null) { Spell.Level = Convert.ToInt32(s.Element("level").Value); } else { Spell.Level = 0; }
                if (s.Element("school") != null) { Spell.School = (School)(Convert.ToInt16(s.Element("school").Value)); }
                if (s.Element("ritual") != null) { Spell.Ritual = Convert.ToBoolean(Convert.ToInt16(s.Element("ritual").Value)); }
                if (s.Element("time") != null) { Spell.Time = s.Element("time").Value; }
                if (s.Element("range") != null) { Spell.Range = s.Element("range").Value; }
                if (s.Element("v") != null) { component.Add(Component.V); }
                if (s.Element("m") != null) { component.Add(Component.M); }
                if (s.Element("s") != null) { component.Add(Component.S); }
                if (s.Element("materials") != null) { Spell.MaterialComponent = s.Element("materials").Value; } else { Spell.MaterialComponent = "None."; }
                if (s.Element("duration") != null) { Spell.Duration = s.Element("duration").Value; }
                if (s.Element("text") != null) { Spell.Text = s.Element("text").Value; }
                foreach (XElement c in s.Descendants("sclass").ToArray())
                {
                    _class.Add(c.Value);
                }
                if (component.Count >= 1) { Spell.Component = component; }
                if (_class.Count >= 1) { Spell.Class = _class; }
                _spells.Add(Spell);
            }
            return _spells;
        }

        private void UnarmoredDefense(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            int _ac = 10 + Convert.ToInt16(printablePlayerCharacter.DexterityModifier);
            int acScore = 0;
            List<XElement> _classfeats = list.Descendants("class").Descendants("feat").Where(p=>p.Parent.Name!="autolevel").Where(n=>n.Descendants("name").FirstOrDefault().Value.ToLower().Contains("unarmored defense")).ToList();
            foreach (XElement xElement in _classfeats)
            {
                if (xElement.Descendants("value").FirstOrDefault() != null)
                    switch (Convert.ToInt16(xElement.Descendants("value").FirstOrDefault().Value))
                    {
                        case 3:
                            {
                                if (acScore < Convert.ToInt16(printablePlayerCharacter.ConstitutionModifier))
                                    acScore = Convert.ToInt16(printablePlayerCharacter.ConstitutionModifier);
                                break;
                            }
                        case 5:
                            {
                                if (acScore < Convert.ToInt16(printablePlayerCharacter.WisdomModifier))
                                    acScore = Convert.ToInt16(printablePlayerCharacter.WisdomModifier);
                                break;
                            }
                        default: { break; }
                    }
            }
            List<XElement> _magicItems = list.Descendants("item").Descendants("mod").Where(p => p.Descendants("type").FirstOrDefault() != null && p.Descendants("type").FirstOrDefault().Value == "10").ToList();
            if(_magicItems.Count>0)
                foreach(XElement e in _magicItems)
                {
                    acScore += Convert.ToInt16(e.Descendants("value").FirstOrDefault().Value);
                }
            _ac += acScore;
            printablePlayerCharacter.ArmorClass = _ac;
        }

        private void GenerateAC(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            int _ac = 0;
            List<XElement> _type = list.Descendants("type").Where(type => type.Value == "1" || type.Value == "2" || type.Value == "3" || type.Value == "4").Where(t=>t.Parent.Name=="item").ToList();
            List<XElement> FightingStyle = _sourceDoc.Descendants("class").Descendants("feat").Where(p => p.Parent.Name != "autolevel").Where(n => n.Descendants("text").FirstOrDefault().Value.ToLower().Contains("you are wearing armor, you gain a")).ToList();
            if (FightingStyle.Descendants("optional").FirstOrDefault() != null && FightingStyle.Descendants("optional").FirstOrDefault().Value == "1")
                _ac += 1;
            foreach (XElement item in _type)
            {
                if (item.Parent.Descendants("slot").FirstOrDefault() != null)
                    _ac += Convert.ToInt16(item.Parent.Descendants("ac").FirstOrDefault().Value);
                switch (item.Value)
                {
                    case "1":
                        { _ac += printablePlayerCharacter.DexterityModifier;break; }
                    case "2":
                        {
                            if (Convert.ToInt16(printablePlayerCharacter.DexterityModifier) > 2)
                                _ac += 2;
                            else
                                _ac += Convert.ToInt16(printablePlayerCharacter.DexterityModifier);
                            break;
                        }
                    default:
                        {
                            _ac += 0;
                            break;
                        }
                }
                if (item.Parent.Descendants("magic").FirstOrDefault() != null)
                {
                    XElement magic = item.Parent.Descendants("mod").FirstOrDefault();
                    if (magic.Descendants("value").FirstOrDefault() != null)
                        _ac += Convert.ToInt16(magic.Descendants("value").FirstOrDefault().Value);
                }
            }

            printablePlayerCharacter.ArmorClass = _ac;
        }

        private void GenerateSpeed(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            int _speed = 0;
            if (list.Descendants("race").Descendants("speed").FirstOrDefault() != null)
                _speed = Convert.ToInt16(list.Descendants("race").Descendants("speed").FirstOrDefault().Value);
            else
                _speed = 30;

            if (list.Descendants("feat").Descendants("mod").Descendants("type").Where(x => x.Value == "13").FirstOrDefault() != null)
            {
                var b = list.Descendants("feat").Descendants("mod").Descendants("type").Where(x => x.Value == "13" && x.Parent.Descendants("value").ToList() != null && x.Parent.Parent.Parent.Name == "character").ToList();
                if (b.Count > 0)
                    _speed += Convert.ToInt16(list.Descendants("feat").Descendants("mod").Descendants("type").Where(x => x.Value == "13" && x.Parent.Descendants("value").ToList() != null && x.Parent.Parent.Parent.Name == "character").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                else if (list.Descendants("feat").Descendants("mod").Descendants("type").Where(x => x.Value == "13").FirstOrDefault().Parent.Descendants("value").FirstOrDefault() != null)
                    _speed += Convert.ToInt16(list.Descendants("feat").Descendants("mod").Descendants("type").Where(x => x.Value == "13").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
            }
            printablePlayerCharacter.Speed = _speed;
        }

        private string GetDamageType(string DamageType)
        {
            switch (DamageType)
            {
                case "2": { return "P"; }
                case "3": { return "S"; }
                default: { return "B"; }
            }
        }

        private void GenerateWeapons(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            List<XElement> _weaponsInHand = list.Where(x => x.Descendants("slot").FirstOrDefault() != null &&
                Convert.ToInt16(x.Descendants("slot").FirstOrDefault().Value) > 1 &&
                Convert.ToInt16(x.Descendants("slot").FirstOrDefault().Value) < 5 &&
                Convert.ToInt16(x.Descendants("type").FirstOrDefault().Value) != 4 &&
                x.Descendants("type").FirstOrDefault() != null).ToList();
            List<XElement> _weaponsNotEquipeped = list.Where(x => x.Descendants("slot").FirstOrDefault() == null &&
                Convert.ToInt16(x.Descendants("type").FirstOrDefault().Value) != 4).ToList();
            List<XElement> _classBonus = _sourceDoc.Descendants("class").Descendants("feat").Descendants("mod").Elements("type").Where(x => x.Value == "2").ToList();
       


            for (int i = 0; i < 4; i++)
            {
                int _magicToHit = 0;
                int _magicToDamage = 0;
                string _DamageType = string.Empty;
                string _Damage = string.Empty;
                if(_classBonus.Count > 0)
                {
                    if (_classBonus.FirstOrDefault().Parent.Descendants("value").FirstOrDefault() != null)
                        _magicToDamage += Convert.ToInt16(_classBonus.FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                }
                if (i < _weaponsInHand.Count)
                {
                    XElement a = _weaponsInHand[i];
                    _DamageType = GetDamageType(a.Descendants("damageType").FirstOrDefault().Value);

                    if (a.Descendants("magic").FirstOrDefault() != null)
                    {
                        if (a.Descendants("mod").Descendants("type").Where(x => x.Value == "3" || x.Value == "5" || x.Value == "5" || x.Value == "6").FirstOrDefault() != null)
                        {
                            _magicToHit += Convert.ToInt16(a.Descendants("mod").Descendants("type").Where(x => x.Value == "3" || x.Value == "5").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                            _magicToDamage += Convert.ToInt16(a.Descendants("mod").Descendants("type").Where(x => x.Value == "4" || x.Value == "6").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                        }
                        if(a.Descendants("mod").Descendants("type").Where(x => x.Value == "7")!=null)
                        {
                            //This is spell attack bonus
                        }
                    }

                    switch (Convert.ToInt16(a.Descendants("slot").FirstOrDefault().Value))
                    {
                        case 2:
                            {
                                printablePlayerCharacter.WeaponName1 = a.Descendants("name").FirstOrDefault().Value;
                                int _property = Convert.ToInt16(a.Descendants("weaponProperty").FirstOrDefault().Value);
                                int _damageMod = 0;

                                if (Convert.ToInt16(printablePlayerCharacter.StrengthModifier) < Convert.ToInt16(printablePlayerCharacter.DexterityModifier))
                                    _damageMod = Convert.ToInt16(printablePlayerCharacter.DexterityModifier);
                                else
                                    _damageMod = Convert.ToInt16(printablePlayerCharacter.StrengthModifier);

                                if (a.Descendants("damage2H").FirstOrDefault() != null)
                                    _Damage = a.Descendants("damage1H").FirstOrDefault().Value;
                                else
                                    _Damage = a.Descendants("damage1H").FirstOrDefault().Value;
                                switch (_property)
                                {
                                    case 2:
                                    case 10:
                                    case 130:
                                    case 138:
                                    case 257:
                                    case 261:
                                    case 273:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + _damageMod + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + _damageMod}/{_DamageType}";
                                            break;
                                        }
                                    default:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + Convert.ToInt16(printablePlayerCharacter.StrengthModifier) + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + Convert.ToInt16(printablePlayerCharacter.StrengthModifier)}/{_DamageType}";
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                printablePlayerCharacter.WeaponName1 = a.Descendants("name").FirstOrDefault().Value;
                                int _property = Convert.ToInt16(a.Descendants("weaponProperty").FirstOrDefault().Value);
                                int _damageMod = 0;

                                if (Convert.ToInt16(printablePlayerCharacter.StrengthModifier) < Convert.ToInt16(printablePlayerCharacter.DexterityModifier))
                                    _damageMod = Convert.ToInt16(printablePlayerCharacter.DexterityModifier);
                                else
                                    _damageMod = Convert.ToInt16(printablePlayerCharacter.StrengthModifier);

                                if (a.Descendants("damage2H").FirstOrDefault() != null)
                                    _Damage = a.Descendants("damage2H").FirstOrDefault().Value;
                                else
                                    _Damage = a.Descendants("damage1H").FirstOrDefault().Value;

                                switch (_property)
                                {
                                    case 2:
                                    case 10:
                                    case 130:
                                    case 138:
                                    case 257:
                                    case 261:
                                    case 273:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + _damageMod + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + _damageMod}/{_DamageType}";
                                            break;
                                        }
                                    default:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + Convert.ToInt16(printablePlayerCharacter.StrengthModifier) + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + Convert.ToInt16(printablePlayerCharacter.StrengthModifier)}/{_DamageType}";
                                            break;
                                        }
                                }
                                break;
                            }
                        case 4:
                            {
                                printablePlayerCharacter.WeaponName1 = a.Descendants("name").FirstOrDefault().Value;
                                int _property = Convert.ToInt16(a.Descendants("weaponProperty").FirstOrDefault().Value);
                                int _damageMod = 0;

                                if (Convert.ToInt16(printablePlayerCharacter.StrengthModifier) < Convert.ToInt16(printablePlayerCharacter.DexterityModifier))
                                    _damageMod = 0;
                                else
                                    _damageMod = 0;

                                if (a.Descendants("damage2H").FirstOrDefault() != null)
                                    _Damage = a.Descendants("damage2H").FirstOrDefault().Value;
                                else
                                    _Damage = a.Descendants("damage1H").FirstOrDefault().Value;

                                switch (_property)
                                {
                                    case 2:
                                    case 10:
                                    case 130:
                                    case 138:
                                    case 257:
                                    case 261:
                                    case 273:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + _damageMod + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + _damageMod}/{_DamageType}";
                                            break;
                                        }
                                    default:
                                        {
                                            printablePlayerCharacter.WeaponAttackBonus1 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + Convert.ToInt16(printablePlayerCharacter.StrengthModifier) + _magicToHit)}";
                                            printablePlayerCharacter.WeaponDamageAndType1 = $"{_Damage} + {_magicToDamage + Convert.ToInt16(printablePlayerCharacter.StrengthModifier)}/{_DamageType}";
                                            break;
                                        }
                                }
                                break;
                            }
                        default: break;
                    }
                }
                else
                {
                    if (_weaponsNotEquipeped.Count >= i)
                    {
                        XElement a = _weaponsNotEquipeped[i - _weaponsInHand.Count];
                        _DamageType = GetDamageType(a.Descendants("damageType").FirstOrDefault().Value);
                        int _property = 0;
                        int _damageMod = 0;

                        if (a.Descendants("magic").FirstOrDefault() != null)
                        {
                            _magicToHit = Convert.ToInt16(a.Descendants("mod").Descendants("type").Where(x => x.Value == "3" || x.Value == "5").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                            _magicToDamage = Convert.ToInt16(a.Descendants("mod").Descendants("type").Where(x => x.Value == "4" || x.Value == "6").FirstOrDefault().Parent.Descendants("value").FirstOrDefault().Value);
                        }
                        if (a.Descendants("weaponProperty").FirstOrDefault() != null)
                            _property = Convert.ToInt16(a.Descendants("weaponProperty").FirstOrDefault().Value);

                        if (Convert.ToInt16(printablePlayerCharacter.StrengthModifier) < Convert.ToInt16(printablePlayerCharacter.DexterityModifier))
                            _damageMod = Convert.ToInt16(printablePlayerCharacter.DexterityModifier);
                        else
                            _damageMod = Convert.ToInt16(printablePlayerCharacter.StrengthModifier);

                        if (a.Descendants("damage2H").FirstOrDefault() != null)
                            _Damage = a.Descendants("damage1H").FirstOrDefault().Value;
                        else
                            _Damage = a.Descendants("damage1H").FirstOrDefault().Value;

                        switch (i)
                        {
                            case 0:
                            case 1:
                                {
                                    printablePlayerCharacter.WeaponName2 = a.Descendants("name").FirstOrDefault().Value;
                                    switch (_property)
                                    {
                                        case 2:
                                        case 10:
                                        case 130:
                                        case 138:
                                        case 257:
                                        case 261:
                                        case 273:
                                            {
                                                printablePlayerCharacter.WeaponAttackBonus2 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + _damageMod + _magicToHit)}";
                                                printablePlayerCharacter.WeaponDamageAndType2 = $"{_Damage} + {_magicToDamage + _damageMod}/{_DamageType}";
                                                break;
                                            }
                                        default:
                                            {
                                                printablePlayerCharacter.WeaponAttackBonus2 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + Convert.ToInt16(printablePlayerCharacter.StrengthModifier) + _magicToHit)}";
                                                printablePlayerCharacter.WeaponDamageAndType2 = $"{_Damage} + {_magicToDamage + Convert.ToInt16(printablePlayerCharacter.StrengthModifier)}/{_DamageType}";
                                                break;
                                            }
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    printablePlayerCharacter.WeaponName3 = a.Descendants("name").FirstOrDefault().Value;
                                    switch (_property)
                                    {
                                        case 2:
                                        case 10:
                                        case 130:
                                        case 138:
                                        case 257:
                                        case 261:
                                        case 273:
                                            {
                                                printablePlayerCharacter.WeaponAttackBonus3 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + _damageMod + _magicToHit)}";
                                                printablePlayerCharacter.WeaponDamageAndType3 = $"{_Damage} + {_magicToDamage + _damageMod}/{_DamageType}";
                                                break;
                                            }
                                        default:
                                            {
                                                printablePlayerCharacter.WeaponAttackBonus3 = $"+{(Convert.ToInt16(printablePlayerCharacter.ProficencyBonus) + Convert.ToInt16(printablePlayerCharacter.StrengthModifier) + _magicToHit)}";
                                                printablePlayerCharacter.WeaponDamageAndType3 = $"{_Damage} + {_magicToDamage + Convert.ToInt16(printablePlayerCharacter.StrengthModifier)}/{_DamageType}";
                                                break;
                                            }
                                    }
                                    break;
                                }
                            default: break;
                        }
                    }
                }
            }
        }

        private void GenerateTreasure(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            string _existing = printablePlayerCharacter.Equipment2;
            string _treasure = string.Empty;
            List<XElement> _list = list.Descendants("name").Where(n => n.Value.ToLower().Contains("(") && n.Value.ToLower().Contains("p)")).ToList();
            _list.AddRange(list.Descendants("name").Where(n => n.Value.ToLower().Contains(" gp ") || 
                n.Value.ToLower().Contains(" cp ") || 
                n.Value.ToLower().Contains(" pp ")).ToList());
            foreach(XElement i in _list)
            {
                string qty = "1";
                if (i.Parent.Descendants("quantity").FirstOrDefault() != null)
                    qty = i.Parent.Descendants("quantity").FirstOrDefault().Value;
                _treasure += $"({qty}) {i.Value}, ";
            }
            _treasure += $"\n\n";
            _existing += _treasure;
            printablePlayerCharacter.Equipment2 = _existing;
        }

        private void GenerateLanguagesAndProficencies(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> backgroundList)
        {
            string _languages = string.Empty;
            string _Proficencies = string.Empty;
            var _list = backgroundList.Descendants("feat").Descendants("name").Where(n => n.Value.ToLower().Contains("lang")).ToList();
            var _prof = backgroundList.Descendants("class").Descendants("feat").Descendants("name").Where(n => n.Value.ToLower().Contains("starting profic")).ToList();
            foreach(XElement i in _list)
            {
                _languages += $"{i.Parent.Descendants("text").FirstOrDefault().Value} ";
            }
            foreach(XElement a in _prof)
            {
                if (a.Parent.Parent.Name != "autolevel")
                {
                    StringBuilder sb = new StringBuilder(a.Parent.Descendants("text").FirstOrDefault().Value);
                    string search1 = $"You are proficient with the following items, in addition to any proficiencies provided by your race or background.";
                    sb.Replace(search1, "");
                    sb.Remove(0, 1);
                    var _replace2 = sb.ToString().Substring(sb.ToString().IndexOf("Skills"));
                    sb.Replace(_replace2, "");
                    sb.Remove(sb.Length - 1,1);
                    _Proficencies += $"{sb.ToString()}\n";
                }
            }

            printablePlayerCharacter.ProficiencesAndLanguages = $"{_languages}\n\n{_Proficencies}";
        }

        private void GenerateRaicalInfo(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            printablePlayerCharacter.Race = list.Descendants("name").FirstOrDefault().Value;
            printablePlayerCharacter.Age = list.Descendants("age").FirstOrDefault().Value;
            printablePlayerCharacter.Height = list.Descendants("height").FirstOrDefault().Value;
            printablePlayerCharacter.Weight = list.Descendants("weight").FirstOrDefault().Value;
            printablePlayerCharacter.Eyes = list.Descendants("eyes").FirstOrDefault().Value;
            printablePlayerCharacter.Skin = list.Descendants("skin").FirstOrDefault().Value;
            printablePlayerCharacter.Hair = list.Descendants("hair").FirstOrDefault().Value;
        }

        private void GenerateFeatsAndTraits(PrintablePlayerCharacter printablePlayerCharacter, List<XElement> list)
        {
            string _currentFeatsAndTraits = printablePlayerCharacter.FeaturesAndTraits1;
            string _featsAndtraits = string.Empty;
            string _header = string.Empty;
            string _output = string.Empty;
            foreach (XElement i in list)
            {
                string _name = string.Empty;
                string _value = string.Empty;
                if (i.Parent.Name != "class")
                {
                    if (string.IsNullOrEmpty(_header))
                        _header = $"******** FEATS ********\n";
                    _name = i.Descendants("name").FirstOrDefault().Value.ToUpper();
                    _value = $"{i.Descendants("text").FirstOrDefault().Value}";
                    _featsAndtraits += $"{_name}\n{_value}\n\n";
                }
                else
                {
                    if (string.IsNullOrEmpty(_header))
                        _header = $"*** CLASS FEATURES ***\n";
                    _name = i.Descendants("name").FirstOrDefault().Value;
                    _featsAndtraits += $"{_name}, ";
                }                
            }
            _featsAndtraits += "\n";
            _output = $"{_header}\n{_featsAndtraits}\n{_currentFeatsAndTraits}";
            printablePlayerCharacter.FeaturesAndTraits1 = _output;
        }

        private int ReturnValue (XElement xElement)
        {
            if (xElement == null)
                return 0;
            else
                return Convert.ToInt32(xElement.Value);
        }

        private string ReturnString (IEnumerable<XElement> xElements)
        {
            string returnString = string.Empty;
            List<XElement> _xElements = xElements.ToList();
            for (int i = 0; i < _xElements.Count; i++)
            {
                XElement xElement = _xElements[i];
                if (xElement.Elements("name").FirstOrDefault() != null)
                {
                    switch (xElement.Elements("name").First().Value)
                    {
                        default:
                            {
                                if(xElement.Elements("quantity").FirstOrDefault() != null)
                                {
                                    returnString = returnString + $"({xElement.Elements("quantity").FirstOrDefault().Value}) ";
                                }
                                returnString = returnString + $"{xElement.Elements("name").First().Value}";
                                break;
                            }
                    }
                }
                if(i + 1 < _xElements.Count)
                {
                    returnString = returnString + $", ";
                }
                else
                {
                    returnString = returnString + $"\n";
                }
            }
            return returnString;
        }

        private void ReturnAttributes (PrintablePlayerCharacter printablePlayerCharacter, IEnumerable<XElement> xElements)
        {
            string[] _attributes = xElements.Descendants("abilities").FirstOrDefault().Value.Split(',');

            for (int i = 0; i < _attributes.Length - 1; i++)
            {
                int _score = Convert.ToInt16(_attributes[i]);
                switch (i)
                {
                    case 0: { printablePlayerCharacter.Strength = _score; printablePlayerCharacter.StrengthModifier = SetModifier(_score); break; }
                    case 1: { printablePlayerCharacter.Dexterity = _score; printablePlayerCharacter.DexterityModifier = SetModifier(_score); break; }
                    case 2: { printablePlayerCharacter.Constitution = _score; printablePlayerCharacter.ConstitutionModifier = SetModifier(_score); break; }
                    case 3: { printablePlayerCharacter.Intelligence = _score; printablePlayerCharacter.IntelligenceModifier = SetModifier(_score); break; }
                    case 4: { printablePlayerCharacter.Wisdom = _score; printablePlayerCharacter.WisdomModifier = SetModifier(_score); break; }
                    case 5: { printablePlayerCharacter.Charisma = _score; printablePlayerCharacter.CharismaModifier = SetModifier(_score); break; }
                    default: break;
                }
            }

            if ((xElements.Descendants("race").Elements("feat").Elements("name").Where(e => e.Value.ToLower() == "ability score increase").FirstOrDefault() != null) ||
                (xElements.Descendants("race").Elements("mod").Elements("category").FirstOrDefault().Value == "1"))
            {
                var _modifiers = xElements.Descendants("race").Elements("feat").Elements("mod").ToList();
                if(_modifiers.Count < 1) { _modifiers = xElements.Descendants("race").Elements("mod").ToList(); }
                foreach (var ability in _modifiers)
                {
                    int a = 0;
                    int b = 0;
                    if (ability.Element("type") != null) { a = Convert.ToInt16(ability.Element("type").Value); }
                    if (ability.Element("value") != null) { b = Convert.ToInt16(ability.Element("value").Value); }
                    XmlAbilityModification(printablePlayerCharacter, a, b);
                }
            }
        }

        private int SetModifier(int score)
        {
            int modifier = -5;
            switch (score)
            {
                case 1: { modifier = -5; break; }
                case int n when (score > 1 && score < 4): { modifier = -4; break; }
                case int n when (score > 3 && score < 6): { modifier = -3; break; }
                case int n when (score > 5 && score < 8): { modifier = -2; break; }
                case int n when (score > 7 && score < 10): { modifier = -1; break; }
                case int n when (score > 9 && score < 12): { modifier = 0; break; }
                case int n when (score > 11 && score < 14): { modifier = 1; break; }
                case int n when (score > 13 && score < 16): { modifier = 2; break; }
                case int n when (score > 15 && score < 18): { modifier = 3; break; }
                case int n when (score > 17 && score < 20): { modifier = 4; break; }
                case int n when (score > 19 && score < 22): { modifier = 5; break; }
                case int n when (score > 21 && score < 24): { modifier = 6; break; }
                case int n when (score > 23 && score < 26): { modifier = 7; break; }
                case int n when (score > 25 && score < 28): { modifier = 8; break; }
                case int n when (score > 27 && score < 30): { modifier = 9; break; }
                case int n when (score < 31): { modifier = 10; break; }
                default:
                    break;
            }
            return modifier;
        }

        private void XmlAbilityModification(PrintablePlayerCharacter playerCharacter, int AbilityName, int AbilityModifier)
        {
            switch (AbilityName)
            {
                case 0: { playerCharacter.Strength += AbilityModifier; playerCharacter.StrengthModifier = SetModifier(playerCharacter.Strength); break; }
                case 1: { playerCharacter.Dexterity += AbilityModifier; playerCharacter.DexterityModifier = SetModifier(playerCharacter.Dexterity); break; }
                case 2: { playerCharacter.Constitution += AbilityModifier; playerCharacter.ConstitutionModifier = SetModifier(playerCharacter.Constitution); break; }
                case 3: { playerCharacter.Intelligence += AbilityModifier; playerCharacter.IntelligenceModifier = SetModifier(playerCharacter.Intelligence); break; }
                case 4: { playerCharacter.Wisdom += AbilityModifier; playerCharacter.WisdomModifier = SetModifier(playerCharacter.Wisdom); break; }
                case 5: { playerCharacter.Charisma += AbilityModifier; playerCharacter.CharismaModifier = SetModifier(playerCharacter.Charisma); break; }
                default:
                    { break; }
            }
        }

        private void WriteBackgroundInfo(PrintablePlayerCharacter printablePlayerCharacter, IEnumerable<XElement> xElements)
        {
            string _backgroundNotes = string.Empty;
            if (xElements.Descendants("background").Elements("name").FirstOrDefault() != null)
                printablePlayerCharacter.Background = xElements.Descendants("background").Elements("name").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("align").FirstOrDefault() != null)
                printablePlayerCharacter.Alignment = xElements.Descendants("background").Elements("align").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("faction").FirstOrDefault() != null)
                printablePlayerCharacter.FactionName = xElements.Descendants("background").Elements("faction").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("personality").FirstOrDefault() != null)
                printablePlayerCharacter.PersonalityTraits = xElements.Descendants("background").Elements("personality").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("ideals").FirstOrDefault() != null)
                printablePlayerCharacter.PersonalityIdeals = xElements.Descendants("background").Elements("ideals").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("bonds").FirstOrDefault() != null)
                printablePlayerCharacter.PersonalityBonds = xElements.Descendants("background").Elements("bonds").FirstOrDefault().Value;
            if (xElements.Descendants("background").Elements("flaws").FirstOrDefault() != null)
                printablePlayerCharacter.PersonalityFlaws = xElements.Descendants("background").Elements("flaws").FirstOrDefault().Value;
            if (xElements.Descendants("background").Descendants("feat").Descendants("name").Where(n => n.Value.ToLower().Contains("feature")).FirstOrDefault() != null)
                GenerateBackStory(printablePlayerCharacter, xElements.Descendants("background").Descendants("feat").Descendants("name").Where(n => n.Value.ToLower().Contains("feature")));
            if (xElements.Descendants("note").FirstOrDefault() != null)
                GenerateBackStory(printablePlayerCharacter, xElements.Descendants("note"));
        }

        private void GenerateBackStory(PrintablePlayerCharacter printablePlayerCharacter, IEnumerable<XElement> xElements)
        {
            string _backstory = printablePlayerCharacter.BackStory;
            string _workingBackstory = string.Empty;
            List<XElement> backstory = xElements.ToList();
            foreach(XElement a in backstory)
            {
                string _title = string.Empty;
                string _text = string.Empty;
                if (a.Descendants("name").FirstOrDefault() != null)
                    _title = a.Descendants("name").FirstOrDefault().Value.ToUpper();
                else
                    _title = a.Parent.Descendants("name").FirstOrDefault().Value.ToUpper();
                if (a.Descendants("text").FirstOrDefault() != null)
                    _text = a.Descendants("text").FirstOrDefault().Value;
                else
                    _text = a.Parent.Descendants("text").FirstOrDefault().Value;
                _workingBackstory = $"{_title}\n\n{_text}\n";
            }
            printablePlayerCharacter.BackStory = $"{_backstory}\n\n{_workingBackstory}";
        }

        private void GenerateSkillProficiency(PrintablePlayerCharacter printablePlayerCharacter, IEnumerable<XElement> xElements, IEnumerable<XElement> xElementsEpertise)
        {
            foreach (XElement s in xElements)
            {
                switch (s.Value)
                {
                    case "0": { printablePlayerCharacter.SaveThrowStrength = true; break; }
                    case "1": { printablePlayerCharacter.SaveThrowDexterity = true; break; }
                    case "2": { printablePlayerCharacter.SaveThrowConstitution = true; ; break; }
                    case "3": { printablePlayerCharacter.SaveThrowIntelligence = true; break; }
                    case "4": { printablePlayerCharacter.SaveThrowWisdom = true; break; }
                    case "5": { printablePlayerCharacter.SaveThrowCharisma = true; break; }
                    case "100": { printablePlayerCharacter.ProficencyAcrobatics = true; break; }
                    case "101": { printablePlayerCharacter.ProficencyAnimalHandling = true; break; }
                    case "102": { printablePlayerCharacter.ProficencyArcana = true; break; }
                    case "103": { printablePlayerCharacter.ProficencyAthletics = true; break; }
                    case "104": { printablePlayerCharacter.ProficencyDeception = true; break; }
                    case "105": { printablePlayerCharacter.ProficencyHistory = true; break; }
                    case "106": { printablePlayerCharacter.ProficencyInsight = true; break; }
                    case "107": { printablePlayerCharacter.ProficencyIntimidation = true; break; }
                    case "108": { printablePlayerCharacter.ProficencyInvestigation = true; break; }
                    case "109": { printablePlayerCharacter.ProficencyMedicine = true; break; }
                    case "110": { printablePlayerCharacter.ProficencyNature = true; break; }
                    case "111": { printablePlayerCharacter.ProficencyPerception = true; break; }
                    case "112": { printablePlayerCharacter.ProficencyPerformance = true; break; }
                    case "113": { printablePlayerCharacter.ProficencyPersuasion = true; break; }
                    case "114": { printablePlayerCharacter.ProficencyReligion = true; break; }
                    case "115": { printablePlayerCharacter.ProficencySlieghtOfHand = true; break; }
                    case "116": { printablePlayerCharacter.ProficencyStealth = true; break; }
                    case "117": { printablePlayerCharacter.ProficencySurvival = true; break; }
                    default: break;
                }
            }

            foreach (XElement s2 in xElementsEpertise)
            {
                if ((s2.Descendants("category").FirstOrDefault() != null) && (s2.Descendants("category").FirstOrDefault().Value == "4"))
                {
                    string _value = "0";
                    if (s2.Descendants("type").FirstOrDefault() != null)
                        _value = s2.Descendants("type").FirstOrDefault().Value;
                    switch (_value)
                    {
                        case "0": { printablePlayerCharacter.ExpertiseAcrobatics = true; break; }
                        case "1": { printablePlayerCharacter.ExpertiseAnimalHandling = true; break; }
                        case "2": { printablePlayerCharacter.ExpertiseArcana = true; break; }
                        case "3": { printablePlayerCharacter.ExpertiseAthletics = true; break; }
                        case "4": { printablePlayerCharacter.ExpertiseDeception = true; break; }
                        case "5": { printablePlayerCharacter.ExpertiseHistory = true; break; }
                        case "6": { printablePlayerCharacter.ExpertiseInsight = true; break; }
                        case "7": { printablePlayerCharacter.ExpertiseIntimidation = true; break; }
                        case "8": { printablePlayerCharacter.ExpertiseInvestigation = true; break; }
                        case "9": { printablePlayerCharacter.ExpertiseMedicine = true; break; }
                        case "10": { printablePlayerCharacter.ExpertiseNature = true; break; }
                        case "11": { printablePlayerCharacter.ExpertisePerception = true; break; }
                        case "12": { printablePlayerCharacter.ExpertisePerformance = true; break; }
                        case "13": { printablePlayerCharacter.ExpertisePersuasion = true; break; }
                        case "14": { printablePlayerCharacter.ExpertiseReligion = true; break; }
                        case "15": { printablePlayerCharacter.ExpertiseSlieghtOfHand = true; break; }
                        case "16": { printablePlayerCharacter.ExpertiseStealth = true; break; }
                        case "17": { printablePlayerCharacter.ExpertiseSurvival = true; break; }
                        default: { break; }
                    }
                }
            }
            GenerateProficencyBonus(printablePlayerCharacter);
            GenerateSkillModifiers(printablePlayerCharacter);
        }

        private void GenerateProficencyBonus(PrintablePlayerCharacter printablePlayerCharacter)
        {
            int _level;
            int _XP = printablePlayerCharacter.ExperiencePoints;
            int _proficencyBonus;
            switch (_XP)
            {
                case int n when (_XP > 0 && _XP <= 299): _level = 1; _proficencyBonus = 2; break;
                case int n when (_XP > 300 && _XP <= 899): _level = 2; _proficencyBonus = 2; break;
                case int n when (_XP > 900 && _XP <= 2799): _level = 3; _proficencyBonus = 2; break;
                case int n when (_XP > 2700 && _XP <= 6499): _level = 4; _proficencyBonus = 2; break;
                case int n when (_XP > 6500 && _XP <= 13999): _level = 5; _proficencyBonus = 3; break;
                case int n when (_XP > 14000 && _XP <= 22999): _level = 6; _proficencyBonus = 3; break;
                case int n when (_XP > 23000 && _XP <= 33999): _level = 7; _proficencyBonus = 3; break;
                case int n when (_XP > 34000 && _XP <= 47999): _level = 8; _proficencyBonus = 3; break;
                case int n when (_XP > 48000 && _XP <= 63999): _level = 9; _proficencyBonus = 4; break;
                case int n when (_XP > 64000 && _XP <= 84999): _level = 10; _proficencyBonus = 4; break;
                case int n when (_XP > 85000 && _XP <= 99999): _level = 11; _proficencyBonus = 4; break;
                case int n when (_XP > 100000 && _XP <= 119999): _level = 12; _proficencyBonus = 4; break;
                case int n when (_XP > 120000 && _XP <= 139999): _level = 13; _proficencyBonus = 5; break;
                case int n when (_XP > 140000 && _XP <= 164999): _level = 14; _proficencyBonus = 5; break;
                case int n when (_XP > 165000 && _XP <= 194999): _level = 15; _proficencyBonus = 5; break;
                case int n when (_XP > 195000 && _XP <= 224999): _level = 16; _proficencyBonus = 5; break;
                case int n when (_XP > 225000 && _XP <= 164999): _level = 17; _proficencyBonus = 6; break;
                case int n when (_XP > 265000 && _XP <= 304999): _level = 18; _proficencyBonus = 6; break;
                case int n when (_XP > 305000 && _XP <= 354999): _level = 19; _proficencyBonus = 6; break;
                case int n when (_XP > 355000): _level = 20; _proficencyBonus = 6; break;
                default: _level = 0; _proficencyBonus = 2; break;
            }
            printablePlayerCharacter.ProficencyBonus = _proficencyBonus;
        }

        private void GenerateSkillModifiers(PrintablePlayerCharacter p)
        {
            p.SaveThrowCharismaModifier = p.CharismaModifier;
            if (p.SaveThrowCharisma)
                p.SaveThrowCharismaModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowCharisma)
                p.SaveThrowCharismaModifier += p.ProficencyBonus;

            p.SaveThrowConstitutionModifier = p.ConstitutionModifier;
            if (p.SaveThrowConstitution)
                p.SaveThrowConstitutionModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowConstitution)
                p.SaveThrowConstitutionModifier += p.ProficencyBonus;

            p.SaveThrowDexterityModifier = p.DexterityModifier;
            if (p.SaveThrowDexterity)
                p.SaveThrowDexterityModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowDexterity)
                p.SaveThrowDexterityModifier += p.ProficencyBonus;

            p.SaveThrowIntelligenceModifier = p.IntelligenceModifier;
            if (p.SaveThrowIntelligence)
                p.SaveThrowIntelligenceModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowIntelligence)
                p.SaveThrowIntelligenceModifier += p.ProficencyBonus;

            p.SaveThrowStrengthModifier = p.StrengthModifier;
            if (p.SaveThrowStrength)
                p.SaveThrowStrengthModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowStrength)
                p.SaveThrowStrengthModifier += p.ProficencyBonus;

            p.SavethrowWisdomModifier = p.WisdomModifier;
            if (p.SaveThrowWisdom)
                p.SavethrowWisdomModifier += p.ProficencyBonus;
            if (p.ExpertiseSaveThrowWisdom)
                p.SavethrowWisdomModifier += p.ProficencyBonus;

            p.AthleticsModifier = p.StrengthModifier;
            if (p.ProficencyAcrobatics)
                p.AthleticsModifier += p.ProficencyBonus;
            if (p.ExpertiseAthletics)
                p.AthleticsModifier += p.ProficencyBonus;

            p.AcobaticsModifier = p.DexterityModifier;
            if (p.ProficencyAcrobatics)
                p.AcobaticsModifier += p.ProficencyBonus;
            if (p.ExpertiseAcrobatics)
                p.AcobaticsModifier += p.ProficencyBonus;

            p.SlieghtOfHandModifier = p.DexterityModifier;
            if (p.ProficencySlieghtOfHand)
                p.SlieghtOfHandModifier += p.ProficencyBonus;
            if (p.ExpertiseSlieghtOfHand)
                p.SlieghtOfHandModifier += p.ProficencyBonus;

            p.StealthModifier = p.DexterityModifier;
            if (p.ProficencyStealth)
                p.StealthModifier += p.ProficencyBonus;
            if (p.ExpertiseStealth)
                p.StealthModifier += p.ProficencyBonus;

            p.ArcanaModifier = p.IntelligenceModifier;
            if (p.ProficencyArcana)
                p.ArcanaModifier += p.ProficencyBonus;
            if (p.ExpertiseArcana)
                p.ArcanaModifier += p.ProficencyBonus;

            p.HistoryModifier = p.IntelligenceModifier;
            if (p.ProficencyHistory)
                p.HistoryModifier = p.ProficencyBonus;
            if (p.ExpertiseHistory)
                p.HistoryModifier = p.ProficencyBonus;

            p.InvestigationModifier = p.IntelligenceModifier;
            if (p.ProficencyInvestigation)
                p.InvestigationModifier += p.ProficencyBonus;
            if (p.ExpertiseInvestigation)
                p.InvestigationModifier += p.ProficencyBonus;

            p.NatureModifier = p.IntelligenceModifier;
            if (p.ProficencyNature)
                p.NatureModifier += p.ProficencyBonus;
            if (p.ExpertiseNature)
                p.NatureModifier += p.ProficencyBonus;

            p.ReligionModifier = p.IntelligenceModifier;
            if (p.ProficencyReligion)
                p.ReligionModifier += p.ProficencyBonus;
            if (p.ExpertiseReligion)
                p.ReligionModifier += p.ProficencyBonus;

            p.AnimalHandlingModifier = p.WisdomModifier;
            if (p.ProficencyAnimalHandling)
                p.AnimalHandlingModifier += p.ProficencyBonus;
            if (p.ExpertiseAnimalHandling)
                p.AnimalHandlingModifier += p.ProficencyBonus;

            p.InsightModifier = p.WisdomModifier;
            if (p.ProficencyInsight)
                p.InsightModifier += p.ProficencyBonus;
            if (p.ExpertiseInsight)
                p.InsightModifier += p.ProficencyBonus;
            
            p.MedicineModifier = p.WisdomModifier;
            if (p.ProficencyMedicine)
                p.MedicineModifier += p.ProficencyBonus;
            if (p.ExpertiseMedicine)
                p.MedicineModifier += p.ProficencyBonus;

            p.PerceptionModifer = p.WisdomModifier;
            if (p.ProficencyPerception)
                p.PerceptionModifer += p.ProficencyBonus;
            if (p.ExpertisePerception)
                p.PerceptionModifer += p.ProficencyBonus;

            p.SurvivalModifier = p.WisdomModifier;
            if (p.ProficencySurvival)
                p.SurvivalModifier += p.ProficencyBonus;
            if (p.ExpertiseSurvival)
                p.SurvivalModifier += p.ProficencyBonus;

            p.DeceptionModifier = p.CharismaModifier;
            if (p.ProficencyDeception)
                p.DeceptionModifier += p.ProficencyBonus;
            if (p.ExpertiseDeception)
                p.DeceptionModifier += p.ProficencyBonus;

            p.IntimidationModifier = p.CharismaModifier;
            if (p.ProficencyIntimidation)
                p.IntimidationModifier += p.ProficencyBonus;
            if (p.ExpertiseIntimidation)
                p.IntimidationModifier += p.ProficencyBonus;

            p.PerformanceModifier = p.CharismaModifier;
            if (p.ProficencyPerformance)
                p.PerformanceModifier += p.ProficencyBonus;
            if (p.ExpertisePerformance)
                p.PerformanceModifier += p.ProficencyBonus;

            p.PersuasionModifier = p.CharismaModifier;
            if (p.ProficencyPersuasion)
                p.PersuasionModifier += p.ProficencyBonus;
            if (p.ExpertisePersuasion)
                p.PersuasionModifier += p.ProficencyBonus;
        }

        private void GenerateClassAndLevel(PrintablePlayerCharacter p, IEnumerable<XElement> xElements)
        {
            string _classandLevel = string.Empty;
            List<XElement> list = xElements.ToList();
            for (int a = 0; a < list.Count; a++)
            {
                XElement i = list[a];
                string t = $"{i.Descendants("name").FirstOrDefault().Value}";
                if (i.Element("level") != null)
                    t += $" ({i.Element("level").Value})";
                else
                    t += $" (1)";

                _classandLevel += $"{t} ";
                if (a < list.Count - 1)
                    _classandLevel += $"/";
            }
            p.ClassLevel = _classandLevel;
        }

        private void GenerateHitDice(PrintablePlayerCharacter p, IEnumerable<XElement> xElements)
        {
            string _hitdiceTotal = string.Empty;
            string _hitdice = string.Empty;
            List<XElement> list = xElements.ToList();
            for (int a = 0; a < list.Count; a++)
            {
                XElement i = list[a];
                string _tempCurrent = "1";
                string _temp = "1";
                if (i.Descendants("hd").FirstOrDefault() != null)
                    _temp = $"{i.Descendants("hd").FirstOrDefault().Value}";

                if (i.Descendants("hdCurrent").FirstOrDefault() != null)
                    _tempCurrent = $"{i.Descendants("hdCurrent").FirstOrDefault().Value}";
                switch (_temp)
                {
                    case "1": { _hitdice = $"D6"; break; }
                    case "2": { _hitdice = $"D8"; break; }
                    case "3": { _hitdice = $"D10"; break; }
                    case "4": { _hitdice = $"D12"; break; }
                    default: { break; }
                }
                _hitdiceTotal += $"{_tempCurrent}{_hitdice}";
                if (a < list.Count - 1)
                {
                    _hitdiceTotal += $" + ";
                }
            }
            p.HitDiceTotal = _hitdiceTotal;
            p.HitDice = _hitdiceTotal;
        }
    }
}
