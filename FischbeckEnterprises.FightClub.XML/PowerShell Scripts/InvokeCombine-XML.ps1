[xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5">
</compendium>  
"@

class BeastXML
{
    [string] $Name

    [ValidateSet("T","S","M","L","H","G")]
    [string] $Size

    [string] $Type

    [ValidateSet("chaotic good (75%) or neutral evil (25%)",
                "Lawful Good",
                "Lawful Neutral",
                "Lawful Evil",
                "Neutral Good",
                "Neutral",
                "Neutral Evil",
                "Chaotic Good",
                "Chaotic Neutral",
                "Chaotic Evil",
                "Unaligned",
                "Any",
                "Any Alignment",
                "any non-good alignment",
                "any evil alignment",
                "any non-lawful alignment",
                "any chaotic alignment",
                "neutral evil (50%) lawful evil (50%)",
                "neutral good (50%) or neutral evil (50%)")]
    [string] $Alignment

    [string] $AC

    [string] $HP

    [string] $Speed
   
    [int] $Strength

    [int] $Dexterity

    [int] $Constitution

    [int] $Intellegence

    [int] $Wisdom

    [int] $Charisma

    [string] $SaveThrows

    [string] $Skill

    [string] $Vulnerable

    [string] $Resist

    [string] $Immune

    [string] $ConditionImmune

    [string] $Senses

    [string] $Passive

    [string] $Languages

    [string] $CR

    [ActionTraitLegendary[]] $Action

    [ActionTraitLegendary[]] $Trait

    [ActionTraitLegendary[]] $Legendary
    
    [ActionTraitLegendary[]] $Reaction

    [string] $Slots

    [string] $Spells

    [string] $Environment

    [string] $Description

    [xml] $XML

    # Constructor
    BeastXML ([string] $Name)
    {
        $this.Name = $Name
    }

    BeastXML ([System.Xml.XmlElement] $XMLElement)
    {
        $this.Name = $XMLElement.name
        $this.AC = $XMLElement.ac
        if($XMLElement.alignment -eq $null) { $this.Alignment = "Unaligned" }
            else { $this.Alignment = $XMLElement.alignment }
        $this.Charisma = $XMLElement.cha
        $this.ConditionImmune = $XMLElement.conditionimmune
        $this.Constitution = $XMLElement.con
        $this.CR = $XMLElement.cr
        $this.Description = $XMLElement.description
        $this.Dexterity = $XMLElement.dex
        $this.Environment = $XMLElement.environment
        $this.HP = $XMLElement.hp
        $this.Immune = $XMLElement.immune
        $this.Intellegence = $XMLElement.int
        $this.Languages = $XMLElement.languages
        $this.Passive = $XMLElement.passive
        $this.Resist = $XMLElement.resist
        $this.SaveThrows = $XMLElement.save
        $this.Skill = $XMLElement.skill
        $this.Senses = $XMLElement.senses
        $this.Size = $XMLElement.size
        $this.Slots = $XMLElement.slots
        $this.Speed = $XMLElement.speed
        $this.Spells = $XMLElement.spells
        $this.Strength = $XMLElement.str
        $this.Type = $XMLElement.type
        $this.Vulnerable = $XMLElement.vulnerable
        $this.Wisdom = $XMLElement.wis
        $this.Action = $this.CreateActions($XMLElement.action)
        $this.Trait = $this.CreateActions($XMLElement.trait)
        $this.Legendary = $this.CreateActions($XMLElement.legendary)
        $this.Reaction = $this.CreateActions($XMLElement.reaction)

        $this.Spells = $this.Spells.Replace(".",",")
    }

    CreateXML($XMLFile)
    {
        $this.XML = $XMLFile
        $this.Compare()
    }

    Compare ()
    {
        $Create = $true

        foreach($monster in $this.XML.compendium.monster)
        {
            if($monster.name -eq $this.Name)
            {
                $Create = $false
                Write-Host "Found monster - $($this.Name)"
                $this.CompareSize($monster)
                $this.CompareType($monster)
                $this.CompareAC($monster)
                $this.CompareAlignment($monster)
                $this.CompareCha($monster)
                $this.CompareCon($monster)
                $this.CompareCond($monster)
                $this.CompareCR($monster)
                $this.CompareDes($monster)
                $this.CompareDex($monster)
                $this.CompareEnv($monster)
                $this.CompareHP($monster)
                $this.CompareImm($monster)
                $this.CompareInt($monster)
                $this.CompareLan($monster)
                $this.ComparePas($monster)
                $this.CompareRes($monster)
                $this.CompareSave($monster)
                $this.CompareSen($monster)
                $this.CompareSize($monster)
                $this.CompareSkill($monster)
                $this.CompareSlo($monster)
                $this.CompareSpe($monster)
                $this.CompareSpeed($monster)
                $this.CompareStr($monster)
                $this.CompareType($monster)
                $this.CompareVul($monster)
                $this.CompareWis($monster)
            }
        }

        if($Create)
        {
            $this.Create($this.XML)
        }
    }

    Hidden CompareSize ([System.Xml.XmlElement] $Element)
    {
        if($Element.size -ne $this.Size) { $Element.size = $this.Size }
    }

    Hidden CompareType ([System.Xml.XmlElement] $Element)
    {
        if($Element.type -ne $this.Type) { $Element.type = $this.Type }
    }

    Hidden CompareAlignment ([System.Xml.XmlElement] $Element)
    {
        if($Element.alignment -eq $this.Alignment) { $Element.alignment = $this.Alignment }
    }

    Hidden CompareAC ([System.Xml.XmlElement] $Element)
    {
        if($Element.ac -ne $this.AC) { $Element.ac = $this.AC }
    }

    Hidden CompareHP ([System.Xml.XmlElement] $Element)
    {
        if($Element.hp -ne $this.HP) { $Element.hp = $this.HP }
    }

    Hidden CompareSpeed ([System.Xml.XmlElement] $Element)
    {
        if($Element.speed -ne $this.Speed) { $Element.speed = $this.Speed }
    }

    Hidden CompareStr ([System.Xml.XmlElement] $Element)
    {
        if($Element.str -ne $this.Strength) { $Element.str = $this.Strength }
    }

    Hidden CompareDex ([System.Xml.XmlElement] $Element)
    {
        if($Element.dex -ne $this.Dexterity) { $Element.dex = $this.Dexterity }
    }

    Hidden CompareCon ([System.Xml.XmlElement] $Element)
    {
        if($Element.con -ne $this.Constitution) { $Element.con = $this.Constitution }
    }

    Hidden CompareInt ([System.Xml.XmlElement] $Element)
    {
        if($Element.int -ne $this.Intellegence) { $Element.int = $this.Intellegence }
    }

    Hidden CompareWis ([System.Xml.XmlElement] $Element)
    {
        if($Element.wis -ne $this.Wisdom) { $Element.wis = $this.Wisdom }
    }

    Hidden CompareCha ([System.Xml.XmlElement] $Element)
    {
        if($Element.cha -ne $this.Charisma) { $Element.cha = $this.Charisma }
    }

    Hidden CompareSave ([System.Xml.XmlElement] $Element)
    {
        if($Element.save -ne $this.SaveThrows) { $Element.save = $this.SaveThrows }
    }

    Hidden CompareSkill ([System.Xml.XmlElement] $Element)
    {
        if($Element.skill -ne $this.Skill) { $Element.skill = $this.Skill }
    }

    Hidden CompareVul ([System.Xml.XmlElement] $Element)
    {
        if($Element.vulnerable -ne $this.Vulnerable) { $Element.vulnerable = $this.Vulnerable }
    }

    Hidden CompareRes ([System.Xml.XmlElement] $Element)
    {
        if($Element.resist -ne $this.Resist) { $Element.resist = $this.Resist }
    }

    Hidden CompareImm ([System.Xml.XmlElement] $Element)
    {
        if($Element.immune -ne $this.Immune) { $Element.immune = $this.Immune }
    }

    Hidden CompareCond ([System.Xml.XmlElement] $Element)
    {
        if($Element.conditionimmune -ne $this.ConditionImmune) { $Element.conditionimmune = $this.ConditionImmune }
    }

    Hidden CompareSen ([System.Xml.XmlElement] $Element)
    {
        if($Element.senses -ne $this.Senses) { $Element.senses = $this.Senses }
    }

    Hidden ComparePas ([System.Xml.XmlElement] $Element)
    {
        if($Element.passive -ne $this.Passive) { $Element.passive = $this.Passive }
    }

    Hidden CompareLan ([System.Xml.XmlElement] $Element)
    {
        if($Element.languages -ne $this.Languages) { $Element.languages = $this.Languages }
    }

    Hidden CompareCR ([System.Xml.XmlElement] $Element)
    {
        if($Element.cr -ne $this.CR) { $Element.cr = $this.CR }
    }

    Hidden CompareSlo ([System.Xml.XmlElement] $Element)
    {
        if($Element.slots -ne $this.Slots) { $Element.slots = $this.Slots }
    }

    Hidden CompareSpe ([System.Xml.XmlElement] $Element)
    {
        if($Element.spells -ne $this.Spells) { $Element.spells = $this.Spells }
    }

    Hidden CompareEnv ([System.Xml.XmlElement] $Element)
    {
        if($Element.environment -ne $this.Environment) { $Element.environment = $this.Environment }
    }

    Hidden CompareDes ([System.Xml.XmlElement] $Element)
    {
        if($Element.description -ne $this.Description) 
        {
            if( $this.Description.Length -gt $Element.description.Length )
            {
                $Element.description = $this.Description
            }
        }
    }

    Hidden Create($XMLFile)
    {
        $NewMonsterElement = $XMLFile.CreateElement("monster")
        $NameElement = $XMLFile.CreateElement("name")
        $SizeElement = $XMLFile.CreateElement("size")
        $TypeElement = $XMLFile.CreateElement("type")
        $ACElement = $XMLFile.CreateElement("ac")
        $HPElement = $XMLFile.CreateElement("hp")
        $SpeedElement = $XMLFile.CreateElement("speed")
        $StrElement = $XMLFile.CreateElement("str")
        $DexElement = $XMLFile.CreateElement("dex")
        $ConElement = $XMLFile.CreateElement("con")
        $IntElement = $XMLFile.CreateElement("int")
        $WisElement = $XMLFile.CreateElement("wis")
        $ChaElement = $XMLFile.CreateElement("cha")
        $SaveElement = $XMLFile.CreateElement("save")
        $SkillElement = $XMLFile.CreateElement("skill")
        $VulnerableElement = $XMLFile.CreateElement("vulnerable")
        $ResistElement = $XMLFile.CreateElement("resist")
        $ImmuneElement = $XMLFile.CreateElement("immune")
        $ConditionImmuneElement = $XMLFile.CreateElement("conditionimmune")
        $SensesElement = $XMLFile.CreateElement("senses")
        $LanguagesElement = $XMLFile.CreateElement("languages")
        $CRElement = $XMLFile.CreateElement("cr")
        $SlotsElement = $XMLFile.CreateElement("slots")
        $SpellsElement = $XMLFile.CreateElement("spells")
        $EnvironmentElement = $XMLFile.CreateElement("environment")
        $DescriptionElement = $XMLFile.CreateElement("description")
        $AlignmentElement = $XMLFile.CreateElement("alignment")
        $PassiveElement = $XMLFile.CreateElement("passive")

        $NameElement.InnerXml = $this.Name
        $SizeElement.InnerXml = $this.Size
        $TypeElement.InnerXml = $this.Type
        $ACElement.InnerXml = $this.AC
        $HPElement.InnerXml = $this.HP
        $SpeedElement.InnerXml = $this.Speed
        $StrElement.InnerXml = $this.Strength
        $DexElement.InnerXml = $this.Dexterity
        $ConElement.InnerXml = $this.Constitution
        $IntElement.InnerXml = $this.Intellegence
        $WisElement.InnerXml = $this.Wisdom
        $ChaElement.InnerXml = $this.Charisma
        $SaveElement.InnerXml = $this.SaveThrows
        $SkillElement.InnerXml = $this.Skill
        $VulnerableElement.InnerXml = $this.Vulnerable
        $ResistElement.InnerXml = $this.Resist
        $ImmuneElement.InnerXml = $this.Immune
        $ConditionImmuneElement.InnerXml = $this.ConditionImmune
        $SensesElement.InnerXml = $this.Senses
        $LanguagesElement.InnerXml = $this.Languages
        $CRElement.InnerXml = $this.CR
        $SlotsElement.InnerXml = $this.Slots
        $SpellsElement.InnerXml = $this.Spells
        $EnvironmentElement.InnerXml = $this.Environment
        $DescriptionElement.InnerXml = $this.Description
        $AlignmentElement.InnerXml = $this.Alignment
        $PassiveElement.InnerXml = $this.Passive

        $NewMonsterElement.AppendChild($NameElement)
        $NewMonsterElement.AppendChild($SizeElement)
        $NewMonsterElement.AppendChild($TypeElement)
        $NewMonsterElement.AppendChild($ACElement)
        $NewMonsterElement.AppendChild($HPElement)
        $NewMonsterElement.AppendChild($SpeedElement)
        $NewMonsterElement.AppendChild($StrElement)
        $NewMonsterElement.AppendChild($DexElement)
        $NewMonsterElement.AppendChild($ConElement)
        $NewMonsterElement.AppendChild($IntElement)
        $NewMonsterElement.AppendChild($WisElement)
        $NewMonsterElement.AppendChild($ChaElement)
        $NewMonsterElement.AppendChild($SaveElement)
        $NewMonsterElement.AppendChild($SkillElement)
        $NewMonsterElement.AppendChild($VulnerableElement)
        $NewMonsterElement.AppendChild($ResistElement)
        $NewMonsterElement.AppendChild($ImmuneElement)
        $NewMonsterElement.AppendChild($ConditionImmuneElement)
        $NewMonsterElement.AppendChild($SensesElement)
        $NewMonsterElement.AppendChild($LanguagesElement)
        $NewMonsterElement.AppendChild($CRElement)
        $NewMonsterElement.AppendChild($SlotsElement)
        $NewMonsterElement.AppendChild($SpellsElement)
        $NewMonsterElement.AppendChild($EnvironmentElement)
        $NewMonsterElement.AppendChild($DescriptionElement)
        $NewMonsterElement.AppendChild($AlignmentElement)
        $NewMonsterElement.AppendChild($PassiveElement)

        foreach($item in $this.Action)
        {
            $ActionElement = $XMLFile.CreateElement("action")
            $ActionNameElement = $XMLFile.CreateElement("name")
            $TextElement = $XMLFile.CreateElement("text")
            $AttackElement = $XMLFile.CreateElement("attack")

            $ActionNameElement.InnerXml = $item.name
            $TextElement.InnerXml = $item.text
            $AttackElement.InnerXml = $item.attack

            $ActionElement.AppendChild($ActionNameElement)
            $ActionElement.AppendChild($TextElement)
            $ActionElement.AppendChild($AttackElement)
            $NewMonsterElement.AppendChild($ActionElement)
        }

        foreach($item in $this.Legendary)
        {
            $ActionElement = $XMLFile.CreateElement("legendary")
            $ActionNameElement = $XMLFile.CreateElement("name")
            $TextElement = $XMLFile.CreateElement("text")
            $AttackElement = $XMLFile.CreateElement("attack")

            $ActionNameElement.InnerXml = $item.name
            $TextElement.InnerXml = $item.text
            $AttackElement.InnerXml = $item.attack

            $ActionElement.AppendChild($ActionNameElement)
            $ActionElement.AppendChild($TextElement)
            $ActionElement.AppendChild($AttackElement)
            $NewMonsterElement.AppendChild($ActionElement)
        }

        foreach($item in $this.Reaction)
        {
            $ActionElement = $XMLFile.CreateElement("reaction")
            $ActionNameElement = $XMLFile.CreateElement("name")
            $TextElement = $XMLFile.CreateElement("text")
            $AttackElement = $XMLFile.CreateElement("attack")

            $ActionNameElement.InnerXml = $item.name
            $TextElement.InnerXml = $item.text
            $AttackElement.InnerXml = $item.attack

            $ActionElement.AppendChild($ActionNameElement)
            $ActionElement.AppendChild($TextElement)
            $ActionElement.AppendChild($AttackElement)
            $NewMonsterElement.AppendChild($ActionElement)
        }

        foreach($item in $this.Trait)
        {
            $ActionElement = $XMLFile.CreateElement("trait")
            $ActionNameElement = $XMLFile.CreateElement("name")
            $TextElement = $XMLFile.CreateElement("text")
            $AttackElement = $XMLFile.CreateElement("attack")

            $ActionNameElement.InnerXml = $item.name
            $TextElement.InnerXml = $item.text
            $AttackElement.InnerXml = $item.attack

            $ActionElement.AppendChild($ActionNameElement)
            $ActionElement.AppendChild($TextElement)
            $ActionElement.AppendChild($AttackElement)
            $NewMonsterElement.AppendChild($ActionElement)
        }

        $XMLFile.compendium.AppendChild($NewMonsterElement)
    }

    [ActionTraitLegendary[]] CreateActions([System.Xml.XmlElement[]] $Element)
    {
        $ActionResult = @()
        Foreach($item in $Element)
        {
            [ActionTraitLegendary] $result = [ActionTraitLegendary]::new()
            $result.Name = $item.name
            $result.Attack = $item.attack
            $result.Text = $item.text
            $ActionResult += $result
        }

        return $ActionResult
    }
}

class ActionTraitLegendary
{
    [string] $Name

    [string[]] $Text

    [string] $Attack
}

$beast = $null
ForEach ($Files in (Get-ChildItem -Path "C:\Users\wfischbeck\source\repos\warren-fischbeck\DDCM\FischbeckEnterprises.FightClub.XML\Sources\"))
{
    [xml] $content = Get-Content -Path $Files.FullName
    $beasts = $content.compendium.monster
    foreach($b in $beasts)
    {
        $b.name
        [BeastXML] $beast = [BeastXML]::new($b)
        $beast.CreateXML($xmlFile)
    }
}

$xmlFile.compendium.monster | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
Write-Host "A total of $($xmlFile.compendium.monster.Count) monsters"
$xmlFile.Save("$($env:OneDriveConsumer)\Documents\Dungeon & Dragons\xml_Sheets\Complete\_NewComplete.xml")
