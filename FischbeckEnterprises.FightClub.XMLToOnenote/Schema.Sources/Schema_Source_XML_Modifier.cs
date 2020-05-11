using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Sources
{
	public partial class Schema_Source_XML_Modifier
	{
		private string nameField;

		private bool nameFieldSpecified;

		private int categoryField;

		private bool categoryFieldSpecified;

		private int typeField;

		private bool typeFieldSpecified;

		private int valueField;

		private bool valueFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("category")]
		public int category { get { return this.categoryField; } set { this.categoryField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool categorySpecified { get { return this.categoryFieldSpecified; } set { this.categoryFieldSpecified = value; } }

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