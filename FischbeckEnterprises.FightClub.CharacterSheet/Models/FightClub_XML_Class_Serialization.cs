using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
	public partial class Character
	{
		private int versionField;
		
		private int uidField;
		
		private string abilitiesField;
		
		private int hpMaxField;
		
		private int hpCurrentField;
		
		private string unarmedField;
		
		private Attack[] attackField;
		
		private PcClass[] classField;
		
		private Background backgroundField;
		
        [System.Xml.Serialization.XmlElementAttribute("version")]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }		
	}


}