using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
	partial class Schema_XML_Class
    {
		private string nameField;
		private int levelField;
		private bool levelFieldSpecified;
		private int hpCurrentField;
		private bool hdCurrentFieldSpecified;
		private int hdField;
		private bool hdFieldSpecified;
		private string wealthField;
		private bool wealthFieldSpecified;
		private string slotsField;
		private bool slotsFieldSpecified;
		private string slotsCurrentField;
		private bool slotsCurrentfieldSpecified;
		private int[] proficiencyField;
		private bool proficiencyFieldSpecified;
		private int numClassSkillsField;
		private bool numbClassSkillsFieldSpecified;
		private string armorField;
		private bool armorFieldSpecified;
		private string weaponsField;
		private bool weaponsFieldSpecified;
		private string toolsField;
		private bool toolsFieldSpecified;
		private List<Schema_XML_Feature> featField;
		private bool featFieldSpecified;
		private int spellAbilityField;
		private bool spellAbilityFieldSpecified;
		private List<Schema_XML_Spell> spellField;
		private bool spellFieldSpecified;
		private List<Schema_XML_Modifier> modField;
		private bool modFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("mod")]
		public List<Schema_XML_Modifier> mod { get { return this.modField; } set { this.modField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("level")]
		public int level { get { return this.levelField; } set { this.levelField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool levelSpecified { get { return this.levelFieldSpecified; } set { this.levelFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("hpCurrent")]
		public int hpCurrent { get { return this.hpCurrentField; } set { this.hpCurrentField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool hpCurrentSpecified { get { return this.hdCurrentFieldSpecified; } set { this.hdCurrentFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("hd")]
		public int hd { get { return this.hdField; } set { this.hdField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool hdSpecified { get { return this.hdFieldSpecified; } set { this.hdFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("wealth")]
		public string wealth { get { return this.wealthField; } set { this.wealthField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool wealthSpecified { get { return this.wealthFieldSpecified; } set { this.wealthFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("slots")]
		public string slots { get { return this.slotsField; } set { this.slotsField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsSpecified { get { return this.slotsFieldSpecified; } set { this.slotsFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("slotsCurrent")]
		public string slotsCurrent { get { return this.slotsCurrentField; } set { this.slotsCurrentField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsCurrentSpecified { get { return this.slotsCurrentfieldSpecified; } set { this.slotsCurrentfieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("proficiency")]
		public int[] proficiency { get { return this.proficiencyField; } set { this.proficiencyField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool proficiencySpecified { get { return this.proficiencyFieldSpecified; } set { this.proficiencyFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("numClassSkills")]
		public int numClassSkills { get { return this.numClassSkillsField; } set { this.numClassSkillsField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool numClassSkillsSpecified { get { return this.numbClassSkillsFieldSpecified; } set { this.numbClassSkillsFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("armor")]
		public string armor { get { return this.armorField; } set { this.armorField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool armorSpecified { get { return this.armorFieldSpecified; } set { this.armorFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("weapons")]
		public string weapons { get { return this.weaponsField; } set { this.weaponsField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool weaponsSpecified { get { return this.weaponsFieldSpecified; } set { this.weaponsFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("tools")]
		public string tools { get { return this.toolsField; } set { this.toolsField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool toolsSpecified { get { return this.toolsFieldSpecified; } set { this.toolsFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public List<Schema_XML_Feature> feat { get { return this.featField; } set { this.featField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecified { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("spellAbility")]
		public int spellAbility { get { return this.spellAbilityField; } set { this.spellAbilityField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellAbilitySpecified { get { return this.spellAbilityFieldSpecified; } set { this.spellAbilityFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("spell")]
		public List<Schema_XML_Spell> spell { get { return this.spellField; } set { this.spellField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellSpecified { get { return this.spellFieldSpecified; } set { this.spellFieldSpecified = value; } }
	}
}
