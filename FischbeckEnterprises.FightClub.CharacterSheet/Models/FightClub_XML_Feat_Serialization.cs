using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
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

		private Mod[] modField;

		private bool modFieldSpecified;

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
		public Mod[] mod { get { return this.modField; } set { this.modField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }
	}
}