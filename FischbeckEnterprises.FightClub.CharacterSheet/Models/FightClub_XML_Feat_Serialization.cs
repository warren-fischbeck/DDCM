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
		
		private string textField;
		
		private bool expandedField;
		
		private bool expandedFieldSpecified;
		
		private mod modField;
		
		private bool modFieldSpecified;
		
		public string name{get{return this.nameField;}set{this.nameField=value;}}
		
		public string text{get{return this.textField;}set{this.textField=value;}}
		
		public bool expanded{get{return this.expandedField;}set{this.expandedField=value;}}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified{get{return this.expandedFieldSpecified;}set{this.expandedFieldSpecified=value;}}
	
		public mod mod{get{return this.modField;}set{this.mod=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool modSpecified{get{return this.modFieldSpecified;}set{this.modFieldSpecified=value;}}
	}
}