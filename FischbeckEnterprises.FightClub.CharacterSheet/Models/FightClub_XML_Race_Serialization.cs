using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
	public partial class Race
	{
		private string nameField;

		private string ageField;

		private string heightField;

		private string weightField;

		private string eyesField;

		private string skinField;

		private string hairField;

		private int[] proficiencyField;

		private bool proficiencyFieldSpecified;

		private Feat[] featField;

		private bool featFieldSpecified;

		private Mod[] modField;

		private bool modFieldSpecified;

		private int spellAbilityField;

		private bool spellAbilityFieldSpecified;

		private Spell[] spellField;

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
		public int[] proficiency { get { return this.proficiencyField; } set { this.proficiencyField = value; } }

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool proficiencySpecified { get { return this.proficiencyFieldSpecified; } set { this.proficiencyFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("feat")]
		public Feat[] feat { get { return this.featField; } set { this.featField = value; } }
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool featSpecified { get { return this.featFieldSpecified; } set { this.featFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("mod")]
		public Mod[] mod { get { return this.modField; } set { this.modField = value; } }
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool modSpecified { get { return this.modFieldSpecified; } set { this.modFieldSpecified = value; } }

		[System.Xml.Serialization.XmlElementAttribute("spellAbility")]
		public int spellAbility { get { return this.spellAbilityField; } set { this.spellAbilityField = value; } }
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellAbilitySpecified { get { return this.spellAbilityFieldSpecified; } set { this.spellAbilityFieldSpecified = value; } }
	
		[System.Xml.Serialization.XmlElementAttribute("spell")]
		public Spell[] spell { get { return this.spellField; } set { this.spellField = value; } }
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool spellSpecified { get { return this.spellFieldSpecified; } set { this.spellFieldSpecified = value; } }
}
}