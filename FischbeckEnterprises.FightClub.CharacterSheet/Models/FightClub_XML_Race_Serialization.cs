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
		public string name {get{return this.nameField;}set{this.nameField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("age")]	
		public string age {get{return this.ageField;}set{this.ageField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("height")]	
		public string height {get{return this.heightField;}set{this.heightField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("weight")]	
		public string weight {get{return this.weightField;}set{this.weightField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("eyes")]	
		public string eyes {get{return this.eyesField;}set{this.eyesField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("skin")]	
		public string skin {get{return this.skinField;}set{this.skinField=value;}}

		[System.Xml.Serialization.XmlElementAttribute("hair")]	
		public string hair {get{return this.hairField;}set{this.hairField=value;}}
	}
}