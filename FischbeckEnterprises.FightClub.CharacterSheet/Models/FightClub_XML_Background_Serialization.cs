using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    public partial class Background
    {
        private string nameField;
        private bool nameFieldSpecified;

        private string alignField;
        private bool alignFieldSpecified;

        private string factionField;
        private bool factionFieldSpecified;

        private string personalityField;
        private bool personalityFieldSpecified;

        private string idealsField;
        private bool idealsFieldSpecified;

        private string bondsField;
        private bool bondsFieldSpecified;

        private string flawsField;
        private bool flawsFieldSpecified;

        private int[] proficiencyField;
        private bool proficiencyFieldSpecified;

        private List<Feat> featField;
        private bool featFieldSpecified;

        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string name { get { return this.nameField; } set { this.nameField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("align")]
        public string align { get { return this.alignField; } set { this.alignField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool alignSpecified { get { return this.alignFieldSpecified; } set { this.alignFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("faction")]
        public string faction { get { return this.factionField; } set { this.factionField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool factionSpecified { get { return this.factionFieldSpecified; } set { this.factionFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("personality")]
        public string personality { get { return this.personalityField; } set { this.personalityField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool personalitySpecified { get { return this.personalityFieldSpecified; } set { this.personalityFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("ideals")]
        public string ideals { get { return this.idealsField; } set { this.idealsField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idealsSpecified { get { return this.idealsFieldSpecified; } set { this.idealsFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("bonds")]
        public string bonds { get { return this.bondsField; } set { this.bondsField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bondsSpecified { get { return this.bondsFieldSpecified; } set { this.bondsFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("flaws")]
        public string flaws { get { return this.flawsField; } set { this.flawsField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool flawsSpecified { get { return this.flawsFieldSpecified; } set { this.flawsFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("proficiency")]
        public int[] proficiency { get { return this.proficiencyField; } set { this.proficiencyField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool proficiencySpecified { get { return this.proficiencyFieldSpecified; } set { this.proficiencyFieldSpecified = value; } }

        [System.Xml.Serialization.XmlElementAttribute("feat")]
        public List<Feat> feat { get { return this.featField; } set { this.featField = value; } }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool featSpecified { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }
    }
}