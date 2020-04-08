using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    public partial class pc
    {
        private List<Character> characterField;

        private List<ImageData> imageDataField;

        private int versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public List<Character> character
        {
            get { return this.characterField; }
            set { this.characterField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public List<ImageData> imageData
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

    public partial class data
    {
        private List<Character> characterField;
        private List<ImageData> imageDataField;
        private int uidField;
        private int versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public List<Character> character
        {
            get { return this.characterField; }
            set { this.characterField = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public List<ImageData> imageData
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
            set { this.versionField = value;  }
        }
    }
}