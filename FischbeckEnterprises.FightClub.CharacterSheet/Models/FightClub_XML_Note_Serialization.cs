using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    class Note
    {
        private string nameField;
        private bool nameFieldSpecified;

        private string textField;
        private bool textFieldSpecified;

        private ImageData imageDataField;
        private bool imageDataFieldSpecified;

        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string name {get{ return this.nameField; }set{ this.nameField = value; }}
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nameSpecified {get{ return this.nameFieldSpecified; }set{ this.nameFieldSpecified = value; }}

        [System.Xml.Serialization.XmlElementAttribute("text")]
        public string text {get{ return this.textField; }set{ this.textField = value; }}
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool textSpecified {get{ return this.textFieldSpecified; }set{ this.textFieldSpecified = value; }}

        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public ImageData imageData {get{ return this.imageDataField; }set{ this.imageDataField = value; }}
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool imageDataSpecified {get{ return this.imageDataFieldSpecified; }set{ this.imageDataFieldSpecified = value; }}
    }
}
