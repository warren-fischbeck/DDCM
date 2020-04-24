using System.Collections.Generic;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
	class Schema_XML_Feature
	{
		[System.SerializableAttribute()]
		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		public partial class Feat
		{
			private string nameField;
			private bool nameFieldSpecified;
			private string textField;
			private bool textFieldSpecified;
			private bool expandedField;
			private bool expandedFieldSpecified;
			private List<Schema_XML_Modifier> modField;
			private bool modFieldSpecified;
			private List<int> proficiencyField;
			private bool proficiencyFieldSpecified;
			private int specialField;
			private bool specialFieldSpecified;

			[System.Xml.Serialization.XmlElementAttribute("name")]
			public string name { get { return this.nameField; } set { this.nameField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }
			[System.Xml.Serialization.XmlElementAttribute("text")]
			public string text { get { return this.textField; } set { this.textField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool textSpecified { get { return this.textFieldSpecified; } set { this.textFieldSpecified = value; } }
			[System.Xml.Serialization.XmlElementAttribute("expanded")]
			public bool expanded { get { return this.expandedField; } set { this.expandedField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool expandedSpecified { get { return this.expandedFieldSpecified; } set { this.expandedFieldSpecified = value; } }
			[System.Xml.Serialization.XmlElementAttribute("mod")]
			public List<Schema_XML_Modifier> mod { get { return this.modField; } set { this.modField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }
			[System.Xml.Serialization.XmlElementAttribute("proficiency")]
			public List<int> proficiency { get { return this.proficiencyField; } set { this.proficiencyField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool proficiencySpecified { get { return this.proficiencyFieldSpecified; } set { this.proficiencyFieldSpecified = value; } }
			[System.Xml.Serialization.XmlElementAttribute("special")]
			public int special { get { return this.specialField; } set { this.specialField = value; } }
			[System.Xml.Serialization.XmlIgnoreAttribute()]
			public bool specialSpecified { get { return this.specialFieldSpecified; } set { this.specialFieldSpecified = value; } }
		}
	}
}