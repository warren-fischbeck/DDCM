$NewNPC = [NPC]::new("fighter", "Test Name")
$NewNPC.Save()


class NPC
{
    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $ClassType

    [string] $Name

    [Abilities] $AbilityScores

    [Race] $Race


    NPC ([string] $Class, [string] $Name)
    {
        $this.Name = $Name
        $this.ClassType = (Get-Culture).TextInfo.ToTitleCase($Class)
        $this.AbilityScores = [Abilities]::new($this.ClassType)

        Write-Host -ForegroundColor Cyan "Class: $($this.ClassType)"
        Write-Host -ForegroundColor Cyan "Inital abilities: $($this.AbilityScores.AbilityScores)"

        $this.Race = [Race]::new()
        $this.AbilityScores.AbilityScores = $this.Race.RaceModifiers($this.AbilityScores.AbilityScores)

        Write-Host -ForegroundColor Cyan "Race: $($this.Race.RaceName)"
        Write-Host -ForegroundColor Cyan "Racial abilities: $($this.AbilityScores.AbilityScores)"

    }

    Save()
    {
        [NPCXML] $xml = [NPCXML]::new($this.AbilityScores, $this.NPCClass, $this.Race, $this.ClassType, $this.Name)
        $xml.CategoryName = "The First Adventurers"
        $xml.SaveNPC()
    }

}

class ClassType
{
    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $ClassName

    [int] $ClassHD

    [string] $ClassHitDice

    [int] $ClassHitPoints

    [string] $ClassSavingThrows
    
    [int] $ClassChallengeRating

    [string] $ClassSenses

    [string] $ClassSkills

    ClassType([string] $ClassType)
    {
        $this.ClassName = $ClassType
    }

