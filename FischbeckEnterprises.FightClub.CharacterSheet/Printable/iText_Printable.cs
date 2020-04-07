using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Forms;
using iText.Kernel.Font;
using iText.IO.Image;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Printable
{
    partial class PDFCreator
    {
        readonly PrintablePlayerCharacter _character;
        readonly string Main_Sheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Sources\\Main_Sheet.pdf";
        readonly string Details_Sheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Sources\\Details_Sheet.pdf";
        readonly string Spells_Sheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Sources\\Spells_Sheet.pdf";
        readonly string Working_Sheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Output\\Working\\Working_Sheet.pdf";
        readonly string Character_Image = string.Empty;
        readonly string Faction_Image = string.Empty;
        private string _FinishedCharacterSheet = string.Empty;
        public PDFCreator() { }
        public PDFCreator(PrintablePlayerCharacter printablePlayerCharacter)
        {
            this._character = printablePlayerCharacter;
            this._FinishedCharacterSheet = $"{System.IO.Directory.GetCurrentDirectory()}\\Output\\{printablePlayerCharacter.CharacterName}.pdf";
            if (_character.CharacterImageFilePath != null)
            {
                if (File.Exists($"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{_character.CharacterImageFilePath}.jpeg"))
                    this.Character_Image = $"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{_character.CharacterImageFilePath}.jpeg";
                if (File.Exists($"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{_character.CharacterName}.jpeg"))
                    this.Character_Image = $"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{_character.CharacterName}.jpeg";
                if (File.Exists(_character.FactionImageFilePath))
                    this.Faction_Image = _character.FactionImageFilePath;
            }

            BuildCharacterSheet();
            //BuildSpellSheet();
        }

        private async void BuildCharacterSheet()
        {
            using (PdfDocument _pdfDocument = new PdfDocument(new PdfReader(Main_Sheet), new PdfWriter(_FinishedCharacterSheet)))
            {
                PdfAcroForm form = PdfAcroForm.GetAcroForm(_pdfDocument, true);

                form.GetField("charactername").SetValue($"{_character.CharacterName}").SetFontSizeAutoScale();
                form.GetField("classlevel").SetValue($"{_character.ClassLevel}").SetFontSizeAutoScale();
                (form.GetField("background").SetValue($"{_character.Background}")).SetFontSize(FontSize(_character.Background.Length));
                form.GetField("race").SetValue($"{_character.Race}").SetFontSizeAutoScale();
                form.GetField("playername").SetValue($"{_character.PlayerName}").SetFontSizeAutoScale();
                form.GetField("alignment").SetValue($"{_character.Alignment}").SetFontSizeAutoScale();
                form.GetField("xp").SetValue($"{_character.ExperiencePoints}");
                form.GetField("proficencybonus").SetValue($"+{_character.ProficencyBonus}");
                form.GetField("inspiration").SetValue($"{_character.Inspiration}");
                form.GetField("strmodifier").SetValue($"{_character.StrengthModifier}");
                form.GetField("str").SetValue($"{_character.Strength}");
                form.GetField("dexmodifier").SetValue($"{_character.DexterityModifier}");
                form.GetField("dex").SetValue($"{_character.Dexterity}");
                form.GetField("conmodifier").SetValue($"{_character.ConstitutionModifier}");
                form.GetField("con").SetValue($"{_character.Constitution}");
                form.GetField("intmodifier").SetValue($"{_character.IntelligenceModifier}");
                form.GetField("int").SetValue($"{_character.Intelligence}");
                form.GetField("wismodifier").SetValue($"{_character.WisdomModifier}");
                form.GetField("wis").SetValue($"{_character.Wisdom}");
                form.GetField("chamod").SetValue($"{_character.CharismaModifier}");
                form.GetField("cha").SetValue($"{_character.Charisma}");

                if (_character.SaveThrowStrength)
                {
                    form.GetField("savingthrowstr").SetValue($"{_character.SaveThrowStrength}");
                }
                form.GetField("savingthrowmodifierstr").SetValue($"{_character.SaveThrowStrengthModifier}");

                if (_character.ProficencyAthletics)
                {
                    form.GetField("athleticsproficency").SetValue($"{_character.ProficencyAthletics}");
                }
                form.GetField("athleticsmodifier").SetValue($"{_character.AthleticsModifier}");

                if (_character.SaveThrowDexterity)
                {
                    form.GetField("savingthrowdex").SetValue($"{_character.SaveThrowDexterity}");
                }
                form.GetField("savingthrowmodifierdex").SetValue($"{_character.SaveThrowDexterityModifier}");

                if (_character.ProficencyAcrobatics)
                {
                    form.GetField("acrobaticsproficency").SetValue($"{_character.ProficencyAcrobatics}");
                }
                form.GetField("acrobaticsmodifier").SetValue($"{_character.AcobaticsModifier}");

                if (_character.ProficencySlieghtOfHand)
                {
                    form.GetField("sleightofhandproficency").SetValue($"{_character.ProficencySlieghtOfHand}");
                }
                form.GetField("sleightofhandmodifier").SetValue($"{_character.SlieghtOfHandModifier}");

                if (_character.ProficencyStealth)
                {
                    form.GetField("stealthproficency").SetValue($"{_character.ProficencyStealth}");
                }
                form.GetField("stealthmodifier").SetValue($"{_character.StealthModifier}");

                if (_character.SaveThrowConstitution)
                {
                    form.GetField("savingthrowcon").SetValue($"{_character.SaveThrowConstitution}");
                }
                form.GetField("savingthrowmodifiercon").SetValue($"{_character.SaveThrowConstitutionModifier}");

                if (_character.SaveThrowIntelligence)
                {
                    form.GetField("savingthrowint").SetValue($"{_character.SaveThrowIntelligence}");
                }
                form.GetField("savingthrowmodifierint").SetValue($"{_character.SaveThrowIntelligenceModifier}");

                if (_character.ProficencyArcana)
                {
                    form.GetField("arcanaproficency").SetValue($"{_character.ProficencyArcana}");
                }
                form.GetField("arcanamodifier").SetValue($"{_character.ArcanaModifier}");

                if (_character.ProficencyHistory)
                {
                    form.GetField("historyproficency").SetValue($"{_character.ProficencyHistory}");
                }
                form.GetField("historymodifier").SetValue($"{_character.HistoryModifier}");

                if (_character.ProficencyInvestigation)
                {
                    form.GetField("investigationproficency").SetValue($"{_character.ProficencyInvestigation}");
                }
                form.GetField("investigationmodifier").SetValue($"{_character.InvestigationModifier}");

                if (_character.ProficencyNature)
                {
                    form.GetField("natureproficency").SetValue($"{_character.ProficencyNature}");
                }
                form.GetField("naturemodifier").SetValue($"{_character.NatureModifier}");

                if (_character.ProficencyReligion)
                {
                    form.GetField("religionproficency").SetValue($"{_character.ProficencyReligion}");
                }
                form.GetField("religionmodifier").SetValue($"{_character.ReligionModifier}");

                if (_character.SaveThrowWisdom)
                {
                    form.GetField("savingthrowwis").SetValue($"{_character.SaveThrowWisdom}");
                }
                form.GetField("savingthrowmodifierwis").SetValue($"{_character.SavethrowWisdomModifier}");

                if (_character.ProficencyAnimalHandling)
                {
                    form.GetField("animalhandlingproficency").SetValue($"{_character.ProficencyAnimalHandling}");
                }
                form.GetField("animalhandlingmodifier").SetValue($"{_character.AnimalHandlingModifier}");

                if (_character.ProficencyInsight)
                {
                    form.GetField("insightproficency").SetValue($"{_character.ProficencyInsight}");
                }
                form.GetField("insightmodifier").SetValue($"{_character.InsightModifier}");

                if (_character.ProficencyMedicine)
                {
                    form.GetField("medicineproficency").SetValue($"{_character.ProficencyMedicine}");
                }
                form.GetField("medicinemodifier").SetValue($"{_character.MedicineModifier}");

                if (_character.ProficencyPerception)
                {
                    form.GetField("perceptionproficency").SetValue($"{_character.ProficencyPerception}");
                }
                form.GetField("perceptionmodifier").SetValue($"{_character.PerceptionModifer}");

                if (_character.ProficencySurvival)
                {
                    form.GetField("survivalproficency").SetValue($"{_character.ProficencySurvival}");
                }
                form.GetField("survivalmodifier").SetValue($"{_character.SurvivalModifier}");

                if (_character.SaveThrowCharisma)
                {
                    form.GetField("savingthrowcha").SetValue($"{_character.SaveThrowCharisma}");
                }
                form.GetField("savingthrowmodifiercha").SetValue($"{_character.SaveThrowCharismaModifier}");

                if (_character.ProficencyDeception)
                {
                    form.GetField("deceptionproficency").SetValue($"{_character.ProficencyDeception}");
                }
                form.GetField("deceptionmodifier").SetValue($"{_character.DeceptionModifier}");

                if (_character.ProficencyIntimidation)
                {
                    form.GetField("intimidationproficency").SetValue($"{_character.ProficencyIntimidation}");
                }
                form.GetField("intimidationmodifier").SetValue($"{_character.IntimidationModifier}");

                if (_character.ProficencyPerformance)
                {
                    form.GetField("performanceproficency").SetValue($"{_character.ProficencyPerformance}");
                }
                form.GetField("performancemodifier").SetValue($"{_character.PerformanceModifier}");

                if (_character.ProficencyPersuasion)
                {
                    form.GetField("persuasionproficency").SetValue($"{_character.ProficencyPersuasion}");
                }
                form.GetField("persuasionmodifier").SetValue($"{_character.PersuasionModifier}");

                form.GetField("passiveperception").SetValue($"{_character.PassivePerception}");
                form.GetField("ac").SetValue($"{_character.ArmorClass}");
                form.GetField("inititive").SetValue($"+{_character.Inititive}");
                form.GetField("speed").SetValue($"{_character.Speed}");
                form.GetField("hpmax").SetValue($"{_character.HitPointMax}");
                form.GetField("hpcurrent").SetValue($"{_character.HitPointCurrent}");
                //form.GetField("hptemp").SetValue($"{_character.HitPointTemperary}");
                form.GetField("hitdicetotal").SetValue($"{_character.HitDiceTotal}").SetFontSize(FontSize(_character.HitDiceTotal.Length) - 6);
                form.GetField("hitdice").SetValue($"{_character.HitDice}").SetFontSize(FontSize(_character.HitDice.Length) - 2);
                form.GetField("weaponname1").SetValue($"{_character.WeaponName1}");
                form.GetField("weaponattackbonus1").SetValue($"{_character.WeaponAttackBonus1}");
                form.GetField("weapondamageandtype1").SetValue($"{_character.WeaponDamageAndType1}");
                form.GetField("weaponname2").SetValue($"{_character.WeaponName2}");
                form.GetField("weaponattackbonus2").SetValue($"{_character.WeaponAttackBonus2}");
                form.GetField("weapondamageandtype2").SetValue($"{_character.WeaponDamageAndType2}");
                form.GetField("weaponname3").SetValue($"{_character.WeaponName3}");
                form.GetField("weaponattackbonus3").SetValue($"{_character.WeaponAttackBonus3}");
                form.GetField("weapondamageandtype3").SetValue($"{_character.WeaponDamageAndType3}");
                form.GetField("attacksandspellcasting").SetValue($"{_character.AttackAndSpellCasting}");
                form.GetField("traits").SetValue($"{_character.PersonalityTraits}").SetFontSize(FontSize(_character.PersonalityTraits.Length));
                form.GetField("ideals").SetValue($"{_character.PersonalityIdeals}").SetFontSize(FontSize(_character.PersonalityIdeals.Length));
                form.GetField("bonds").SetValue($"{_character.PersonalityBonds}").SetFontSize(FontSize(_character.PersonalityBonds.Length));
                form.GetField("flaws").SetValue($"{_character.PersonalityFlaws}").SetFontSize(FontSize(_character.PersonalityFlaws.Length));
                form.GetField("featuresandtraits1").SetValue($"{_character.FeaturesAndTraits1}").SetFontSize(FontSize(_character.FeaturesAndTraits1.Length));
                form.GetField("proficienciesandlanguages").SetValue($"{_character.ProficiencesAndLanguages}").SetFontSize(FontSize(_character.ProficiencesAndLanguages.Length) + 1);
                form.GetField("equipment1").SetValue($"{_character.Equipment1}").SetFontSize(FontSize(_character.Equipment1.Length) + 1);
                form.GetField("passiveperception").SetValue($"{_character.PassivePerception}");

                using (PdfDocument _working = new PdfDocument(new PdfReader(Details_Sheet), new PdfWriter(Working_Sheet)))
                {
                    PdfAcroForm workingform = PdfAcroForm.GetAcroForm(_working, true);
                    workingform.GetField("charactername2").SetValue($"{_character.CharacterName}").SetFontSizeAutoScale();
                    workingform.GetField("age").SetValue($"{_character.Age}").SetFontSizeAutoScale();
                    workingform.GetField("height").SetValue($"{_character.Height}").SetFontSizeAutoScale();
                    workingform.GetField("weight").SetValue($"{_character.Weight}").SetFontSizeAutoScale();
                    workingform.GetField("eyes").SetValue($"{_character.Eyes}").SetFontSizeAutoScale();
                    workingform.GetField("skin").SetValue($"{_character.Skin}").SetFontSizeAutoScale();
                    workingform.GetField("hair").SetValue($"{_character.Hair}").SetFontSizeAutoScale();
                    //workingform.GetField("characterimage").SetValue($"{}");
                    workingform.GetField("allies").SetValue($"{_character.Allies}");
                    workingform.GetField("factionname").SetValue($"{_character.FactionName}").SetFontSizeAutoScale();
                    //workingform.GetField("factionsymbolimage").SetValue($"{}");
                    workingform.GetField("backstory1").SetValue($"{_character.BackStory}").SetFontSize(FontSize(_character.BackStory.Length) + 1);
                    workingform.GetField("featsandtraits2").SetValue($"{_character.FeatsAndTraits2}").SetFontSizeAutoScale();
                    workingform.GetField("equipment2").SetValue($"{_character.Equipment2}").SetFontSize(FontSize(_character.Equipment2.Length) + 1);

                    if (!string.IsNullOrEmpty(Character_Image) && File.Exists(Character_Image))
                    {
                        iText.IO.Image.ImageData imageData = ImageDataFactory.Create(Character_Image);
                        Image image = new Image(imageData).ScaleToFit(145, 200).SetFixedPosition(1, 45, 450);
                        //Image image = new Image(imageData).ScaleAbsolute(145, 200).SetFixedPosition(1,45,450);
                        Document document = new Document(_working);
                        document.Add(image);
                    }

                    if(!string.IsNullOrEmpty(Faction_Image) && File.Exists(Faction_Image))
                    {
                        iText.IO.Image.ImageData imageData = ImageDataFactory.Create(Faction_Image);
                        Image image = new Image(imageData).ScaleToFit(145, 120).SetFixedPosition(1, 450, 505);
                        Document document = new Document(_working);
                        document.Add(image);
                    }
                }
                using (PdfDocument _details = new PdfDocument(new PdfReader(Working_Sheet)))
                {
                    _pdfDocument.AddPage(_details.GetPage(1).CopyTo(_pdfDocument));
                }
                FileInfo file = new FileInfo(Working_Sheet);
                file.Delete();

                for (int i = 0; i < _character.SpellCasting.Count; i++)
                {
                    using (PdfDocument _spell = new PdfDocument(new PdfReader(Spells_Sheet), new PdfWriter(Working_Sheet)))
                    {
                        WriteSpells(_spell, _character.SpellCasting[i]);
                    }
                    PdfDocument _spells = new PdfDocument(new PdfReader(Working_Sheet));
                    _pdfDocument.AddPage(_spells.GetPage(1).CopyTo(_pdfDocument));
                    _spells.Close();
                }
                file = new FileInfo(Working_Sheet);
                file.Delete();
            }
        }

        private void WriteSpells(PdfDocument pdfDocument, SpellCasting spellCasting)
        {
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDocument, true);
            IDictionary<string, PdfFormField> fields = form.GetFormFields();

            List<string> Cantrips = new List<string>() { "cantrip001", "cantrip002", "cantrip003", "cantrip004", "cantrip005", "cantrip006", "cantrip007", "cantrip008" };
            List<string> _1st = new List<string>() { "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112" };
            List<string> _2nd = new List<string>() { "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213" };
            List<string> _3rd = new List<string>() { "301", "302", "303", "304", "305", "306", "307", "308", "309", "310", "311", "312", "313" };
            List<string> _4th = new List<string>() { "401", "402", "403", "404", "405", "406", "407", "408", "409", "410", "411", "412", "413" };
            List<string> _5th = new List<string>() { "501", "502", "503", "504", "505", "506", "507", "508", "509", "510" };
            List<string> _6th = new List<string>() { "601", "602", "603", "604", "605", "606", "607", "608", "609" };
            List<string> _7th = new List<string>() { "701", "702", "703", "704", "705", "706", "707", "708", "709" };
            List<string> _8th = new List<string>() { "801", "802", "803", "804", "805", "806", "807" };
            List<string> _9th = new List<string>() { "901", "902", "903", "904", "905", "906", "907" };
            List<string> _10th = new List<string>() { "1001", "1002", "1003", "1004", "1005", "1006", "1007" };

            List<Spell> _0 = spellCasting.SpellsKnown.Where(x => x.Level == 0).OrderBy(n => n.Name).Take(11).ToList();
            List<Spell> _1 = spellCasting.SpellsKnown.Where(x => x.Level == 1).OrderByDescending(a=>a.prepared).ThenBy(n => n.Name).Take(12).ToList();
            List<Spell> _2 = spellCasting.SpellsKnown.Where(x => x.Level == 2).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(12).ToList();
            List<Spell> _3 = spellCasting.SpellsKnown.Where(x => x.Level == 3).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(12).ToList();
            List<Spell> _4 = spellCasting.SpellsKnown.Where(x => x.Level == 4).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(9).ToList();
            List<Spell> _5 = spellCasting.SpellsKnown.Where(x => x.Level == 5).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(8).ToList();
            List<Spell> _6 = spellCasting.SpellsKnown.Where(x => x.Level == 6).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(8).ToList();
            List<Spell> _7 = spellCasting.SpellsKnown.Where(x => x.Level == 7).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(6).ToList();
            List<Spell> _8 = spellCasting.SpellsKnown.Where(x => x.Level == 8).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(6).ToList();
            List<Spell> _9 = spellCasting.SpellsKnown.Where(x => x.Level == 9).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).Take(6).ToList();
            List<Spell> _10 = spellCasting.SpellsKnown.Where(x => x.Level == 10).OrderByDescending(a => a.prepared).ThenBy(n => n.Name).ToList();

            for (int i = 0; i < _0.Count; i++)
            {
                PdfFormField field = form.GetField(Cantrips[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    field.SetValue(_0[i].Name);
                }
            }

            for (int i = 0; i < _1.Count; i++)
            {
                PdfFormField field = form.GetField(_1st[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_1[i].prepared)
                    {
                        form.GetField($"{_1st[i]}prepaired").SetValue("Yes");
                    }
                    string comp = string.Empty;
                    foreach (Component s in _1[i].Component)
                    {
                        if (string.IsNullOrEmpty(comp))
                        {
                            comp = $"{s}";
                        }
                        else
                        {
                            comp += $", {s}";
                        }
                    }
                        string Name = $"{_1[i].Name}";
                    field.SetValue(Name);
                    
                }
            }

            for (int i = 0; i < _2.Count; i++)
            {
                PdfFormField field = form.GetField(_2nd[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_2[i].prepared)
                    {
                        form.GetField($"{_2nd[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_2[i].Name);
                }
            }

            for (int i = 0; i < _3.Count; i++)
            {
                PdfFormField field = form.GetField(_3rd[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_3[i].prepared)
                    {
                        form.GetField($"{_3rd[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_3[i].Name);
                }
            }

            for (int i = 0; i < _4.Count; i++)
            {
                PdfFormField field = form.GetField(_4th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_4[i].prepared)
                    {
                        form.GetField($"{_4th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_4[i].Name);
                }
            }

            for (int i = 0; i < _5.Count; i++)
            {
                PdfFormField field = form.GetField(_5th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_5[i].prepared)
                    {
                        form.GetField($"{_5th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_5[i].Name);
                }
            }

            for (int i = 0; i < _6.Count; i++)
            {
                PdfFormField field = form.GetField(_6th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_6[i].prepared)
                    {
                        form.GetField($"{_6th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_6[i].Name);
                }
            }

            for (int i = 0; i < _7.Count; i++)
            {
                PdfFormField field = form.GetField(_7th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_7[i].prepared)
                    {
                        form.GetField($"{_7th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_7[i].Name);
                }
            }

            for (int i = 0; i < _8.Count; i++)
            {
                PdfFormField field = form.GetField(_8th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_8[i].prepared)
                    {
                        form.GetField($"{_8th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_8[i].Name);
                }
            }

            for (int i = 0; i < _9.Count; i++)
            {
                PdfFormField field = form.GetField(_9th[i]);
                if (string.IsNullOrEmpty(field.GetValue().ToString()))
                {
                    if (_9[i].prepared)
                    {
                        form.GetField($"{_9th[i]}prepaired").SetValue("Yes");
                    }
                    field.SetValue(_9[i].Name);
                }
            }

            WriteSpellSlots(spellCasting, form);
        }

        private void WriteSpellSlots(SpellCasting SpellCasterCharacter, PdfAcroForm form)
        {
            form.GetField("100slots").SetValue(SpellCasterCharacter._1stLevelSlots.ToString());
            form.GetField("200slots").SetValue(SpellCasterCharacter._2ndLevelSlots.ToString());
            form.GetField("300slots").SetValue(SpellCasterCharacter._3rdLevelSlots.ToString());
            form.GetField("400slots").SetValue(SpellCasterCharacter._4thLevelSlots.ToString());
            form.GetField("500slots").SetValue(SpellCasterCharacter._5thLevelSlots.ToString());
            form.GetField("600slots").SetValue(SpellCasterCharacter._6thLevelSlots.ToString());
            form.GetField("700slots").SetValue(SpellCasterCharacter._7thLevelSlots.ToString());
            form.GetField("800slots").SetValue(SpellCasterCharacter._8thLevelSlots.ToString());
            form.GetField("900slots").SetValue(SpellCasterCharacter._9thLevelSlots.ToString());
            form.GetField("spellcastingclass").SetValue($"{SpellCasterCharacter.SpellCastingClass}");
            form.GetField("spellcastingability").SetValue(SpellCasterCharacter.AbilityScore.Substring(0, 3));
            form.GetField("spellattackbonus").SetValue($"+{SpellCasterCharacter.SpellAttachBonus}");
            form.GetField("spellsavedc").SetValue($"{SpellCasterCharacter.SpellDC}");
        }

        private int FontSize(int length)
        {
            int _fontSize = 12;
            switch (length)
            {
                case int i when (length > 20 && length < 49): { _fontSize = 8; break; }
                case int i when (length > 50 && length < 100): { _fontSize = 6; break; }
                case int i when (length > 100): { _fontSize = 5; break; }
                default: { _fontSize = 11; break; }
            }
            return _fontSize;
        }
    }
    
    public partial class SpellCasting
    {
        public string SpellCastingClass { get; set; }
        public string AbilityScore { get; set; }
        public int SpellAttachBonus { get; set; }
        public int SpellDC { get; set; }
        public List<Spell> SpellsKnown { get; set; }
        public int CantripsKnown { get; set; }
        public int _1stLevelSlots { get; set; }
        public int _2ndLevelSlots { get; set; }
        public int _3rdLevelSlots { get; set; }
        public int _4thLevelSlots { get; set; }
        public int _5thLevelSlots { get; set; }
        public int _6thLevelSlots { get; set; }
        public int _7thLevelSlots { get; set; }
        public int _8thLevelSlots { get; set; }
        public int _9thLevelSlots { get; set; }
        public int _10thLevelSlots { get; set; }
        public int SpellsPrepaired { get; set; }

        public SpellCasting()
        {
            this.SpellsKnown = new List<Spell>();
        }
    }

    public partial class Spell
    {
        public bool prepared { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public School School { get; set; }
        public bool Ritual { get; set; }
        public string Time { get; set; }
        public string Range { get; set; }
        public List<Component> Component { get; set; }
        public string MaterialComponent { get; set; }
        public string Duration { get; set; }
        public string Text { get; set; }
        public Dice[] Roll { get; set; }
        public List<string> Class { get; set; }
    }
}
