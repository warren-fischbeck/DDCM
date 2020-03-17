using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class pc
    {

        private pcCharacter[] characterField;

        private pcImageData[] imageDataField;

        private byte versionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("character")]
        public pcCharacter[] character
        {
            get
            {
                return this.characterField;
            }
            set
            {
                this.characterField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imageData")]
        public pcImageData[] imageData
        {
            get
            {
                return this.imageDataField;
            }
            set
            {
                this.imageDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte version
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

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacter
    {

        private byte versionField;

        private ushort uidField;

        private string nameField;

        private pcCharacterImageData imageDataField;

        private string abilitiesField;

        private byte hpMaxField;

        private byte hpCurrentField;

        private uint xpField;

        private bool xpFieldSpecified;

        private byte unarmedField;

        private pcCharacterRace raceField;

        private pcCharacterBackground backgroundField;

        private pcCharacterAttack[] attackField;

        private pcCharacterClass[] classField;

        private pcCharacterContainer[] containerField;

        private pcCharacterFeat[] featField;

        private pcCharacterItem[] itemField;

        private pcCharacterNote[] noteField;

        private pcCharacterTracker[] trackerField;

        private pcCharacterMonster[] monsterField;

        private string slotsField;

        private string slotsCurrentField;

        /// <remarks/>
        public byte version
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
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public pcCharacterImageData imageData
        {
            get
            {
                return this.imageDataField;
            }
            set
            {
                this.imageDataField = value;
            }
        }

        /// <remarks/>
        public string abilities
        {
            get
            {
                return this.abilitiesField;
            }
            set
            {
                this.abilitiesField = value;
            }
        }

        /// <remarks/>
        public byte hpMax
        {
            get
            {
                return this.hpMaxField;
            }
            set
            {
                this.hpMaxField = value;
            }
        }

        /// <remarks/>
        public byte hpCurrent
        {
            get
            {
                return this.hpCurrentField;
            }
            set
            {
                this.hpCurrentField = value;
            }
        }

        /// <remarks/>
        public uint xp
        {
            get
            {
                return this.xpField;
            }
            set
            {
                this.xpField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool xpSpecified
        {
            get
            {
                return this.xpFieldSpecified;
            }
            set
            {
                this.xpFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte unarmed
        {
            get
            {
                return this.unarmedField;
            }
            set
            {
                this.unarmedField = value;
            }
        }

        /// <remarks/>
        public pcCharacterRace race
        {
            get
            {
                return this.raceField;
            }
            set
            {
                this.raceField = value;
            }
        }

        /// <remarks/>
        public pcCharacterBackground background
        {
            get
            {
                return this.backgroundField;
            }
            set
            {
                this.backgroundField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("attack")]
        public pcCharacterAttack[] attack
        {
            get
            {
                return this.attackField;
            }
            set
            {
                this.attackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("class")]
        public pcCharacterClass[] @class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("container")]
        public pcCharacterContainer[] container
        {
            get
            {
                return this.containerField;
            }
            set
            {
                this.containerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("feat")]
        public pcCharacterFeat[] feat
        {
            get
            {
                return this.featField;
            }
            set
            {
                this.featField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public pcCharacterItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("note")]
        public pcCharacterNote[] note
        {
            get
            {
                return this.noteField;
            }
            set
            {
                this.noteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tracker")]
        public pcCharacterTracker[] tracker
        {
            get
            {
                return this.trackerField;
            }
            set
            {
                this.trackerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("monster")]
        public pcCharacterMonster[] monster
        {
            get
            {
                return this.monsterField;
            }
            set
            {
                this.monsterField = value;
            }
        }

        /// <remarks/>
        public string slots
        {
            get
            {
                return this.slotsField;
            }
            set
            {
                this.slotsField = value;
            }
        }

        /// <remarks/>
        public string slotsCurrent
        {
            get
            {
                return this.slotsCurrentField;
            }
            set
            {
                this.slotsCurrentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterImageData
    {

        private ushort uidField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterRace
    {

        private string nameField;

        private byte speedField;

        private bool speedFieldSpecified;

        private string ageField;

        private string heightField;

        private string weightField;

        private string eyesField;

        private string skinField;

        private string hairField;

        private int[] proficiencyField;

        private pcCharacterRaceFeat[] featField;

        private pcCharacterRaceMod[] modField;

        private byte spellAbilityField;

        private pcCharacterRaceSpell[] spellField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte speed
        {
            get
            {
                return this.speedField;
            }
            set
            {
                this.speedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool speedSpecified
        {
            get
            {
                return this.speedFieldSpecified;
            }
            set
            {
                this.speedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public string height
        {
            get
            {
                return this.heightField;
            }
            set
            {
                this.heightField = value;
            }
        }

        /// <remarks/>
        public string weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public string eyes
        {
            get
            {
                return this.eyesField;
            }
            set
            {
                this.eyesField = value;
            }
        }

        /// <remarks/>
        public string skin
        {
            get
            {
                return this.skinField;
            }
            set
            {
                this.skinField = value;
            }
        }

        /// <remarks/>
        public string hair
        {
            get
            {
                return this.hairField;
            }
            set
            {
                this.hairField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("proficiency")]
        public int[] proficiency
        {
            get
            {
                return this.proficiencyField;
            }
            set
            {
                this.proficiencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("feat")]
        public pcCharacterRaceFeat[] feat
        {
            get
            {
                return this.featField;
            }
            set
            {
                this.featField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mod")]
        public pcCharacterRaceMod[] mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }

        /// <remarks/>
        public byte spellAbility
        {
            get
            {
                return this.spellAbilityField;
            }
            set
            {
                this.spellAbilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("spell")]
        public pcCharacterRaceSpell[] spell
        {
            get
            {
                return this.spellField;
            }
            set
            {
                this.spellField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterRaceFeat
    {

        private string nameField;

        private string textField;

        private byte expandedField;

        private bool expandedFieldSpecified;

        private int proficiencyField;

        private bool proficiencyFieldSpecified;

        private pcCharacterRaceFeatMod[] modField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified
        {
            get
            {
                return this.expandedFieldSpecified;
            }
            set
            {
                this.expandedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int proficiency
        {
            get
            {
                return this.proficiencyField;
            }
            set
            {
                this.proficiencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool proficiencySpecified
        {
            get
            {
                return this.proficiencyFieldSpecified;
            }
            set
            {
                this.proficiencyFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mod")]
        public pcCharacterRaceFeatMod[] mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterRaceFeatMod
    {

        private byte categoryField;

        private byte typeField;

        private bool typeFieldSpecified;

        private byte valueField;

        /// <remarks/>
        public byte category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterRaceMod
    {

        private string nameField;

        private byte categoryField;

        private bool categoryFieldSpecified;

        private byte typeField;

        private bool typeFieldSpecified;

        private byte valueField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool categorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterRaceSpell
    {

        private string nameField;

        private byte schoolField;

        private byte ritualField;

        private bool ritualFieldSpecified;

        private byte levelField;

        private bool levelFieldSpecified;

        private string timeField;

        private string rangeField;

        private byte vField;

        private byte sField;

        private byte mField;

        private bool mFieldSpecified;

        private string materialsField;

        private string durationField;

        private string textField;

        private byte preparedField;

        private bool preparedFieldSpecified;

        private string rollField;

        private string[] sclassField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte school
        {
            get
            {
                return this.schoolField;
            }
            set
            {
                this.schoolField = value;
            }
        }

        /// <remarks/>
        public byte ritual
        {
            get
            {
                return this.ritualField;
            }
            set
            {
                this.ritualField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ritualSpecified
        {
            get
            {
                return this.ritualFieldSpecified;
            }
            set
            {
                this.ritualFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool levelSpecified
        {
            get
            {
                return this.levelFieldSpecified;
            }
            set
            {
                this.levelFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        public string range
        {
            get
            {
                return this.rangeField;
            }
            set
            {
                this.rangeField = value;
            }
        }

        /// <remarks/>
        public byte v
        {
            get
            {
                return this.vField;
            }
            set
            {
                this.vField = value;
            }
        }

        /// <remarks/>
        public byte s
        {
            get
            {
                return this.sField;
            }
            set
            {
                this.sField = value;
            }
        }

        /// <remarks/>
        public byte m
        {
            get
            {
                return this.mField;
            }
            set
            {
                this.mField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mSpecified
        {
            get
            {
                return this.mFieldSpecified;
            }
            set
            {
                this.mFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string materials
        {
            get
            {
                return this.materialsField;
            }
            set
            {
                this.materialsField = value;
            }
        }

        /// <remarks/>
        public string duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte prepared
        {
            get
            {
                return this.preparedField;
            }
            set
            {
                this.preparedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool preparedSpecified
        {
            get
            {
                return this.preparedFieldSpecified;
            }
            set
            {
                this.preparedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string roll
        {
            get
            {
                return this.rollField;
            }
            set
            {
                this.rollField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sclass")]
        public string[] sclass
        {
            get
            {
                return this.sclassField;
            }
            set
            {
                this.sclassField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterBackground
    {

        private string nameField;

        private string alignField;

        private string factionField;

        private string personalityField;

        private string idealsField;

        private string bondsField;

        private string flawsField;

        private int[] proficiencyField;

        private pcCharacterBackgroundFeat[] featField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string align
        {
            get
            {
                return this.alignField;
            }
            set
            {
                this.alignField = value;
            }
        }

        /// <remarks/>
        public string faction
        {
            get
            {
                return this.factionField;
            }
            set
            {
                this.factionField = value;
            }
        }

        /// <remarks/>
        public string personality
        {
            get
            {
                return this.personalityField;
            }
            set
            {
                this.personalityField = value;
            }
        }

        /// <remarks/>
        public string ideals
        {
            get
            {
                return this.idealsField;
            }
            set
            {
                this.idealsField = value;
            }
        }

        /// <remarks/>
        public string bonds
        {
            get
            {
                return this.bondsField;
            }
            set
            {
                this.bondsField = value;
            }
        }

        /// <remarks/>
        public string flaws
        {
            get
            {
                return this.flawsField;
            }
            set
            {
                this.flawsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("proficiency")]
        public int[] proficiency
        {
            get
            {
                return this.proficiencyField;
            }
            set
            {
                this.proficiencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("feat")]
        public pcCharacterBackgroundFeat[] feat
        {
            get
            {
                return this.featField;
            }
            set
            {
                this.featField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterBackgroundFeat
    {

        private string nameField;

        private string textField;

        private byte expandedField;

        private bool expandedFieldSpecified;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified
        {
            get
            {
                return this.expandedFieldSpecified;
            }
            set
            {
                this.expandedFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterAttack
    {

        private string nameField;

        private byte typeField;

        private string attackBonusField;

        private string damageField;

        private byte damageTypeField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string attackBonus
        {
            get
            {
                return this.attackBonusField;
            }
            set
            {
                this.attackBonusField = value;
            }
        }

        /// <remarks/>
        public string damage
        {
            get
            {
                return this.damageField;
            }
            set
            {
                this.damageField = value;
            }
        }

        /// <remarks/>
        public byte damageType
        {
            get
            {
                return this.damageTypeField;
            }
            set
            {
                this.damageTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClass
    {

        private string nameField;

        private byte levelField;

        private bool levelFieldSpecified;

        private byte hdCurrentField;

        private bool hdCurrentFieldSpecified;

        private byte hdField;

        private bool hdFieldSpecified;

        private string wealthField;

        private string slotsField;

        private string slotsCurrentField;

        private int[] proficiencyField;

        private byte numClassSkillsField;

        private string armorField;

        private string weaponsField;

        private string toolsField;

        private pcCharacterClassFeat[] featField;

        private pcCharacterClassTracker[] trackerField;

        private pcCharacterClassMod[] modField;

        private pcCharacterClassAutolevel[] autolevelField;

        private byte spellAbilityField;

        private pcCharacterClassSpell[] spellField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool levelSpecified
        {
            get
            {
                return this.levelFieldSpecified;
            }
            set
            {
                this.levelFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte hdCurrent
        {
            get
            {
                return this.hdCurrentField;
            }
            set
            {
                this.hdCurrentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hdCurrentSpecified
        {
            get
            {
                return this.hdCurrentFieldSpecified;
            }
            set
            {
                this.hdCurrentFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte hd
        {
            get
            {
                return this.hdField;
            }
            set
            {
                this.hdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hdSpecified
        {
            get
            {
                return this.hdFieldSpecified;
            }
            set
            {
                this.hdFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string wealth
        {
            get
            {
                return this.wealthField;
            }
            set
            {
                this.wealthField = value;
            }
        }

        /// <remarks/>
        public string slots
        {
            get
            {
                return this.slotsField;
            }
            set
            {
                this.slotsField = value;
            }
        }

        /// <remarks/>
        public string slotsCurrent
        {
            get
            {
                return this.slotsCurrentField;
            }
            set
            {
                this.slotsCurrentField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("proficiency")]
        //[System.Xml.Serialization.XmlElement(ElementName ="proficiency")]
        [System.Xml.Serialization.XmlArrayItemAttribute("proficiency", typeof(int), IsNullable = false, NestingLevel = 2)]

        public int[] proficiency
        {
            get
            {
                return this.proficiencyField;
            }
            set
            {
                this.proficiencyField = value;
            }
        }

        /// <remarks/>
        public byte numClassSkills
        {
            get
            {
                return this.numClassSkillsField;
            }
            set
            {
                this.numClassSkillsField = value;
            }
        }

        /// <remarks/>
        public string armor
        {
            get
            {
                return this.armorField;
            }
            set
            {
                this.armorField = value;
            }
        }

        /// <remarks/>
        public string weapons
        {
            get
            {
                return this.weaponsField;
            }
            set
            {
                this.weaponsField = value;
            }
        }

        /// <remarks/>
        public string tools
        {
            get
            {
                return this.toolsField;
            }
            set
            {
                this.toolsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("feat")]
        public pcCharacterClassFeat[] feat
        {
            get
            {
                return this.featField;
            }
            set
            {
                this.featField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("tracker")]
        public pcCharacterClassTracker[] tracker
        {
            get
            {
                return this.trackerField;
            }
            set
            {
                this.trackerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mod")]
        public pcCharacterClassMod[] mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("autolevel")]
        public pcCharacterClassAutolevel[] autolevel
        {
            get
            {
                return this.autolevelField;
            }
            set
            {
                this.autolevelField = value;
            }
        }

        /// <remarks/>
        public byte spellAbility
        {
            get
            {
                return this.spellAbilityField;
            }
            set
            {
                this.spellAbilityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("spell")]
        public pcCharacterClassSpell[] spell
        {
            get
            {
                return this.spellField;
            }
            set
            {
                this.spellField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassFeat
    {

        private string nameField;

        private string textField;

        private byte optionalField;

        private bool optionalFieldSpecified;

        private byte expandedField;

        private bool expandedFieldSpecified;

        private byte specialField;

        private bool specialFieldSpecified;

        private pcCharacterClassFeatMod modField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte optional
        {
            get
            {
                return this.optionalField;
            }
            set
            {
                this.optionalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool optionalSpecified
        {
            get
            {
                return this.optionalFieldSpecified;
            }
            set
            {
                this.optionalFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified
        {
            get
            {
                return this.expandedFieldSpecified;
            }
            set
            {
                this.expandedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte special
        {
            get
            {
                return this.specialField;
            }
            set
            {
                this.specialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool specialSpecified
        {
            get
            {
                return this.specialFieldSpecified;
            }
            set
            {
                this.specialFieldSpecified = value;
            }
        }

        /// <remarks/>
        public pcCharacterClassFeatMod mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassFeatMod
    {

        private string nameField;

        private byte typeField;

        private byte valueField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassTracker
    {

        private string labelField;

        private byte typeField;

        private byte resetTypeField;

        private byte valueField;

        private byte formulaField;

        /// <remarks/>
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte resetType
        {
            get
            {
                return this.resetTypeField;
            }
            set
            {
                this.resetTypeField = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public byte formula
        {
            get
            {
                return this.formulaField;
            }
            set
            {
                this.formulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassMod
    {

        private string nameField;

        private byte categoryField;

        private byte typeField;

        private bool typeFieldSpecified;

        private byte valueField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassAutolevel
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("feat", typeof(pcCharacterClassAutolevelFeat))]
        [System.Xml.Serialization.XmlElementAttribute("level", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("scoreImprovement", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("slots", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("spellSlotsOptional", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("tracker", typeof(pcCharacterClassAutolevelTracker))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassAutolevelFeat
    {

        private string nameField;

        private string textField;

        private byte specialField;

        private bool specialFieldSpecified;

        private byte optionalField;

        private bool optionalFieldSpecified;

        private int[] proficiencyField;

        private pcCharacterClassAutolevelFeatMod[] modField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte special
        {
            get
            {
                return this.specialField;
            }
            set
            {
                this.specialField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool specialSpecified
        {
            get
            {
                return this.specialFieldSpecified;
            }
            set
            {
                this.specialFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte optional
        {
            get
            {
                return this.optionalField;
            }
            set
            {
                this.optionalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool optionalSpecified
        {
            get
            {
                return this.optionalFieldSpecified;
            }
            set
            {
                this.optionalFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("proficiency")]
        public int[] proficiency
        {
            get
            {
                return this.proficiencyField;
            }
            set
            {
                this.proficiencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mod")]
        public pcCharacterClassAutolevelFeatMod[] mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassAutolevelFeatMod
    {

        private byte categoryField;

        private bool categoryFieldSpecified;

        private byte typeField;

        private bool typeFieldSpecified;

        private byte valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public byte category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool categorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassAutolevelTracker
    {

        private string labelField;

        private byte typeField;

        private byte resetTypeField;

        private byte formulaField;

        /// <remarks/>
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte resetType
        {
            get
            {
                return this.resetTypeField;
            }
            set
            {
                this.resetTypeField = value;
            }
        }

        /// <remarks/>
        public byte formula
        {
            get
            {
                return this.formulaField;
            }
            set
            {
                this.formulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        feat,

        /// <remarks/>
        level,

        /// <remarks/>
        scoreImprovement,

        /// <remarks/>
        slots,

        /// <remarks/>
        spellSlotsOptional,

        /// <remarks/>
        tracker,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterClassSpell
    {

        private object[] itemsField;

        private ItemsChoiceType1[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("duration", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("level", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("m", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("materials", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("prepared", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("range", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ritual", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("roll", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("s", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("school", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("sclass", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("time", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("v", typeof(byte))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType1[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType1
    {

        /// <remarks/>
        duration,

        /// <remarks/>
        level,

        /// <remarks/>
        m,

        /// <remarks/>
        materials,

        /// <remarks/>
        name,

        /// <remarks/>
        prepared,

        /// <remarks/>
        range,

        /// <remarks/>
        ritual,

        /// <remarks/>
        roll,

        /// <remarks/>
        s,

        /// <remarks/>
        school,

        /// <remarks/>
        sclass,

        /// <remarks/>
        text,

        /// <remarks/>
        time,

        /// <remarks/>
        v,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterContainer
    {

        private string nameField;

        private string textField;

        private decimal valueField;

        private decimal weightField;

        private bool weightFieldSpecified;

        private byte expandedField;

        private bool expandedFieldSpecified;

        private pcCharacterContainerItem[] itemField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        public decimal weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool weightSpecified
        {
            get
            {
                return this.weightFieldSpecified;
            }
            set
            {
                this.weightFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified
        {
            get
            {
                return this.expandedFieldSpecified;
            }
            set
            {
                this.expandedFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public pcCharacterContainerItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterContainerItem
    {

        private object[] itemsField;

        private ItemsChoiceType2[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ac", typeof(sbyte))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("quantity", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("slot", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("strength", typeof(sbyte))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("value", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("weight", typeof(decimal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        ac,

        /// <remarks/>
        name,

        /// <remarks/>
        quantity,

        /// <remarks/>
        slot,

        /// <remarks/>
        strength,

        /// <remarks/>
        text,

        /// <remarks/>
        value,

        /// <remarks/>
        weight,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterFeat
    {

        private object[] itemsField;

        private ItemsChoiceType3[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("expanded", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("mod", typeof(pcCharacterFeatMod))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("prereq", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("proficiency", typeof(int))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType3[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterFeatMod
    {

        private byte categoryField;

        private bool categoryFieldSpecified;

        private byte typeField;

        private byte valueField;

        /// <remarks/>
        public byte category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool categorySpecified
        {
            get
            {
                return this.categoryFieldSpecified;
            }
            set
            {
                this.categoryFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType3
    {

        /// <remarks/>
        expanded,

        /// <remarks/>
        mod,

        /// <remarks/>
        name,

        /// <remarks/>
        prereq,

        /// <remarks/>
        proficiency,

        /// <remarks/>
        text,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterItem
    {

        private object[] itemsField;

        private ItemsChoiceType4[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ac", typeof(sbyte))]
        [System.Xml.Serialization.XmlElementAttribute("damage1H", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("damage2H", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("damageType", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("detail", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("magic", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("mod", typeof(pcCharacterItemMod))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("quantity", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("roll", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("slot", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("stealth", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("strength", typeof(sbyte))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("type", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("value", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("weaponLongRange", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("weaponProperty", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("weaponRange", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("weight", typeof(decimal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType4[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterItemMod
    {

        private string nameField;

        private byte typeField;

        private sbyte valueField;

        private bool valueFieldSpecified;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public sbyte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType4
    {

        /// <remarks/>
        ac,

        /// <remarks/>
        damage1H,

        /// <remarks/>
        damage2H,

        /// <remarks/>
        damageType,

        /// <remarks/>
        detail,

        /// <remarks/>
        magic,

        /// <remarks/>
        mod,

        /// <remarks/>
        name,

        /// <remarks/>
        quantity,

        /// <remarks/>
        roll,

        /// <remarks/>
        slot,

        /// <remarks/>
        stealth,

        /// <remarks/>
        strength,

        /// <remarks/>
        text,

        /// <remarks/>
        type,

        /// <remarks/>
        value,

        /// <remarks/>
        weaponLongRange,

        /// <remarks/>
        weaponProperty,

        /// <remarks/>
        weaponRange,

        /// <remarks/>
        weight,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterNote
    {

        private string nameField;

        private string textField;

        private byte expandedField;

        private bool expandedFieldSpecified;

        private pcCharacterNoteImageData imageDataField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public byte expanded
        {
            get
            {
                return this.expandedField;
            }
            set
            {
                this.expandedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool expandedSpecified
        {
            get
            {
                return this.expandedFieldSpecified;
            }
            set
            {
                this.expandedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public pcCharacterNoteImageData imageData
        {
            get
            {
                return this.imageDataField;
            }
            set
            {
                this.imageDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterNoteImageData
    {

        private ushort uidField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterTracker
    {

        private string labelField;

        private byte typeField;

        private bool typeFieldSpecified;

        private byte resetTypeField;

        private bool resetTypeFieldSpecified;

        private byte valueField;

        private bool valueFieldSpecified;

        private string formulaField;

        /// <remarks/>
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte resetType
        {
            get
            {
                return this.resetTypeField;
            }
            set
            {
                this.resetTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool resetTypeSpecified
        {
            get
            {
                return this.resetTypeFieldSpecified;
            }
            set
            {
                this.resetTypeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string formula
        {
            get
            {
                return this.formulaField;
            }
            set
            {
                this.formulaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonster
    {

        private object[] itemsField;

        private ItemsChoiceType5[] itemsElementNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("abilities", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("ac", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("action", typeof(pcCharacterMonsterAction))]
        [System.Xml.Serialization.XmlElementAttribute("alignment", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("cr", typeof(sbyte))]
        [System.Xml.Serialization.XmlElementAttribute("environment", typeof(ushort))]
        [System.Xml.Serialization.XmlElementAttribute("hd", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("hpCurrent", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("hpMax", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("imageData", typeof(pcCharacterMonsterImageData))]
        [System.Xml.Serialization.XmlElementAttribute("label", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("languages", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("name", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("passive", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("size", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("skill", typeof(pcCharacterMonsterSkill))]
        [System.Xml.Serialization.XmlElementAttribute("speed", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("text", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("trait", typeof(pcCharacterMonsterTrait))]
        [System.Xml.Serialization.XmlElementAttribute("type", typeof(string))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType5[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonsterAction
    {

        private string nameField;

        private string textField;

        private pcCharacterMonsterActionAttack attackField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }

        /// <remarks/>
        public pcCharacterMonsterActionAttack attack
        {
            get
            {
                return this.attackField;
            }
            set
            {
                this.attackField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonsterActionAttack
    {

        private string nameField;

        private byte attackBonusField;

        private string damageField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte attackBonus
        {
            get
            {
                return this.attackBonusField;
            }
            set
            {
                this.attackBonusField = value;
            }
        }

        /// <remarks/>
        public string damage
        {
            get
            {
                return this.damageField;
            }
            set
            {
                this.damageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonsterImageData
    {

        private ushort uidField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonsterSkill
    {

        private byte idField;

        private byte modifierField;

        /// <remarks/>
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public byte modifier
        {
            get
            {
                return this.modifierField;
            }
            set
            {
                this.modifierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcCharacterMonsterTrait
    {

        private string nameField;

        private string textField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType5
    {

        /// <remarks/>
        abilities,

        /// <remarks/>
        ac,

        /// <remarks/>
        action,

        /// <remarks/>
        alignment,

        /// <remarks/>
        cr,

        /// <remarks/>
        environment,

        /// <remarks/>
        hd,

        /// <remarks/>
        hpCurrent,

        /// <remarks/>
        hpMax,

        /// <remarks/>
        imageData,

        /// <remarks/>
        label,

        /// <remarks/>
        languages,

        /// <remarks/>
        name,

        /// <remarks/>
        passive,

        /// <remarks/>
        size,

        /// <remarks/>
        skill,

        /// <remarks/>
        speed,

        /// <remarks/>
        text,

        /// <remarks/>
        trait,

        /// <remarks/>
        type,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class pcImageData
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