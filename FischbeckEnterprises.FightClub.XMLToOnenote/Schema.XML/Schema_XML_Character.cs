using System.Collections.Generic;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]

	partial class Schema_XML_Character
	{
		private int versionField;
		private string uidField;
		private string nameField;
		private Schema_XML_Image_Data imageDataField;
		private string abilitiesField;
		private int hpMaxField;
		private int hpCurrentField;
		private int xpField;
		private bool xpFieldSpecified;
		private int unarmedField;
		private Schema_XML_Race raceField;
		private List<Schema_XML_Natural_Attack> attackField;
		private bool attackFieldSpecified;
		private List<Schema_XML_Class> classField;
		private List<Schema_XML_Conatiner> containerField;
		private bool containerFieldSpecified;
		private List<Schema_XML_Feature> featField;
		private bool featFieldSpecified;
		private List<Schema_XML_Item> itemField;
		private bool itemFieldSpecified;
		private List<Schema_XML_Note> noteField;
		private bool noteFieldSpecified;
		private string slotsField;
		private bool slotsFieldSpecified;
		private string slotsCurrentField;
		private bool slotsCurrentfieldSpecified;
		private Schema_XML_Background backgroundField;
		private bool backgroundFieldSpecified;


		[System.Xml.Serialization.XmlElementAttribute("version")]
		public int version { get { return this.versionField; } set { this.versionField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("uid")]
		public string uid { get { return this.uidField; } set { this.uidField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("imageData")]
		public Schema_XML_Image_Data imageData { get { return this.imageDataField; } set { this.imageDataField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("abilities")]
		public string abilities { get { return this.abilitiesField; } set { this.abilitiesField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("hpMax")]
		public int hpMax { get { return this.hpMaxField; } set { this.hpMaxField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("hpCurrent")]
		public int hpCurrent { get { return this.hpCurrentField; } set { this.hpCurrentField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("xp")]
		public int xp { get { return this.xpField; } set { this.xpField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool xpSpecified { get { return this.xpFieldSpecified; } set { this.xpFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("unarmed")]
		public int unarmed { get { return this.unarmedField; } set { this.unarmedField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("race")]
		public Schema_XML_Race race { get { return this.raceField; } set { this.raceField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("attack")]
		public List<Schema_XML_Natural_Attack> attack { get { return this.attackField; } set { this.attackField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attackSpecified { get { return this.attackFieldSpecified; } set { this.attackFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("class")]
		public List<Schema_XML_Class> @class { get { return this.classField; } set { this.classField = value; } }
		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public List<Schema_XML_Feature> feat { get { return this.featField; } set { this.featField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecificed { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("container")]
		public List<Schema_XML_Conatiner> container { get { return this.containerField; } set { this.containerField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool containerSpecificed { get { return this.containerFieldSpecified; } set { this.containerFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("item")]
		public List<Schema_XML_Item> item { get { return this.itemField; } set { this.itemField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool itemSpecificed { get { return this.itemFieldSpecified; } set { this.itemFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("note")]
		public List<Schema_XML_Note> note { get { return this.noteField; } set { this.noteField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool noteSpecificed { get { return this.noteFieldSpecified; } set { this.noteFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("slots")]
		public string slots { get { return this.slotsField; } set { this.slotsField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsSpecified { get { return this.slotsFieldSpecified; } set { this.slotsFieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("slotsCurrent")]
		public string slotsCurrent { get { return this.slotsCurrentField; } set { this.slotsCurrentField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsCurrentSpecified { get { return this.slotsCurrentfieldSpecified; } set { this.slotsCurrentfieldSpecified = value; } }
		[System.Xml.Serialization.XmlElementAttribute("background")]
		public Schema_XML_Background background { get { return this.backgroundField; } set { this.backgroundField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool backgroundSpecified { get { return this.backgroundFieldSpecified; } set { this.backgroundFieldSpecified = value; } }
	}
}