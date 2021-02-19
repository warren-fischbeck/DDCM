using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.Mobile.DND.Models
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
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

		private List<NaturalAttack> attackField;

		private bool attackFieldSpecified;

		private List<PcClass> classField;

		private List<Container> containerField;

		private bool containerFieldSpecified;

		private List<Feat> featField;

		private bool featFieldSpecified;

		private List<Item> itemField;

		private bool itemFieldSpecified;

		private List<Note> noteField;

		private bool noteFieldSpecified;

		private string slotsField;

		private bool slotsFieldSpecified;

		private string slotsCurrentField;

		private bool slotsCurrentfieldSpecified;

		private Background backgroundField;
		private bool backgroundFieldSpecified;


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
		public List<NaturalAttack> attack { get { return this.attackField; } set { this.attackField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attackSpecified { get { return this.attackFieldSpecified; } set { this.attackFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("class")]
		public List<PcClass> @class { get { return this.classField; } set { this.classField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public List<Feat> feat { get { return this.featField; } set { this.featField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecificed { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("container")]
		public List<Container> container { get { return this.containerField; } set { this.containerField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool containerSpecificed { get { return this.containerFieldSpecified; } set { this.containerFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("item")]
		public List<Item> item { get { return this.itemField; } set { this.itemField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool itemSpecificed { get { return this.itemFieldSpecified; } set { this.itemFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("note")]
		public List<Note> note { get { return this.noteField; } set { this.noteField = value; } }
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
		public Background background { get { return this.backgroundField; } set { this.backgroundField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool backgroundSpecified { get { return this.backgroundFieldSpecified; } set { this.backgroundFieldSpecified = value; } }
	}

	public partial class Container
	{
		private string nameField;
		private bool nameFieldSpecified;

		private string textField;
		private bool textFieldSpecified;

		private string valueField;
		private bool valueFieldSpecified;

		private List<Item> itemField;
		private bool itemFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("text")]
		public string text { get { return this.textField; } set { this.textField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool textSpecified { get { return this.textFieldSpecified; } set { this.textFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("value")]
		public string value { get { return this.valueField; } set { this.valueField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool valueSpecified { get { return this.valueFieldSpecified; } set { this.valueFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("item")]
		public List<Item> item { get { return this.itemField; } set { this.itemField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool itemSpecified { get { return this.itemFieldSpecified; } set { this.itemFieldSpecified = value; } }
	}

	public partial class Feat
	{
		private string nameField;

		private bool nameFieldSpecified;

		private string textField;

		private bool textFieldSpecified;

		private bool expandedField;

		private bool expandedFieldSpecified;

		private List<Mod> modField;

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
		public List<Mod> mod { get { return this.modField; } set { this.modField = value; } }

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

	public partial class ImageData
	{

		private int uidField;

		private string encodedField;

		private bool encodedFieldSpecified;

		/// <remarks/>
		public int uid
		{
			get
			{
				return this.uidField;
			}
			set
			{
				this.uidField = value;
			}
		}

		/// <remarks/>
		public string encoded
		{
			get
			{
				return this.encodedField;
			}
			set
			{
				this.encodedField = value;
			}
		}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool encodedSpecified { get { return this.encodedFieldSpecified; } set { this.encodedFieldSpecified = value; } }

	}

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

		private List<Mod> modField;
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

		private int weaponRangeField;
		private bool weaponRangeFieldSpecified;

		private int weaponLongRangeField;
		private bool weaponLongRangeFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("weaponRange")]
		public int weaponRange { get { return this.weaponRangeField; } set { this.weaponRangeField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool weaponRangeSpecified { get { return this.weaponRangeFieldSpecified; } set { this.weaponRangeFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("weaponLongRange")]
		public int weaponLongRange { get { return this.weaponLongRangeField; } set { this.weaponLongRangeField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool weaponLongRangeSpecified { get { return this.weaponLongRangeFieldSpecified; } set { this.weaponLongRangeFieldSpecified = value; } }

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
		public List<Mod> mod { get { return this.modField; } set { this.modField = value; } }
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

	public partial class Mod
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

	public partial class NaturalAttack
	{
		private string nameField;

		private bool nameFieldSpecified;

		private int typeField;

		private bool typeFieldSpecified;

		private string attackBonusField;

		private bool attackBonusFieldSpecified;

		private string damageField;

		private bool damageFieldSpecified;

		private int damageTypeField;

		private bool damageTypeFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("type")]
		public int type { get { return this.typeField; } set { this.typeField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool typeSpecified { get { return this.typeFieldSpecified; } set { this.typeFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("attackBonus")]
		public string attackBonus { get { return this.attackBonusField; } set { this.attackBonusField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attackBonusSpecified { get { return this.attackBonusFieldSpecified; } set { this.attackBonusFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("damage")]
		public string damage { get { return this.damageField; } set { this.damageField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool damageSpecified { get { return this.damageFieldSpecified; } set { this.damageFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("damageType")]
		public int damageType { get { return this.damageTypeField; } set { this.damageTypeField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool damageTypeSpecified { get { return this.damageTypeFieldSpecified; } set { this.damageTypeFieldSpecified = value; } }
	}

	public partial class Note
	{
		private string nameField;
		private bool nameFieldSpecified;

		private string textField;
		private bool textFieldSpecified;

		private ImageData imageDataField;
		private bool imageDataFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nameSpecified { get { return this.nameFieldSpecified; } set { this.nameFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("text")]
		public string text { get { return this.textField; } set { this.textField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool textSpecified { get { return this.textFieldSpecified; } set { this.textFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("imageData")]
		public ImageData imageData { get { return this.imageDataField; } set { this.imageDataField = value; } }
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool imageDataSpecified { get { return this.imageDataFieldSpecified; } set { this.imageDataFieldSpecified = value; } }
	}

	public partial class pc
	{
		private List<Character> characterField;

		private List<ImageData> imageDataField;

		private int versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("character")]
		public List<Character> character
		{
			get { return this.characterField; }
			set { this.characterField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("imageData")]
		public List<ImageData> imageData
		{
			get { return this.imageDataField; }
			set { this.imageDataField = value; }
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("version")]
		public int version
		{
			get { return this.versionField; }
			set { this.versionField = value; }
		}
	}

	public partial class data
	{
		private List<Character> characterField;
		private List<ImageData> imageDataField;
		private int uidField;
		private int versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("character")]
		public List<Character> character
		{
			get { return this.characterField; }
			set { this.characterField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("imageData")]
		public List<ImageData> imageData
		{
			get { return this.imageDataField; }
			set { this.imageDataField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("uid")]
		public int uid
		{
			get { return this.uidField; }
			set { this.uidField = value; }
		}

		[System.Xml.Serialization.XmlElementAttribute("version")]
		public int version
		{
			get { return this.versionField; }
			set { this.versionField = value; }
		}
	}

	public partial class PcClass
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
		private List<Feat> featField;
		private bool featFieldSpecified;
		private int spellAbilityField;
		private bool spellAbilityFieldSpecified;
		private List<XMLSpell> spellField;
		private bool spellFieldSpecified;
		private List<Mod> modField;
		private bool modFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("mod")]
		public List<Mod> mod { get { return this.modField; } set { this.modField = value; } }

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
		public List<Feat> feat { get { return this.featField; } set { this.featField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecified { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("spellAbility")]
		public int spellAbility { get { return this.spellAbilityField; } set { this.spellAbilityField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellAbilitySpecified { get { return this.spellAbilityFieldSpecified; } set { this.spellAbilityFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("spell")]
		public List<XMLSpell> spell { get { return this.spellField; } set { this.spellField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellSpecified { get { return this.spellFieldSpecified; } set { this.spellFieldSpecified = value; } }
	}

	public partial class Race
	{
		private string nameField;

		private string ageField;

		private string heightField;

		private string weightField;

		private string eyesField;

		private string skinField;

		private string hairField;

		private string speedField;

		private bool speedFieldSpecified;

		private List<int> proficiencyField;

		private bool proficiencyFieldSpecified;

		private List<Feat> featField;

		private bool featFieldSpecified;

		private List<Mod> modField;

		private bool modFieldSpecified;

		private int spellAbilityField;

		private bool spellAbilityFieldSpecified;

		private List<XMLSpell> spellField;

		private bool spellFieldSpecified;

		[System.Xml.Serialization.XmlElementAttribute("name")]
		public string name { get { return this.nameField; } set { this.nameField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("age")]
		public string age { get { return this.ageField; } set { this.ageField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("height")]
		public string height { get { return this.heightField; } set { this.heightField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("weight")]
		public string weight { get { return this.weightField; } set { this.weightField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("eyes")]
		public string eyes { get { return this.eyesField; } set { this.eyesField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("skin")]
		public string skin { get { return this.skinField; } set { this.skinField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("hair")]
		public string hair { get { return this.hairField; } set { this.hairField = value; } }

		[System.Xml.Serialization.XmlElementAttribute("proficiency")]
		public List<int> proficiency { get { return this.proficiencyField; } set { this.proficiencyField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool proficiencySpecified { get { return this.proficiencyFieldSpecified; } set { this.proficiencyFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public List<Feat> feat { get { return this.featField; } set { this.featField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecified { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("mod")]
		public List<Mod> mod { get { return this.modField; } set { this.modField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("spellAbility")]
		public int spellAbility { get { return this.spellAbilityField; } set { this.spellAbilityField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellAbilitySpecified { get { return this.spellAbilityFieldSpecified; } set { this.spellAbilityFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("spell")]
		public List<XMLSpell> spell { get { return this.spellField; } set { this.spellField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellSpecified { get { return this.spellFieldSpecified; } set { this.spellFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("speed")]
		public string speed { get { return this.speedField; } set { this.speedField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool seedSpecified { get { return this.speedFieldSpecified; } set { this.speedFieldSpecified = value; } }
	}
	
	public partial class XMLSpell
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
