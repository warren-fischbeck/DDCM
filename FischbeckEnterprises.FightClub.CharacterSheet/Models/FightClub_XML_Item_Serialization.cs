using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    public partial class Item
    {
        private string nameField;
        private bool nameFieldSpecified;

        private string detailField;
        private bool detailFieldSpecified;

        private string textField;
        private bool textFieldSpecified;

        private int typeField;
        private bool typeFieldSpecified;

        private int magicField;
        private bool magicFieldSpecified;

        private int slotField;
        private bool slotFieldSpecified;

        private string valueField;
        private bool valueFieldSpecified;

        private string weightField;
        private bool weightFieldSpecified;

        private int acField;
        private bool acFieldSpecified;

        private Mod[] modField;
        private bool modFieldSpecified;

        private string damage1HField;
        private bool damage1HFieldSpecified;

        private string damage2HField;
        private bool damage2HFieldSpecified;

        private int damageTypeField;
        private bool damageTypeFieldSpecified;

        private int weaponPropertyField;
        private bool weaponPropertyFieldSpecified;

        private int strengthField;
        private bool strengthFieldSpecified;

        private int quantityField;
        private bool quantityFieldSpecified;


        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string name { get { return this.nameField; } set { this.nameField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("detail")]
        public string detail { get { return this.detailField; } set { this.detailField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool detailSpecified { get { return this.detailFieldSpecified; } set { this.detailFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("text")]
        public string text { get { return this.textField; } set { this.textField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool textSpecified { get { return this.textFieldSpecified; } set { this.textFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("type")]
        public int type { get { return this.typeField; } set { this.typeField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified { get { return this.typeFieldSpecified; } set { this.typeFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("magic")]
        public int magic { get { return this.magicField; } set { this.magicField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool magicSpecified { get { return this.magicFieldSpecified; } set { this.magicFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("slot")]
        public int slot { get { return this.slotField; } set { this.slotField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool slotsSpecified { get { return this.slotFieldSpecified; } set { this.slotFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("value")]
        public string @value { get { return this.valueField; } set { this.valueField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified { get { return this.valueFieldSpecified; } set { this.valueFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("weight")]
        public string weight { get { return this.weightField; } set { this.weightField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool weightSpecified { get { return this.weightFieldSpecified; } set { this.weightFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("ac")]
        public int ac { get { return this.acField; } set { this.acField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool acSpecified { get { return this.acFieldSpecified; } set { this.acFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("mod")]
        public Mod[] mod { get { return this.modField; } set { this.modField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("damage1H")]
        public string damage1H { get { return this.damage1HField; } set { this.damage1HField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool damage1HSpecified { get { return this.damage1HFieldSpecified; } set { this.damage1HFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("damage2H")]
        public string damage2H { get { return this.damage2HField; } set { this.damage2HField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool damage2HSpecified { get { return this.damage2HFieldSpecified; } set { this.damage2HFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("damageType")]
        public int damageType { get { return this.damageTypeField; } set { this.damageTypeField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool damageTypeSpecified { get { return this.damageTypeFieldSpecified; } set { this.damageTypeFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("weaponProperty")]
        public int weaponProperty { get { return this.weaponPropertyField; } set { this.weaponPropertyField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool weaponPropertySpecified { get { return this.weaponPropertyFieldSpecified; } set { this.weaponPropertyFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("strength")]
        public int strength { get { return this.strengthField; } set { this.strengthField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool strengthSpecified { get { return this.strengthFieldSpecified; } set { this.strengthFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("quantity")]
        public int quantity { get { return this.quantityField; } set { this.quantityField = value; } }
        public bool quantitySpecified { get { return this.quantityFieldSpecified; } set { this.quantityFieldSpecified = value; } }
    }
}
