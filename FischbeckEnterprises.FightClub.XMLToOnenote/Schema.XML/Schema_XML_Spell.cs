using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	partial class Schema_XML_Spell
    {
		private string nameField;

		private int levelField;

		private int schoolField;

		private int ritualField;

		private bool ritualFieldSpecified;

		private string timeField;

		private string rangeField;

		private int vField;

		private bool vFieldSpecified;

		private int sField;

		private bool sFieldSpecified;

		private int mField;

		private bool mFieldSpecified;

		private string materialsField;

		private bool materialsFieldSpecified;

		private string durationField;

		private List<string> textField;

		private List<string> sClassField;

		private int preparedField;

		private bool preparedFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("level")]
		public int level { get { return this.levelField; } set { this.levelField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("school")]
		public int school { get { return this.schoolField; } set { this.schoolField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("ritual")]
		public int ritual { get { return this.ritualField; } set { this.ritualField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ritualSpecified { get { return this.ritualFieldSpecified; } set { this.ritualFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("time")]
		public string time { get { return this.timeField; } set { this.timeField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("range")]
		public string range { get { return this.rangeField; } set { this.rangeField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("v")]
		public int v { get { return this.vField; } set { this.vField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool vSpecified { get { return this.vFieldSpecified; } set { this.vFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("s")]
		public int s { get { return this.sField; } set { this.sField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool sSpecified { get { return this.sFieldSpecified; } set { this.sFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("m")]
		public int m { get { return this.mField; } set { this.mField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool mSpecified { get { return this.mFieldSpecified; } set { this.mFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("materials")]
		public string materials { get { return this.materialsField; } set { this.materialsField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool matrialsSpecified { get { return this.materialsFieldSpecified; } set { this.materialsFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("duration")]
		public string duration { get { return this.durationField; } set { this.durationField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("text")]
		public List<string> text { get { return this.textField; } set { this.textField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("sClass")]
		public List<string> sClass { get { return this.sClassField; } set { this.sClassField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("prepared")]
		public int prepared { get { return this.preparedField; } set { this.preparedField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool preparedSpecified { get { return this.preparedFieldSpecified; } set { this.preparedFieldSpecified = value; } }
	}
}