using FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Sources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Core
{
    internal class DataLoader
    {
        private List<DirectoryInfo> DirectoryInfoField = new List<DirectoryInfo>();
        private List<FileInfo> FileField = new List<FileInfo>();
        private List<Schema_Source_XML_Item> _Source_Items = new List<Schema_Source_XML_Item>();

        public List<DirectoryInfo> Directory 
        { 
            get { return this.DirectoryInfoField; }
            set { this.DirectoryInfoField = value; }
        }

        public DataLoader(DirectoryInfo directory)
        {
            Directory.Add(directory);
            GetFiles();
        }

        public DataLoader(List<DirectoryInfo> directories)
        {
            Directory.AddRange(directories);
            GetFiles();
        }

        private void GetFiles()
        {
            foreach(DirectoryInfo directory in DirectoryInfoField)
            {
                FileField.AddRange(directory.GetFiles());
            }
            ImportXML(this.FileField);
            CleanUp();
        }

        private void ImportXML(List<FileInfo> Files)
        {
            Schema_Source_Compendium compendium = new Schema_Source_Compendium();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Schema_Source_Compendium));
            foreach (FileInfo file in Files)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                    {
                        compendium = (Schema_Source_Compendium)xmlSerializer.Deserialize(fileStream);
                        _Source_Items.AddRange(compendium.Item);
                    }
                }
                catch (System.InvalidOperationException)
                {

                }
            }
        } 
        
        public void CleanUp()
        {
            _Source_Items = ItemCleanUp(_Source_Items);
        }

        private List<Schema_Source_XML_Item> ItemCleanUp (List<Schema_Source_XML_Item> Source)
        {
            List<Schema_Source_XML_Item> CleanedItems = new List<Schema_Source_XML_Item>();
            List<Schema_Source_XML_Item> DuplicateItems = new List<Schema_Source_XML_Item>();
            foreach(Schema_Source_XML_Item item in Source)
            {
                var test = CleanedItems.Where(a => a.Name == item.Name).FirstOrDefault();
                if (test == null)
                { CleanedItems.Add(item); }
                else
                { DuplicateItems.Add(item); }
            }
            return CleanedItems.OrderBy(a=>a.Type).ThenBy(b=>b.Name).ToList();
        }
    }
}
