using FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Sources
{
    public partial class Schema_Source_XML_Item
    {
        private string NameField = "N/A";
        private string DetailField = "N/A";
        private List<string> TextField;
        private ItemType TypeField;
        private int MagicField;
        private double ValueField;
        private string WeightField = "N/A";
        private int ACField;
        private List<Schema_Source_XML_Modifier> ModifierField;
        private string Damage1HandedField = "N/A";
        private string Damage2HandedField = "N/A";
        private DamgeType DamageTypeField;
        private List<ItemProperty> PropertyField = new List<ItemProperty>();
        private string StrengthField = "N/A";
        private int QuantityField;
        private string WeaponRangeField = "N/A";
        private string WeaponLongRangeField = "N/A";


        [XmlElementAttribute("name")]
        public string Name
        {
            get { return this.NameField; }
            set { this.NameField = value; }
        }
        [XmlElementAttribute("detail")]
        public string Detail
        {
            get { return this.DetailField; }
            set { this.DetailField = value; }
        }
        [XmlElementAttribute("text")]
        public List<string> Text
        {
            get { return this.TextField; }
            set { this.TextField = value; }
        }
        [XmlElementAttribute("type")]
        public string Type
        {
            get { return TypeConverter(this.TypeField); }
            set { this.TypeField = TypeConverter(value); }
        }
        [XmlElementAttribute("magic")]
        public int Magic
        {
            get { return this.MagicField; }
            set { this.MagicField = value; }
        }
        [XmlElementAttribute("value")]
        public string Value
        {
            get { return this.ValueField.ToString(); }
            set { if (! string.IsNullOrEmpty(value)) { this.ValueField = Convert.ToDouble(value); } }
        }
        [XmlElementAttribute("weight")]
        public string Weight
        {
            get { return this.WeightField; }
            set { this.WeightField = value; }
        }
        [XmlElementAttribute("ac")]
        public int AC
        {
            get { return this.ACField; }
            set { this.ACField = value; }
        }
        [XmlElementAttribute("modifier")]
        public List<Schema_Source_XML_Modifier> Modifier
        {
            get { return this.ModifierField; }
            set { this.ModifierField = value; }
        }
        [XmlElementAttribute("dmg1")]
        public string Damage1Handed
        {
            get { return this.Damage1HandedField; }
            set { this.Damage1HandedField = value; }
        }
        [XmlElementAttribute("dmg2")]
        public string Damage2Handed
        {
            get { return this.Damage2HandedField; }
            set { this.Damage2HandedField = value; }
        }
        [XmlElementAttribute("dmgType")]
        public string DamageType
        {
            get { return DmgType(this.DamageTypeField); }
            set { this.DamageTypeField = DmgType(value); }
        }
        [XmlElementAttribute("property")]
        public string Property
        {
            get { return PropertyConverter(this.PropertyField); }
            set { this.PropertyField = PropertyConverter(value); }
        }
        [XmlElementAttribute("strength")]
        public string Strength
        {
            get { return this.StrengthField; }
            set { this.StrengthField = value; }
        }
        [XmlElementAttribute("quantity")]
        public int Quantity
        {
            get { return this.QuantityField; }
            set { this.QuantityField = value; }
        }
        [XmlElementAttribute("range")]
        public string WeaponRange
        {
            get { return RangeConverter(this.WeaponRangeField, this.WeaponLongRangeField); }
            set { RangeConverter(value); }
        }


        private string DmgType(DamgeType Type)
        {
            string _Type = "";
            switch (Type)
            {
                case DamgeType.Bludgening:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"B"; } else { _Type += $", B"; }
                    break;
                case DamgeType.Piercing:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"P"; } else { _Type += $", P"; }
                    break;
                case DamgeType.Slashing:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"S"; } else { _Type += $", S"; }
                    break;
                case DamgeType.Acid:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"A"; } else { _Type += $", A"; }
                    break;
                case DamgeType.Cold:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"C"; } else { _Type += $", C"; }
                    break;
                case DamgeType.Fire:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"F"; } else { _Type += $", F"; }
                    break;
                case DamgeType.Force:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"FC"; } else { _Type += $", FC"; }
                    break;
                case DamgeType.Lightning:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"L"; } else { _Type += $", L"; }
                    break;
                case DamgeType.Necrotic:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"N"; } else { _Type += $", N"; }
                    break;
                case DamgeType.Poison:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"PS"; } else { _Type += $", PS"; }
                    break;
                case DamgeType.Radiant:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"R"; } else { _Type += $", R"; }
                    break;
                case DamgeType.Thunder:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"T"; } else { _Type += $", T"; }
                    break;
                default:
                    if (string.IsNullOrEmpty(_Type)) { _Type = $"B"; } else { _Type += $", B"; }
                    break;
            }
            return _Type;
        }

        private DamgeType DmgType(string Type)
        {
            switch (Type.ToLower())
            {
                case "b":
                    return DamgeType.Bludgening;
                    
                case "p":
                    return DamgeType.Piercing;
                    
                case "s":
                    return DamgeType.Slashing;
                    
                case "a":
                    return DamgeType.Acid;
                    
                case "c":
                    return DamgeType.Cold;
                    
                case "f":
                    return DamgeType.Fire;
                    
                case "fc":
                    return DamgeType.Force;
                    
                case "l":
                    return DamgeType.Lightning;
                    
                case "n":
                    return DamgeType.Necrotic;
                    
                case "ps":
                    return DamgeType.Poison;
                    
                case "r":
                    return DamgeType.Radiant;
                    
                case "t":
                    return DamgeType.Thunder;
                    
                default:
                    return DamgeType.Bludgening;                    
            }
        }

        private string TypeConverter(ItemType Type)
        {
            string result;
            switch (Type)
            {
                case ItemType.LightArmor:
                    result = "LA";
                    break;
                case ItemType.MediumArmor:
                    result = "MA";
                    break;
                case ItemType.HeavyArmor:
                    result = "HA";
                    break;
                case ItemType.Shield:
                    result = "S";
                    break;
                case ItemType.MeleeWeapon:
                    result = "M";
                    break;
                case ItemType.RangedWeapon:
                    result = "R";
                    break;
                case ItemType.Ammunition:
                    result = "A";
                    break;
                case ItemType.Rod:
                    result = "RD";
                    break;
                case ItemType.Staff:
                    result = "ST";
                    break;
                case ItemType.Wand:
                    result = "WD";
                    break;
                case ItemType.Ring:
                    result = "RG";
                    break;
                case ItemType.Potion:
                    result = "P";
                    break;
                case ItemType.Scroll:
                    result = "SC";
                    break;
                case ItemType.WonderousItem:
                    result = "W";
                    break;
                case ItemType.AdventeringGear:
                    result = "G";
                    break;
                case ItemType.Money:
                    result = "$";
                    break;
                default:
                    result = "N/A";
                    break;
            }
            return result;
        }

        private ItemType TypeConverter(string Type)
        {
            switch (Type.ToUpper())
            {
                case "LA":
                    return ItemType.LightArmor;
                case "MA":
                    return ItemType.MediumArmor;
                case "HA":
                    return ItemType.HeavyArmor;
                case "S":
                    return ItemType.Shield;
                case "M": 
                    return ItemType.MeleeWeapon;
                case "R":
                    return ItemType.RangedWeapon;
                case "A":
                    return ItemType.Ammunition;
                case "RD":
                    return ItemType.Rod;
                case "ST": 
                    return ItemType.Staff;
                case "WD": 
                    return ItemType.Wand;
                case "RG": 
                    return ItemType.Ring;
                case "P": 
                    return ItemType.Potion;
                case "SC": 
                    return ItemType.Scroll;
                case "W": 
                    return ItemType.Wand;
                case "G": 
                    return ItemType.AdventeringGear;
                case "$": 
                    return ItemType.Money;
                default:
                    return ItemType.Money;
            }
        }

        private List<ItemProperty> PropertyConverter(string Type)
        {
            List<ItemProperty> properties = new List<ItemProperty>();
            string[] Types = Type.Split(',');
            for (int i = 0; i < Types.Length; i++)
            {
                switch (Types[i].ToUpper())
                {
                    case "A": { properties.Add(ItemProperty.Ammunition); break; }
                    case "F": { properties.Add(ItemProperty.Finesse); break; }
                    case "H": { properties.Add(ItemProperty.Heavy); break; }
                    case "L": { properties.Add(ItemProperty.Light); break; }
                    case "LD": { properties.Add(ItemProperty.Loading); break; }
                    case "R": { properties.Add(ItemProperty.Reach); break; }
                    case "S": { properties.Add(ItemProperty.Special); break; }
                    case "T": { properties.Add(ItemProperty.Thrown); break; }
                    case "2H": { properties.Add(ItemProperty.TwoHanded); break; }
                    case "V": { properties.Add(ItemProperty.Versatile); break; }
                    case "M": { properties.Add(ItemProperty.Martial); break; }
                    default:
                        break;
                }
            }
            return properties;
        }

        private string PropertyConverter(List<ItemProperty> Type)
        {
            string returnString = string.Empty;
            foreach(ItemProperty item in Type)
            {
                switch (item)
                {
                    case ItemProperty.Ammunition:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "A"; } else { returnString += ", A"; }
                        break;
                    case ItemProperty.Finesse:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "F"; } else { returnString += ", F"; }
                        break;
                    case ItemProperty.Heavy:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "H"; } else { returnString += ", H"; }
                        break;
                    case ItemProperty.Light:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "L"; } else { returnString += ", L"; }
                        break;
                    case ItemProperty.Loading:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "LD"; } else { returnString += ", LD"; }
                        break;
                    case ItemProperty.Reach:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "R"; } else { returnString += ", R"; }
                        break;
                    case ItemProperty.Special:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "S"; } else { returnString += ", S"; }
                        break;
                    case ItemProperty.Thrown:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "T"; } else { returnString += ", T"; }
                        break;
                    case ItemProperty.TwoHanded:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "2H"; } else { returnString += ", 2H"; }
                        break;
                    case ItemProperty.Versatile:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "V"; } else { returnString += ", V"; }
                        break;
                    case ItemProperty.Martial:
                        if (string.IsNullOrEmpty(returnString)) { returnString = "M"; } else { returnString += ", M"; }
                        break;
                    case ItemProperty.Simple:
                        break;
                    default:
                        break;
                }
            }
            return returnString;
        }

        private void RangeConverter (string Type)
        {
            if (!string.IsNullOrEmpty(Type))
            {
                this.WeaponRangeField = Type.Split("/")[0];
                this.WeaponLongRangeField = Type.Split("/")[1];
            }
        }

        private string RangeConverter (string Short, string Long)
        {
            return $"{Short}/{Long}";
        }
    }
}