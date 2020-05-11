using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Sources
{
    [XmlRoot("compendium")]
    public partial class Schema_Source_Compendium
    {
        private int VersionField;
        private string Auto_IndentField;
        private List<Schema_Source_XML_Item> ItemField;

        [XmlAttributeAttribute("version")]
        public int Version
        {
            get { return this.VersionField; }
            set { this.VersionField = value; }
        }
        [XmlAttributeAttribute("auto_indent")]
        public string Auto_Indent
        {
            get { return this.Auto_IndentField; }
            set { this.Auto_IndentField = value; }
        }
        [XmlElementAttribute("item")]
        public List<Schema_Source_XML_Item> Item
        {
            get { return this.ItemField; }
            set { this.ItemField = value; }
        }
    }
}