class NPC
{
    [NPCAbilities] $NPCAbilities

    [NPCRace] $NPCRace

    [NPCCLass] $NPCClass
    
    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $NPCType

    [string] $NPCName

    NPC($NPCType)
    {
        $this.NPCType = $NPCType
        $this.NPCRace = [NPCRace]::new()
        $this.BuildNPC()
    }

    NPC($NPCType, $NPCRace)
    {
        $this.NPCType = $NPCType
        $this.NPCRace = [NPCRace]::new($NPCRace)
        $this.BuildNPC()
    }

        NPC($NPCType, $NPCRace, $NPCName)
    {
        $this.NPCName = $NPCName
        $this.NPCType = $NPCType
        $this.NPCRace = [NPCRace]::new($NPCRace)
        $this.BuildNPC()
    }

    BuildNPC()
    {
        $this.NPCAbilities = [NPCAbilities]::new($this.NPCType)
        $this.NPCAbilities.AbilityScores = $this.NPCRace.RaceModifiers($this.NPCAbilities.AbilityScores)
        $this.NPCClass = [NPCCLass]::new()
        $this.NPCClass.ClassHitDie($this.NPCType)
        $this.NPCClass.NPCConstitutionModifier = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2])
    }
}

class NPCAbilities
{
    [int[]] $AbilityScores

    # Property with validate set
    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $NPCType


    NPCAbilities ([string] $NPCType)
    {
        $this.NPCType = $NPCType
        $this.AbilityScores = $this.RollAllAbilities()
        $this.AbilityScores = $this.AssignAbilities($this.NPCType)
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
                $abilityScore = $this.AbilityScores[3], $this.AbilityScores[5], $this.AbilityScores[2], $this.AbilityScores[1],$this.AbilityScores[0],$this.AbilityScores[4]
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

    [int] AssignModifier([int] $AbilityScore)
    {
        return ($AbilityScore - 10)/2
    }
}

class NPCRace
{
    [string] $NPCRace

    [string] $NPCRaceLanguages

    NPCRace()
    {
        $this.NPCRace = $this.RollRandomRace()
    }
    NPCRace($Race)
    {
        $this.NPCRace = $Race
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
        switch ($this.NPCRace)
        {
            'Dragonborn' 
            {
                $updates = $abilityScores
                $updates[0] += 2
                $updates[5] += 1
                $this.NPCRaceLanguages="Common,Draconic"
            }
            'Elf, High'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[3] += 1
                $this.NPCRaceLanguages="Common,Elven"
            }
            'Elf, Wood'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[4] += 1
                $this.NPCRaceLanguages="Common,Elven"
            }
            'Dwarf, Hill'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[4] += 1
                $this.NPCRaceLanguages="Common,Dwarvish"
            }
            'Dwarf, Mountain'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[0] += 2
                $this.NPCRaceLanguages="Common,Dwarvish"
            }
            'Gnome, Forest'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[1] += 1
                $this.NPCRaceLanguages="Common,Gnomish"
            }
            'Gnome, Rock'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[2] += 1
                $this.NPCRaceLanguages="Common,Gnomish"
            }
            'Halfling, Lightfoot'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[5] += 1
                $this.NPCRaceLanguages="Common,Halfling"
            }
            'Halfling, stout'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[2] += 1
                $this.NPCRaceLanguages="Common,Halfling"
            }
            Default 
            {
                foreach($i in $abilityScores)
                {
                    $updates.Add($i + 1)
                }
                $this.NPCRaceLanguages="Common,Elven"
            }
        }
        return $updates
    }
}

class NPCCLass
{

    [int] $NPCHD

    [string] $HitDice

    [int] $NPCHP

    [int] $NPCConstitutionModifier

    [string] $NPCSavingThrows

    [void] AddClassLevel([int] $Level)
    {
        $this.HitDice = "$($Level)D$($this.NPCHD) + $(($Level * $this.NPCConstitutionModifier))"
        $this.NPCHP = ($this.RollDice($this.NPCHD, $Level) + ($Level * $this.NPCConstitutionModifier))
        Write-Host -ForegroundColor Cyan "HD: $($this.HitDice) HP: $($this.NPCHP)"
    }

    [void] ClassHitDie($npcType)
    {
        switch ($npcType)
        {
            "Non-Combat" 
            { 
                $this.NPCHD = '4'
            }
            "Barbarian" 
            { 
                $this.NPCHD = '12'
            }
            "Bard" 
            { 
                $this.NPCHD = '6'
            }
            "Cleric" 
            { 
                $this.NPCHD = '8'
            }
            "Druid" 
            { 
                $this.NPCHD = '8'
            }
            "Fighter" 
            { 
                $this.NPCHD = '10'
            }
            "Monk" 
            { 
                $this.NPCHD = '8' 
            }
            "Paladin" 
            { 
                $this.NPCHD = '10' 
            }
            "Ranger" 
            { 
                $this.NPCHD = '10' 
            }
            "Rouge" 
            { 
                $this.NPCHD = '8' 
            }
            "Sorcerer" 
            { 
                $this.NPCHD = '6' 
            }
            "Warlock" 
            { 
                $this.NPCHD = '6' 
            }
            "Wizard" 
            { 
                $this.NPCHD = '6' 
            }
            Default 
            { 
                $this.NPCHD = '6' 
            }
        }
    }

    [int] RollDice([int] $dieSize, [int] $dieCount)
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
}

[NPC] $nPC = [NPC]::new("Barbarian", "Dwarf, Mountain")
Write-Host -ForegroundColor Cyan "$($nPC.NPCAbilities.AbilityScores)"
Write-Host -ForegroundColor Cyan "$($nPC.NPCRace.NPCRace) - $($nPC.NPCRace.NPCRaceLanguages)"
$nPC.NPCClass.AddClassLevel(14)