    AddClass()
    {
        switch ($this.ClassName)
        {
            "Non-Combat" 
            { 
                $this.ClassHD = '4'
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Barbarian" 
            { 
                $this.ClassHD = '12'
                $this.ClassSkills = "$( $this.ClassSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Intimidation +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]))"
            }
            "Bard" 
            { 
                $this.ClassHD = '6'
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Cleric" 
            { 
                $this.ClassHD = '8'
                $this.ClassSkills = "$( $this.ClassSkills) Religon +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Druid" 
            { 
                $this.ClassHD = '8'
                $this.ClassSkills = "$( $this.ClassSkills) Nature +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Fighter" 
            { 
                $this.ClassHD = '10'
                $this.ClassSkills = "$( $this.ClassSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Acrobatics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Monk" 
            { 
                $this.ClassHD = '8' 
                $this.ClassSkills = "$( $this.ClassSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Acrobatics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Paladin" 
            { 
                $this.ClassHD = '10' 
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
            }
            "Ranger" 
            { 
                $this.ClassHD = '10' 
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Survival +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
            }
            "Rouge" 
            { 
                $this.ClassHD = '8' 
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , Stealth +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Sorcerer" 
            { 
                $this.ClassHD = '6' 
                $this.ClassSkills = "$( $this.ClassSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Warlock" 
            { 
                $this.ClassHD = '6' 
                $this.ClassSkills = "$( $this.ClassSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Wizard" 
            { 
                $this.ClassHD = '6' 
                $this.ClassSkills = "$( $this.ClassSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            Default 
            { 
                $this.ClassSkills = "$( $this.ClassSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassSkills = "$( $this.ClassSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.ClassHD = '6' 
            }
        }

    }
}

class Abilities
{
    [int[]] $AbilityScores

    # Property with validate set
    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $ClassType


    Abilities ([string] $NpcClass)
    {
        $this.ClassType = $NpcClass
        $this.AbilityScores = $this.RollAllAbilities()
        $this.AbilityScores = $this.AssignAbilities($this.ClassType)
    }

    [int] RollSingleAttributeScore ([int] $dieQuanty, [int] $dieSize)
    {
        [System.Collections.ArrayList] $result = @()
        for($i=0; $i -lt $dieQuanty; $i ++)
        {    
            $result.Add((Get-Random -Minimum 1 -Maximum $dieSize)) | Out-Null
        }
        $lowest = ($result | Measure-Object -Minimum).Minimum
        $Total = ($result | Measure-Object -Sum).Sum
        return ($Total - $lowest)
    }

    [int[]] RollAllAbilities()
    {
        $result = @()
        [System.Collections.ArrayList] $result = @()
        for($i=0; $i -lt 6; $i ++)
        {    
            $result.Add($this.RollSingleAttributeScore(4,6))
        }
        return $result 
    }

    [int] IncreaseSingleAbilityScore ([int] $scoreToIncrease)
    {
        return $scoreToIncrease + 2
    }

    [int[]] AssignAbilities([string] $Type)
    {
        $abilityScore = @()
        switch ($Type)
        {
            "Barbarian" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[0], $this.AbilityScores[2], $this.AbilityScores[1], $this.AbilityScores[5],$this.AbilityScores[3],$this.AbilityScores[4]
            }
            "Bard" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[5], $this.AbilityScores[4], $this.AbilityScores[3], $this.AbilityScores[1],$this.AbilityScores[2],$this.AbilityScores[0]
            }
            "Cleric" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[4], $this.AbilityScores[5], $this.AbilityScores[3], $this.AbilityScores[2],$this.AbilityScores[0],$this.AbilityScores[1]
            }
            "Druid" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[3], $this.AbilityScores[5], $this.AbilityScores[2], $this.AbilityScores[1],$this.AbilityScores[0],$this.AbilityScores[4]
            }
            "Fighter" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[0], $this.AbilityScores[2], $this.AbilityScores[1], $this.AbilityScores[5],$this.AbilityScores[3],$this.AbilityScores[4]
            }
            "Monk" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[0], $this.AbilityScores[2], $this.AbilityScores[1], $this.AbilityScores[5],$this.AbilityScores[3],$this.AbilityScores[4]
            }
            "Paladin" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[1], $this.AbilityScores[4], $this.AbilityScores[2], $this.AbilityScores[5],$this.AbilityScores[3],$this.AbilityScores[0]
            }
            "Ranger" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[3], $this.AbilityScores[2], $this.AbilityScores[1], $this.AbilityScores[4],$this.AbilityScores[0],$this.AbilityScores[5]
            }
            "Rouge" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[2], $this.AbilityScores[0], $this.AbilityScores[1], $this.AbilityScores[5],$this.AbilityScores[3],$this.AbilityScores[4]
            }
            "Sorcerer" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[5], $this.AbilityScores[2], $this.AbilityScores[4], $this.AbilityScores[1],$this.AbilityScores[3],$this.AbilityScores[0]
            }
            "Warlock" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[5], $this.AbilityScores[2], $this.AbilityScores[4], $this.AbilityScores[1],$this.AbilityScores[3],$this.AbilityScores[0]
            }
            "Wizard" 
            {
                $this.AbilityScores = $this.AbilityScores | sort -Descending
                $abilityScore = $this.AbilityScores[5], $this.AbilityScores[4], $this.AbilityScores[3], $this.AbilityScores[0],$this.AbilityScores[1],$this.AbilityScores[2]
            }
            Default {$abilityScore = $this.AbilityScores}
        }
        return $abilityScore
    }

    [int] Modifier([int] $AbilityScore)
    {
        return ($AbilityScore - 10)/2
    }
}

class Race
{
    [string] $RaceName

    [string] $RaceLanguages

    [string] $RaceSpeed = "30 ft"

    [string] $RaceSize = "Medium"

    [string] $RaceSenses = ""

    Race()
    {
        $this.RaceName = $this.RollRandomRace()
    }
    Race($Race)
    {
        $this.RaceName = $Race
    }

    [string] RollRandomRace()
    {
        switch ($this.RollDie(15))
        {
            '1' { return "Dwarf, Hill" }
            '2' { return "Dwarf, Mountain" }
            '3' { return "Elf, High" }
            '4' { return "Elf, Wood" }
            '5' { return "Halfling, Lightfoot" }
            '6' { return "Halfling, Stout" }
            '7' { return "Gnome, Forest" }
            '8' { return "Gnome, Rock" }
            '9' { return "Dragonborn" }
            Default { return "Human" }
        }
        return "Human"
    }

