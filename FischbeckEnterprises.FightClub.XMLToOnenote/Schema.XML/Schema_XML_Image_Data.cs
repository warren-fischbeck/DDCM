namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.XML
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    partial class Schema_XML_Image_Data
    {
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ImageData
        {
            private int uidField;
            private string encodedField;
            private bool encodedFieldSpecified;

            /// <remarks/>
            public int uid
            {
                get { return this.uidField; }
                set { this.uidField = value; }
            }
            /// <remarks/>
            public string encoded
            {
                get { return this.encodedField; }
                set { this.encodedField = value; }
            }
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool encodedSpecified
            {
                get { return this.encodedFieldSpecified; }
                set { this.encodedFieldSpecified = value; }
            }
        }
    }
}
