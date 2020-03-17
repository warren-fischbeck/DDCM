using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
	public partial class Spell
	{
		private string  nameField;
		
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
		
		private string[] textField;
		
		private string[] sClassField;
		
		[System.Xml.Serialization.XmlElementAttribute("name")]	
		public string name {get{return this.nameField;}set{this.nameField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("school")]	
		public string school {get{return this.schoolField;}set{this.schoolField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("ritual")]	
		public int ritual {get{return this.ritualField;}set{this.ritualField=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ritualSpecified{get{return this.ritualFieldSpecified;}set{this.ritualFieldSpecified=value;}}
		
        [System.Xml.Serialization.XmlElementAttribute("time")]	
		public string time {get{return this.timeField;}set{this.timeField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("range")]	
		public string range {get{return this.rangeField;}set{this.rangeField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("v")]	
		public int v {get{return this.vField;}set{this.vField=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool vSpecified{get{return this.vFieldSpecified;}set{this.vFieldSpecified=value;}}

        [System.Xml.Serialization.XmlElementAttribute("s")]	
		public int s {get{return this.sField;}set{this.sField=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sSpecified{get{return this.sFieldSpecified;}set{this.sFieldSpecified=value;}}

        [System.Xml.Serialization.XmlElementAttribute("m")]	
		public int m {get{return this.mField;}set{this.mField=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mSpecified{get{return this.mFieldSpecified;}set{this.mFieldSpecified=value;}}

        [System.Xml.Serialization.XmlElementAttribute("matrials)]	
		public int matrials {get{return this.matrialsField;}set{this.matrialsField=value;}}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool matrialsSpecified{get{return this.matrialsFieldSpecified;}set{this.matrialsFieldSpecified=value;}}

        [System.Xml.Serialization.XmlElementAttribute("duration")]	
		public string duration {get{return this.durationField;}set{this.durationField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("text")]	
		public string text {get{return this.textField;}set{this.textField=value;}}

        [System.Xml.Serialization.XmlElementAttribute("sClass")]	
		public string sClass {get{return this.sClassField;}set{this.sClassField=value;}}

	}
}