    [int] RollDie ([int] $dieSize)
    {
        return (Get-Random -Minimum 1 -Maximum $dieSize)
    }

    [int[]] RaceModifiers([int[]] $abilityScores)
    {
        [System.Collections.ArrayList] $updates = @()
        switch ($this.RaceName)
        {
            'Dragonborn' 
            {
                $updates = $abilityScores
                $updates[0] += 2
                $updates[5] += 1
                $this.RaceLanguages = "Common,Draconic"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Elf, High'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[3] += 1
                $this.RaceLanguages = "Common,Elven"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Elf, Wood'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[4] += 1
                $this.RaceLanguages = "Common,Elven"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Dwarf, Hill'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[4] += 1
                $this.RaceLanguages = "Common,Dwarvish"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Dwarf, Mountain'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[0] += 2
                $this.RaceLanguages = "Common,Dwarvish"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Gnome, Forest'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[1] += 1
                $this.RaceLanguages = "Common,Gnomish"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Gnome, Rock'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[2] += 1
                $this.RaceLanguages = "Common,Gnomish"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Halfling, Lightfoot'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[5] += 1
                $this.RaceLanguages = "Common,Halfling"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            'Halfling, stout'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[2] += 1
                $this.RaceLanguages = "Common,Halfling"
                $this.RaceSpeed = "25 ft"
                $this.RaceSize = "Small"
                $this.RaceSenses += "Darkvision 60 ft"
            }
            Default 
            {
                foreach($i in $abilityScores)
                {
                    $updates.Add($i + 1)
                }
                $this.RaceLanguages = "Common,Elven"
            }
        }
        return $updates
    }
}

