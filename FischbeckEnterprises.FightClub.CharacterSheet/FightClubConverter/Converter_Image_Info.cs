﻿using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using iText.Layout;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void PCImage()
        {
            if (_pc.character.FirstOrDefault().imageData != null)
            {
                int id = _pc.character.FirstOrDefault().imageData.uid;
                byte[] bytes;
                foreach (var item in _pc.imageData.ToList())
                {
                    if (item.uid == id)
                    {
                        Image image;
                        bytes = Convert.FromBase64String(item.encoded);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                            string save = $"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{item.uid}.jpeg";
                            string save2 = $"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{_pc.character.FirstOrDefault().name.Replace("\"", "")}.jpeg";
                            Console.WriteLine(save);
                            Console.WriteLine(save2);
                            _printablePlayerCharacter.CharacterImageFilePath = save2;
                            image.Save(save);
                            image.Save(save2);
                        }
                    }
                }
            }
        }

        private void FactionImage()
        {
            string _factionName = _pc.character.FirstOrDefault().background.faction;
            if (_pc.character.FirstOrDefault().note.Count > 0 && !string.IsNullOrEmpty(_factionName))
            {
                ImageData _faction = _pc.character.FirstOrDefault().note.Where(x => x.name.Contains(_factionName)).Select(x => x.imageData).FirstOrDefault();
                byte[] bytes;
                if (_faction != null)
                {
                    foreach (ImageData item in _pc.imageData.ToList())
                    {
                        if (item.uid == _faction.uid)
                        {
                            Image image;
                            if (item.encoded != null)
                            {
                                bytes = Convert.FromBase64String(item.encoded);
                                using (MemoryStream ms = new MemoryStream(bytes))
                                {
                                    image = Image.FromStream(ms);
                                    string save = $"{System.IO.Directory.GetCurrentDirectory()}\\Images\\{item.uid}.jpeg";
                                    _printablePlayerCharacter.FactionImageFilePath = save;
                                    image.Save(save);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ImageCleanup()
        {
            string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\Images";
            FileInfo[] files = new DirectoryInfo(directory).GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension.Contains("jpeg"))
                {
                    file.Delete();
                }
            }
        }
    }
}