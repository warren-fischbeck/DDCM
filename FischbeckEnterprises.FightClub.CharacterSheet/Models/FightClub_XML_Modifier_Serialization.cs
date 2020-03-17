using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
	public partial class Mod
	{
		private string nameField;

		private int typeField;

		private bool typeFieldSpecified;

		private int valueField;

		private bool valueFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("type")]
		public int type { get { return this.typeField; } set { this.typeField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool typeSpecified { get { return this.typeFieldSpecified; } set { this.typeFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("value")]
		public int value { get { return this.valueField; } set { this.valueField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool valueSpecified { get { return this.valueFieldSpecified; } set { this.valueFieldSpecified = value; } }
	}
}