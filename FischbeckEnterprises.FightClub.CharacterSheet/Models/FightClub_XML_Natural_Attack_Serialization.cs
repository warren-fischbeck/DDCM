using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
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
        public string name {get{return this.nameField;}set{this.nameField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool nameSpecified {get{return this.nameFieldSpecified;}set{this.nameFieldSpecified=value;}}

		[System.Xml.Serialization.XmlElementAttribute("type")]
        public int type {get{return this.typeField;}set{this.typeField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool typeSpecified {get{return this.typeFieldSpecified;}set{this.typeFieldSpecified=value;}}
		
		[System.Xml.Serialization.XmlElementAttribute("attackBonus")]
        public string attackBonus {get{return this.attackBonusField;}set{this.attackBonusField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attackBonusSpecified {get{return this.attackBonusFieldSpecified;}set{this.attackBonusFieldSpecified=value;}}

		[System.Xml.Serialization.XmlElementAttribute("damage")]
        public string damage {get{return this.damageField;}set{this.damageField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool damageSpecified {get{return this.damageFieldSpecified;}set{this.damageFieldSpecified=value;}}

		[System.Xml.Serialization.XmlElementAttribute("damageType")]
        public string damageType {get{return this.damageTypeField;}set{this.damageTypeField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool damageTypeSpecified {get{return this.damageTypeFieldSpecified;}set{this.damageTypeFieldSpecified=value;}}
	}
}