class NPCXML
{
    [xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<root version="4" dataversion="20200528" release="8|CoreRPG:4">
</root>  
"@

    [Abilities] $NPCAbilities

    [Race] $NPCRace

    [ClassType] $NPCClass

    [string] $NPCType

    [string] $NPCName

    [string] $CategoryName

    NPCXML($Abilities, $Class, $Race, $Type, $Name)
    {
        $this.NPCAbilities = $Abilities
        $this.NPCClass = $Class
        $this.NPCRace = $Race
        $this.NPCName = $Name
        $this.NPCType = $Type
    }

    [void] SaveNPC()
    {
        $npcNodeElement =  $this.XMLFile.CreateElement("npc")
        $npcRootElement = $this.XMLFile.CreateElement("category")
        $NpcRootName = $this.XMLFile.CreateElement("$($this.NPCName.ToLower().Replace(' ',''))")

        $this.XMLFile.root.AppendChild($npcNodeElement)
        $npcNodeElement.AppendChild($npcRootElement).SetAttribute("name",$this.CategoryName)
        $npcRootElement.AppendChild($NpcRootName)
        $this.CreateNPCRoots($NpcRootName)
        $this.XMLFile.Save("C:\users\wfischbeck\OneDrive - Luxco\Desktop\$($this.NPCName).xml")
    }

    [void] CreateNPCRoots($npcRootElement)
    {
        $abilityRootElement = $this.XMLFile.CreateElement("abilities")
        $acRootElement  = $this.XMLFile.CreateElement("ac")
        $acTextElement = $this.XMLFile.CreateElement("actext")
        $acActionElement = $this.XMLFile.CreateElement("actions")
        $alignmentElement = $this.XMLFile.CreateElement("alignment")
        $crElement = $this.XMLFile.CreateElement("cr")
        $hdElement = $this.XMLFile.CreateElement("hd")
        $hpElement = $this.XMLFile.CreateElement("hp")
        $innateSpellsElement = $this.XMLFile.CreateElement("innatespells")
        $isIdentifiedElement = $this.XMLFile.CreateElement("isidentified")
        $lairactionsElement = $this.XMLFile.CreateElement("lairactions")
        $languageElement = $this.XMLFile.CreateElement("languages")
        $lendaryactionsElement = $this.XMLFile.CreateElement("lendaryactions")
        $lockedElement = $this.XMLFile.CreateElement("locked")
        $nameElement = $this.XMLFile.CreateElement("name")
        $nonid_nameElement = $this.XMLFile.CreateElement("nonid_name")
        $reactionsElement = $this.XMLFile.CreateElement("reactions")
        $savingthrowsElement = $this.XMLFile.CreateElement("savingthrows")
        $sensesElement = $this.XMLFile.CreateElement("senses")
        $sizeElement = $this.XMLFile.CreateElement("size")
        $skillsElement = $this.XMLFile.CreateElement("skillsElement")
        $speedElement = $this.XMLFile.CreateElement("speed")
        $spellsElement = $this.XMLFile.CreateElement("spells")
        $spellSlotElement = $this.XMLFile.CreateElement("spellslots")
        $textElement = $this.XMLFile.CreateElement("text")
        $tokenElement = $this.XMLFile.CreateElement("token")
        $traitsElement= $this.XMLFile.CreateElement("traits")
        $typeElement = $this.XMLFile.CreateElement("type")
        $xpElement = $this.XMLFile.CreateElement("xp")
        $charismaElement = $this.XMLFile.CreateElement("charisma")
        $charismabonusElement = $this.XMLFile.CreateElement("bonus")
        $charismascoreElement = $this.XMLFile.CreateElement("score")
        $constitutionElement = $this.XMLFile.CreateElement("constitution")
        $constitutionbonusElement = $this.XMLFile.CreateElement("bonus")
        $constitutionscoreElement = $this.XMLFile.CreateElement("score")
        $dexterityElement = $this.XMLFile.CreateElement("dexterity")
        $dexteritybonusElement = $this.XMLFile.CreateElement("bonus")
        $dexterityscoreElement = $this.XMLFile.CreateElement("score")
        $intelligenceElement = $this.XMLFile.CreateElement("intelligence")
        $intelligencebonusElement = $this.XMLFile.CreateElement("bonus")
        $intelligencescoreElement = $this.XMLFile.CreateElement("score")
        $strengthElement = $this.XMLFile.CreateElement("strength")
        $strengthbonusElement = $this.XMLFile.CreateElement("bonus")
        $strengthscoreElement = $this.XMLFile.CreateElement("score")
        $wisdomElement = $this.XMLFile.CreateElement("wisdom")
        $wisdombonusElement = $this.XMLFile.CreateElement("bonus")
        $wisdomscoreElement = $this.XMLFile.CreateElement("score")
        
        $npcRootElement.AppendChild($abilityRootElement)
        $abilityRootElement.AppendChild($charismaElement)
            $charismaElement.AppendChild($charismascoreElement).SetAttribute("type","number")
            $charismaElement.AppendChild($charismabonusElement).SetAttribute("type","number")
                $charismabonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[5])
                $charismascoreElement.InnerXml = $this.NPCAbilities.AbilityScores[5]
        $abilityRootElement.AppendChild($constitutionElement)
            $constitutionElement.AppendChild($constitutionbonusElement).SetAttribute("type","number")
            $constitutionElement.AppendChild($constitutionscoreElement).SetAttribute("type","number")
                $constitutionbonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[2])
                $constitutionscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[2]
        $abilityRootElement.AppendChild($dexterityElement)
            $dexterityElement.AppendChild($dexteritybonusElement).SetAttribute("type","number")
            $dexterityElement.AppendChild($dexterityscoreElement).SetAttribute("type","number")
                $dexteritybonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[1])
                $dexterityscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[1]
        $abilityRootElement.AppendChild($intelligenceElement)
            $intelligenceElement.AppendChild($intelligencebonusElement).SetAttribute("type","number")
            $intelligenceElement.AppendChild($intelligencescoreElement).SetAttribute("type","number")
                $intelligencebonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[3])
                $intelligencescoreElement.InnerXml = $this.NPCAbilities.AbilityScores[3]
        $abilityRootElement.AppendChild($strengthElement)
            $strengthElement.AppendChild($strengthbonusElement).SetAttribute("type","number")
            $strengthElement.AppendChild($strengthscoreElement).SetAttribute("type","number")
                $strengthbonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[0])
                $strengthscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[0]
        $abilityRootElement.AppendChild($wisdomElement)
            $wisdomElement.AppendChild($wisdombonusElement).SetAttribute("type","number")
            $wisdomElement.AppendChild($wisdomscoreElement).SetAttribute("type","number")
                $wisdombonusElement.InnerXml = $this.NPCAbilities.Modifier($this.NPCAbilities.AbilityScores[4])
                $wisdomscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[4]
        $npcRootElement.AppendChild($acRootElement).SetAttribute("type","number")
            $acRootElement.InnerXml = 0
        $npcRootElement.AppendChild($acTextElement).SetAttribute("type","string")
            $acTextElement.InnerXml = 0
        $npcRootElement.AppendChild($alignmentElement).SetAttribute("type","string")
            $alignmentElement.InnerXml = $this.NPCClass.NPCAlignment
        $npcRootElement.AppendChild($crElement).SetAttribute("type","string")
            $crElement.InnerXml = $this.NPCClass.ChallengeRating
        $npcRootElement.AppendChild($hdElement).SetAttribute("type","string")
            $hdElement.InnerXml = $this.NPCClass.ClassHitDice
        $npcRootElement.AppendChild($hpElement).SetAttribute("type","number")
            $hpElement.InnerXml = $this.NPCClass.HitPoints
        $npcRootElement.AppendChild($innateSpellsElement)
        $npcRootElement.AppendChild($isIdentifiedElement).SetAttribute("type","number")
            $isIdentifiedElement.InnerXml = 0
        $npcRootElement.AppendChild($lairactionsElement)
        $npcRootElement.AppendChild($languageElement).SetAttribute("type","string")
            $languageElement.InnerXml = "$($this.NPCRace.RaceLanguages)"
        $npcRootElement.AppendChild($lendaryactionsElement)
        $npcRootElement.AppendChild($lockedElement).SetAttribute("type","number")
            $lockedElement.InnerXml = 1
        $npcRootElement.AppendChild($nameElement).SetAttribute("type","string")
            $nameElement.InnerXml = $this.NPCName
        $npcRootElement.AppendChild($nonid_nameElement).SetAttribute("type","string")
            $nonid_nameElement.InnerXml = "$($this.NPCRace.RaceName.Split(',')[0]) $($this.NPCType)"
        $npcRootElement.AppendChild($reactionsElement)
        $npcRootElement.AppendChild($savingthrowsElement).SetAttribute("type","string")
            $savingthrowsElement.InnerXml = $this.NPCClass.ClassSavingThrows
        $npcRootElement.AppendChild($sensesElement).SetAttribute("type","string")
            $sensesElement.InnerXml = "$($this.NPCRace.RaceSenses), $($this.NPCClass.Senses)"
        $npcRootElement.AppendChild($sizeElement).SetAttribute("type","string")
            $sizeElement.InnerXML = $this.NPCRace.NPCSize
        $npcRootElement.AppendChild($skillsElement).SetAttribute("type","string")
            $skillsElement.InnerXml = $this.NPCClass.ClassSkills
        $npcRootElement.AppendChild($speedElement).SetAttribute("type","string")
            $speedElement.InnerXml = $this.NPCRace.NPCSpeed
        $npcRootElement.AppendChild($spellsElement)
        $npcRootElement.AppendChild($textElement).SetAttribute("type","formattedtext")
        $npcRootElement.AppendChild($tokenElement).SetAttribute("type","token")
        $npcRootElement.AppendChild($traitsElement)
        $npcRootElement.AppendChild($typeElement).SetAttribute("type","string")
            $typeElement.InnerXml = $this.NPCRace.NPCRace
        $npcRootElement.AppendChild($xpElement).SetAttribute("type","number")
            $xpElement.InnerXml = 0


    }
}