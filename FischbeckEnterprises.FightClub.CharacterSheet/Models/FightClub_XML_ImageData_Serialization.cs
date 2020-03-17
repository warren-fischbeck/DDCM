using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ImageData
    {

        private ushort uidField;

        private string encodedField;

        /// <remarks/>
        public ushort uid
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
    }
}