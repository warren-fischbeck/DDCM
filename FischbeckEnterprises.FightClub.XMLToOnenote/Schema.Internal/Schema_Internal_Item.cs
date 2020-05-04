using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace FischbeckEnterprises.FightClub.XMLToOnenote.Schema.Internal
{
    class Schema_Internal_Item : Schema_Internal_Object
    {
        private string DetailField;
        private List<string> TextField;
        private int TypeField;
        private bool MagicField;
        private Slot SlotField;
        private string ValueField;
        private string WeightField;
        private int ACFiled;
        private List<Schema_Internal_Modifier> ModifierField;
        private string Damage1HField;
        private string Damage2HField;
        private int DamageTypeField;
        private int WeaponPropertyField;
        private int StrengthField;
        private int QuantityField;
        private int WeaponRangeField;
        private int WeaponLongRangeField;

        public string Detail
        {
            get { return this.Detail; }
            set { this.Detail = value; }
        }
        public List<string> Text
        {
            get { return this.TextField; }
            set { this.TextField = value; }
        }
        public int Type
        {
            get { return this.TypeField; }
            set { this.TypeField = value; }
        }
        public bool Magic
        {
            get { return this.MagicField; }
            set { this.MagicField = value; }
        }
        public Slot Slot
        {
            get { return this.SlotField; }
            set { this.SlotField = value; }
        }
        public string Value
        {
            get { return this.ValueField; }
            set { this.ValueField = value; }
        }
        public string Weight
        {
            get { return this.WeightField; }
            set { this.WeightField = value; }
        }
        public int AC
        {
            get { return this.ACFiled; }
            set { this.ACFiled = value; }
        }
        public List<Schema_Internal_Modifier> Modifier
        {
            get { return this.ModifierField; }
            set { this.ModifierField = value; }
        }
        public string Damage1H
        {
            get { return this.Damage1HField; }
            set { this.Damage1HField = value; }
        }
        public string Damage2H
        {
            get { return this.Damage2HField; }
            set { this.Damage2HField = value; }
        }
public 
    }
}
