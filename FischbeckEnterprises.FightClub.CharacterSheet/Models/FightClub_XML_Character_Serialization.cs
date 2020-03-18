using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
	public partial class Character
	{
		private int versionField;

		private string uidField;

		private string nameField;

		private ImageData imageDataField;

		private string abilitiesField;

		private int hpMaxField;

		private int hpCurrentField;

		private int xpField;

		private bool xpFieldSpecified;

		private int unarmedField;

		private Race raceField;

		private NaturalAttack[] attackField;

		private bool attackFieldSpecified;

		private PcClass[] classField;

		private Container[] containerField;

		private bool containerFieldSpecified;

		private Feat[] featField;

		private bool featFieldSpecified;

		private Item[] itemField;

		private bool itemFieldSpecified;

		private Note[] noteField;

		private bool noteFiledSpecified;

		private string slotsField;
		private bool slotsFieldSpecified;
		private string slotsCurrentField;
		private bool slotsCurrentfieldSpecified;


		[System.Xml.Serialization.XmlElementAttribute("version")]
		public int version { get { return this.versionField; } set { this.versionField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("uid")]
		public string uid { get { return this.uidField; } set { this.uidField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("imageData")]
		public ImageData imageData { get { return this.imageDataField; } set { this.imageDataField = value; } }

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
		public Race race { get { return this.raceField; } set { this.raceField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("attack")]
		public NaturalAttack[] attack { get { return this.attackField; } set { this.attackField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attackSpecified { get { return this.attackFieldSpecified; } set { this.attackFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("class")]
		public PcClass[] @class { get { return this.classField; } set { this.classField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public Feat[] feat { get { return this.featField; } set { this.featField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecificed { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("container")]
		public Container[] container { get { return this.containerField; } set { this.containerField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool containerSepecified { get { return this.containerFieldSpecified; } set { this.containerFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("item")]
		public Item[] item { get { return this.itemField; } set { this.itemField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool itemSepecified { get { return this.itemFieldSpecified; } set { this.itemFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("note")]
		public Note[] note { get { return this.noteField; } set { this.noteField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool noteSepecified { get { return this.noteFiledSpecified; } set { this.noteFiledSpecified = value; } }
		
		[System.Xml.Serialization.XmlElementAttribute("slots")]
		public string slots { get { return this.slotsField; } set { this.slotsField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsSpecified { get { return this.slotsFieldSpecified; } set { this.slotsFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("slotsCurrent")]
		public string slotsCurrent { get { return this.slotsCurrentField; } set { this.slotsCurrentField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool slotsCurrentSpecified { get { return this.slotsCurrentfieldSpecified; } set { this.slotsCurrentfieldSpecified = value; } }

	}
}