
[xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<root version="4" dataversion="20200528" release="8|CoreRPG:4">
</root>  
"@

# Define a class
class FantasyGroundsNpc
{

    # Property with validate set
    [ValidateSet("NonCombat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $NPCType

    [string] $NPCName

    [int[]] $AbilityScores

    [int[]] $ClassScores

    [int] $ClassLevel

    [string] $Armor = "none"

    [string] $ArmorClass = "10"

    [string] $Alignment = "Lawful Good"

    [string] $hd

    [string] $hp

    [string] $Race

    [string] $Language

    [string] $SavingThrows

    [string] $InnateSpells

    [string] $LairActions

    [string] $Reactions

    [string] $Senses = "passive Perception $($this.AssignModifier($this.ClassScores[4]) + 10)"

    [string] $Size = "Medium"



    # Constructor
    FantasyGroundsNpc ([string] $NPCType, [string] $NPCName, [int] $ClassLevel)
    {
        $this.NPCName = $NPCName
        $this.NPCType = $NPCType
        $this.ClassLevel = $ClassLevel
        $this.AbilityScores = $this.RollAbilities()
        $this.ClassScores = $this.AssignAbilities($this.NPCType)
        $this.alignment = $this.RandomAlignment()
        $this.RollHP()
        $this.Race = $this.RandomRace()
    }

    [int] RollAttributeScore ([int] $DieQuanty, [int] $DieSize)
    {
        [System.Collections.ArrayList] $result = @()
        for($i=0; $i -lt $DieQuanty; $i ++)
        {    
            $result.Add((Get-Random -Minimum 1 -Maximum $DieSize)) | Out-Null
        }
        $lowest = ($result | Measure-Object -Minimum).Minimum
        #Write-Host -ForegroundColor Cyan "($($lowest))[$($result)]"
        $Total = ($result | Measure-Object -Sum).Sum
        return ($Total - $lowest)
    }

    [string] RandomRace ()
    {
        switch ($this.RollDie(6))
        {
            '1' {$this.language="Common,Dwarvish"; return "Dwarf"}
            '2' {$this.language="Common,Elven"; return "Elf"}
            '3' {$this.language="Common,Halfling"; return "Halfling"}
            '4' {$this.language="Common,Gnomish"; return "Gnome"}
            '5' {$this.language="Common,Draconic"; return "Dragonborn"}
            Default {$this.language="Common,Elven"; return "Human"}
        }
        $this.language = "Common"
        return "Human"
    }

    [void] RollHP ()
    {
        switch ($this.NPCType)
        {
            "NonCombat" { $this.hd = "4"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Barbarian" { $this.hd = "12"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Bard" { $this.hd = "6"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Cleric" { $this.hd = "8"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Druid" { $this.hd = "8"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Fighter" { $this.hd = "10"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Monk" { $this.hd = "8"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Paladin" { $this.hd = "10"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Ranger" { $this.hd = "10"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Rouge" { $this.hd = "8"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Sorcerer" { $this.hd = "6"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Warlock" { $this.hd = "6"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            "Wizard" { $this.hd = "6"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
            Default { $this.hd = "6"; $this.hp = $this.RollDice($this.hd,$this.ClassLevel)}
        }
    }

    [int] RollDice ([int] $dieSize, [int] $dieCount)
    {
        [int] $total = 0

        for($i = 0; $i -lt $dieCount; $i ++)
        {
            $total += $this.RollDie($dieSize)
        }

        return $total
    }

    [int] RollDie ([int] $dieSize)
    {
        return (Get-Random -Minimum 1 -Maximum $dieSize)
    }

    [string]RandomAlignment()
    {
        switch ($this.RollDie(9))
        {
            '1' { return "Lawful Good"}
            '2' { return "Neutral Good" }
            '3' { return "Chaotic Good" }
            '4' { return "Lawful Neutral" }
            '5' { return "Neutral" }
            '6' { return "Chaotic Neutral" }
            '7' { return "Lawful Evil" }
            '8' { return "Neutral Evil" }
            Default {return "Chaotic Evil"}
        }
        return "Lawful Good"
    }

    [int[]] RollAbilities()
    {
        [System.Collections.ArrayList] $result = @()
        for($i=0; $i -lt 6; $i ++)
        {    
            $result.Add($this.RollAttributeScore(4,6))
        }
        if([math]::Floor($this.ClassLevel /4) -gt 0) 
        {
            $result = $result | sort -Descending
            $Bump = ([math]::Floor($this.ClassLevel /4))*2
            $result[0] += ($Bump)
        }
        return $result 
    }

    [int[]] AssignAbilities([string] $Type)
    {
        $abilityScore = @()
        switch ($Type)
        {
            "Barbarian" 
                {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[0], $this.ClassScores[2], $this.ClassScores[1], $this.ClassScores[5],$this.ClassScores[3],$this.ClassScores[4]
                }
            "Bard" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[5], $this.ClassScores[4], $this.ClassScores[3], $this.ClassScores[1],$this.ClassScores[2],$this.ClassScores[0]
            }
            "Cleric" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[3], $this.ClassScores[5], $this.ClassScores[2], $this.ClassScores[1],$this.ClassScores[0],$this.ClassScores[4]
            }
            "Druid" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[3], $this.ClassScores[5], $this.ClassScores[2], $this.ClassScores[1],$this.ClassScores[0],$this.ClassScores[4]
            }
            "Fighter" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[0], $this.ClassScores[2], $this.ClassScores[1], $this.ClassScores[5],$this.ClassScores[3],$this.ClassScores[4]
            }
            "Monk" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[0], $this.ClassScores[2], $this.ClassScores[1], $this.ClassScores[5],$this.ClassScores[3],$this.ClassScores[4]
            }
            "Paladin" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[1], $this.ClassScores[4], $this.ClassScores[2], $this.ClassScores[5],$this.ClassScores[3],$this.ClassScores[0]
            }
            "Ranger" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[3], $this.ClassScores[2], $this.ClassScores[1], $this.ClassScores[4],$this.ClassScores[0],$this.ClassScores[5]
            }
            "Rouge" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[2], $this.ClassScores[0], $this.ClassScores[1], $this.ClassScores[5],$this.ClassScores[3],$this.ClassScores[4]
            }
            "Sorcerer" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[5], $this.ClassScores[2], $this.ClassScores[4], $this.ClassScores[1],$this.ClassScores[3],$this.ClassScores[0]
            }
            "Warlock" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[5], $this.ClassScores[2], $this.ClassScores[4], $this.ClassScores[1],$this.ClassScores[3],$this.ClassScores[0]
            }
            "Wizard" 
            {
                    $this.ClassScores = $this.AbilityScores | sort -Descending
                    $abilityScore = $this.ClassScores[5], $this.ClassScores[4], $this.ClassScores[3], $this.ClassScores[0],$this.ClassScores[1],$this.ClassScores[2]
            }
            Default {$abilityScore = $this.AbilityScores}
        }
        return $abilityScore
    }

    [int] AssignModifier([int] $AbilityScore)
    {
        return ($AbilityScore - 10)/2
    }

    [void] SaveNPC($XMLFile)
    {
        $NpcRootName = $XMLFile.CreateElement("$($this.NPCName.Replace(' ',''))")
        $npcRootElement = $XMLFile.CreateElement("npc")
        $npcRootElement.AppendChild($NpcRootName)
        $XMLFile.root.AppendChild($npcRootElement)
        $this.CreateNpcXMLRoots($XMLFile, $NpcRootName)      

        $XMLFile.Save("C:\users\wfischbeck\OneDrive - Luxco\Desktop\$($this.NPCName).xml")
    }

    [void] CreateNpcXMLRoots ($xmlFile, $npcRootElement)
    {
        $abilityRootElement = $xmlFile.CreateElement("abilities")
        $acRootElement  = $xmlFile.CreateElement("ac")
        $acTextElement = $xmlFile.CreateElement("actext")
        $acActionElement = $xmlFile.CreateElement("actions")
        $alignmentElement = $xmlFile.CreateElement("alignment")
        $crElement = $xmlFile.CreateElement("cr")
        $hdElement = $xmlFile.CreateElement("hd")
        $hpElement = $xmlFile.CreateElement("hp")
        $innateSpellsElement = $xmlFile.CreateElement("innatespells")
        $isIdentifiedElement = $xmlFile.CreateElement("isidentified")
        $lairactionsElement = $xmlFile.CreateElement("lairactions")
        $languageElement = $xmlFile.CreateElement("languages")
        $lendaryactionsElement = $xmlFile.CreateElement("lendaryactions")
        $lockedElement = $xmlFile.CreateElement("locked")
        $nameElement = $xmlFile.CreateElement("name")
        $nonid_nameElement = $xmlFile.CreateElement("nonid_name")
        $reactionsElement = $xmlFile.CreateElement("reactions")
        $savingthrowsElement = $xmlFile.CreateElement("savingthrows")
        $sensesElement = $xmlFile.CreateElement("senses")
        $sizeElement = $xmlFile.CreateElement("size")
        $skillsElement = $xmlFile.CreateElement("skillsElement")
        $speedElement = $xmlFile.CreateElement("speed")
        $spellsElement = $xmlFile.CreateElement("spells")
        $spellSlotElement = $xmlFile.CreateElement("spellslots")
        $textElement = $xmlFile.CreateElement("text")
        $tokenElement = $xmlFile.CreateElement("token")
        $traitsElement= $xmlFile.CreateElement("traits")
        $typeElement = $xmlFile.CreateElement("type")
        $xpElement = $xmlFile.CreateElement("xp")
        $charismaElement = $xmlFile.CreateElement("charisma")
        $charismabonusElement = $xmlFile.CreateElement("bonus")
        $charismascoreElement = $xmlFile.CreateElement("score")
        $constitutionElement = $xmlFile.CreateElement("constitution")
        $constitutionbonusElement = $xmlFile.CreateElement("bonus")
        $constitutionscoreElement = $xmlFile.CreateElement("score")
        $dexterityElement = $xmlFile.CreateElement("dexterity")
        $dexteritybonusElement = $xmlFile.CreateElement("bonus")
        $dexterityscoreElement = $xmlFile.CreateElement("score")
        $intelligenceElement = $xmlFile.CreateElement("intelligence")
        $intelligencebonusElement = $xmlFile.CreateElement("bonus")
        $intelligencescoreElement = $xmlFile.CreateElement("score")
        $strengthElement = $xmlFile.CreateElement("strength")
        $strengthbonusElement = $xmlFile.CreateElement("bonus")
        $strengthscoreElement = $xmlFile.CreateElement("score")
        $wisdomElement = $xmlFile.CreateElement("wisdom")
        $wisdombonusElement = $xmlFile.CreateElement("bonus")
        $wisdomscoreElement = $xmlFile.CreateElement("score")


        $npcRootElement.AppendChild($abilityRootElement)
        $abilityRootElement.AppendChild($charismaElement)
            $charismaElement.AppendChild($charismascoreElement).SetAttribute("type","number")
            $charismaElement.AppendChild($charismabonusElement).SetAttribute("type","number")
                $charismabonusElement.InnerXml = $this.AssignModifier($this.ClassScores[5])
                $charismascoreElement.InnerXml = $this.ClassScores[5]
        $abilityRootElement.AppendChild($constitutionElement)
            $constitutionElement.AppendChild($constitutionbonusElement).SetAttribute("type","number")
            $constitutionElement.AppendChild($constitutionscoreElement).SetAttribute("type","number")
                $constitutionbonusElement.InnerXml = $this.AssignModifier($this.ClassScores[2])
                $constitutionscoreElement.InnerXml = $this.ClassScores[2]
        $abilityRootElement.AppendChild($dexterityElement)
            $dexterityElement.AppendChild($dexteritybonusElement).SetAttribute("type","number")
            $dexterityElement.AppendChild($dexterityscoreElement).SetAttribute("type","number")
                $dexteritybonusElement.InnerXml = $this.AssignModifier($this.ClassScores[1])
                $dexterityscoreElement.InnerXml = $this.ClassScores[1]
        $abilityRootElement.AppendChild($intelligenceElement)
            $intelligenceElement.AppendChild($intelligencebonusElement).SetAttribute("type","number")
            $intelligenceElement.AppendChild($intelligencescoreElement).SetAttribute("type","number")
                $intelligencebonusElement.InnerXml = $this.AssignModifier($this.ClassScores[3])
                $intelligencescoreElement.InnerXml = $this.ClassScores[3]
        $abilityRootElement.AppendChild($strengthElement)
            $strengthElement.AppendChild($strengthbonusElement).SetAttribute("type","number")
            $strengthElement.AppendChild($strengthscoreElement).SetAttribute("type","number")
                $strengthbonusElement.InnerXml = $this.AssignModifier($this.ClassScores[0])
                $strengthscoreElement.InnerXml = $this.ClassScores[0]
        $abilityRootElement.AppendChild($wisdomElement)
            $wisdomElement.AppendChild($wisdombonusElement).SetAttribute("type","number")
            $wisdomElement.AppendChild($wisdomscoreElement).SetAttribute("type","number")
                $wisdombonusElement.InnerXml = $this.AssignModifier($this.ClassScores[4])
                $wisdomscoreElement.InnerXml = $this.ClassScores[4]
        $npcRootElement.AppendChild($acRootElement).SetAttribute("type","number")
            $acRootElement.InnerXml = $this.armorclass
        $npcRootElement.AppendChild($acTextElement).SetAttribute("type","string")
            $acTextElement.InnerXml = $this.Armor
        $npcRootElement.AppendChild($alignmentElement).SetAttribute("type","string")
            $alignmentElement.InnerXml = $this.alignment
        $npcRootElement.AppendChild($crElement).SetAttribute("type","string")
            $crElement.InnerXml = $this.ClassLevel
        $npcRootElement.AppendChild($hdElement).SetAttribute("type","string")
            $hdElement.InnerXml = "($($this.ClassLevel)D$($this.hd) + $($this.ClassLevel * $this.AssignModifier($this.ClassScores[2])))"
        $npcRootElement.AppendChild($hpElement).SetAttribute("type","number")
            $hpElement.InnerXml = $this.hp
        $npcRootElement.AppendChild($innateSpellsElement)
        $npcRootElement.AppendChild($isIdentifiedElement).SetAttribute("type","number")
            $isIdentifiedElement.InnerXml = 0
        $npcRootElement.AppendChild($lairactionsElement)
        $npcRootElement.AppendChild($languageElement).SetAttribute("type","string")
            $languageElement.InnerXml = $this.language
        $npcRootElement.AppendChild($lendaryactionsElement)
        $npcRootElement.AppendChild($lockedElement).SetAttribute("type","number")
            $lockedElement.InnerXml = 1
        $npcRootElement.AppendChild($nameElement).SetAttribute("type","string")
            $nameElement.InnerXml=$this.NPCName
        $npcRootElement.AppendChild($nonid_nameElement).SetAttribute("type","string")
            $nonid_nameElement.InnerXml = "$($this.race) $($this.NPCType)"
        $npcRootElement.AppendChild($reactionsElement)
        $npcRootElement.AppendChild($savingthrowsElement).SetAttribute("type","string")
            $savingthrowsElement.InnerXml = $this.SavingThrows
        $npcRootElement.AppendChild($sensesElement).SetAttribute("type","string")
        $npcRootElement.AppendChild($sizeElement).SetAttribute("type","string")
            $sizeElement.InnerXML = "Medium"
        $npcRootElement.AppendChild($skillsElement).SetAttribute("type","string")
        $npcRootElement.AppendChild($speedElement).SetAttribute("type","string")
            $speedElement.InnerXml = "30 Ft"
        $npcRootElement.AppendChild($spellsElement)
        $npcRootElement.AppendChild($textElement).SetAttribute("type","formattedtext")
        $npcRootElement.AppendChild($tokenElement).SetAttribute("type","token")
        $npcRootElement.AppendChild($traitsElement)
        $npcRootElement.AppendChild($typeElement).SetAttribute("type","string")
            $typeElement.InnerXml = $this.race
        $npcRootElement.AppendChild($xpElement).SetAttribute("type","number")
            $xpElement.InnerXml = $this.ClassLevel * 100
    }
}

$test = [FantasyGroundsNpc]::new("NonCombat","Mary Nightgale", 1)
$test.AbilityScores
$test.SaveNPC($xmlFile)
