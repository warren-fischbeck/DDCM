using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

    partial class Schema_XML_Data
    {
        private List<Schema_XML_Character> characterField;
        private List<Schema_XML_Image_Data> imageDataField;
        private int uidField;
        private int versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public List<Schema_XML_Character> character
        {
            get { return this.characterField; }
            set { this.characterField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public List<Schema_XML_Image_Data> imageData
        {
            get { return this.imageDataField; }
            set { this.imageDataField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("uid")]
        public int uid
        {
            get { return this.uidField; }
            set { this.uidField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("version")]
        public int version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }
    }
}
