using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    public partial class pc
    {
        private Character[] characterField;

        private ImageData[] imageDataField;

        private int versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public Character[] character
        {
            get
            {
                return this.characterField;
            }
            set
            {
                this.characterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public ImageData[] imageData
        {
            get
            {
                return this.imageDataField;
            }
            set
            {
                this.imageDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("version")]
        public int version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

    }
}