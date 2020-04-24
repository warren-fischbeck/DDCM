using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
    class Schema_XML_Conatiner
    {
        private string nameField;
        private bool nameFieldSpecified;
        private string textField;
        private bool textFieldSpecified;
        private string valueField;
        private bool valueFieldSpecified;
        private List<Schema_XML_Item> itemField;
        private bool itemFieldSpecified;

        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string name { get { return this.nameField; } set { this.nameField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }
        [System.Xml.Serialization.XmlElementAttribute("text")]
        public string text { get { return this.textField; } set { this.textField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool textSpecified { get { return this.textFieldSpecified; } set { this.textFieldSpecified = value; } }
        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string value { get { return this.valueField; } set { this.valueField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified { get { return this.valueFieldSpecified; } set { this.valueFieldSpecified = value; } }
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public List<Schema_XML_Item> item { get { return this.itemField; } set { this.itemField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool itemSpecified { get { return this.itemFieldSpecified; } set { this.itemFieldSpecified = value; } }
    }
}
