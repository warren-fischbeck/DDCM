using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
    partial class Schema_XML_PC
    {
        private List<Schema_XML_Character> characterField;

        private List<Schema_XML_Image_Data> imageDataField;

        private int versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public List<Schema_XML_Character> character
        {
            get { return this.characterField; }
            set { this.characterField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public List<Schema_XML_Image_Data> imageData
        {
            get { return this.imageDataField; }
            set { this.imageDataField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("version")]
        public int version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }
    }
}