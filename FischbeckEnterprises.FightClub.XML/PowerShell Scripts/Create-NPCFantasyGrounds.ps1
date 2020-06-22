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
        $this.NPCClass.NPCConstitutionModifier = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2])
        $this.NPCClass.NPCAbilities = $this.NPCAbilities
        $this.NPCClass.NPCType = $this.NPCType
    }

    AddLevel($Level)
    {
        $this.NPCClass.ClassHitDie($this.NPCType)
        $this.NPCClass.AddClassLevel($Level)
        $count = 0
        switch($level)
        {
            {$_ -in "4","5","6", "7"} 
            {
                $count = 1
            }
            {$_ -in "8","9","10", "11"} 
            {
                $count = 2
            }
            {$_ -in "12","13","14", "15"} 
            {
                $count = 3
            }
            {$_ -in "16","17","18"} 
            {
                $count = 4
            }
            "19"
            {
                $count = 5
            }

        }

        While ($count -gt 0)
        {
            switch ($this.NPCType)
            {
                "Non-Combat"
                {
                    $this.NPCAbilities.AbilityScores[0] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[0])
                }
                "Barbarian"
                {
                    $this.NPCAbilities.AbilityScores[2] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[2])
                }
                "Bard"
                {
                    $this.NPCAbilities.AbilityScores[5] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[5])
                }
                "Cleric"
                {
                    $this.NPCAbilities.AbilityScores[4] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[4])
                }
                "Druid"
                {
                    $this.NPCAbilities.AbilityScores[4] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[4])
                }
                "Fighter"
                {
                    $this.NPCAbilities.AbilityScores[0] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[0])
                }
                "Monk"
                {
                    $this.NPCAbilities.AbilityScores[4] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[4])
                }
                "Paladin"
                {
                    $this.NPCAbilities.AbilityScores[5] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[5])
                }
                "Ranger"
                {
                    $this.NPCAbilities.AbilityScores[4] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[4])
                }
                "Rouge"
                {
                    $this.NPCAbilities.AbilityScores[1] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[1])
                }
                "Sorcerer"
                {
                    $this.NPCAbilities.AbilityScores[5] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[5])
                }
                "Warlock"
                {
                    $this.NPCAbilities.AbilityScores[5] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[5])
                }
                "Wizard"
                {
                    $this.NPCAbilities.AbilityScores[3] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[3])
                }
                default 
                {
                    $this.NPCAbilities.AbilityScores[0] = $this.NPCAbilities.IncreaseSingleAbilityScore($this.NPCAbilities.AbilityScores[0])
                }
            }
            $count--
        } 

    }

    Save()
    {
        [NPCXML] $xml = [NPCXML]::new($this.NPCAbilities, $this.NPCClass, $this.NPCRace, $this.NPCType, $this.NPCName)
        $xml.CategoryName = "The First Adventurers"
        $xml.SaveNPC()
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

    [string] $NPCSpeed = "30 ft"

    [string] $NPCSize = "Medium"

    [string] $NPCSenses = ""

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
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Elf, High'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[3] += 1
                $this.NPCRaceLanguages="Common,Elven"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Elf, Wood'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[4] += 1
                $this.NPCRaceLanguages="Common,Elven"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Dwarf, Hill'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[4] += 1
                $this.NPCRaceLanguages="Common,Dwarvish"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Dwarf, Mountain'
            {
                $updates = $abilityScores
                $updates[2] += 2
                $updates[0] += 2
                $this.NPCRaceLanguages="Common,Dwarvish"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Gnome, Forest'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[1] += 1
                $this.NPCRaceLanguages="Common,Gnomish"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Gnome, Rock'
            {
                $updates = $abilityScores
                $updates[3] += 2
                $updates[2] += 1
                $this.NPCRaceLanguages="Common,Gnomish"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Halfling, Lightfoot'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[5] += 1
                $this.NPCRaceLanguages="Common,Halfling"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
            }
            'Halfling, stout'
            {
                $updates = $abilityScores
                $updates[1] += 2
                $updates[2] += 1
                $this.NPCRaceLanguages="Common,Halfling"
                $this.NPCSpeed = "25 ft"
                $this.NPCSize = "Small"
                $this.NPCSenses = "Darkvision 60 ft"
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
    
    [NPCAbilities] $NPCAbilities

    [int] $CRRating

    [string] $NPCSenses

    [string] $NPCAlignment

    [string] $NPCSkills

    [ValidateSet("Non-Combat", "Barbarian","Bard","Cleric","Druid","Fighter","Monk","Paladin","Ranger","Rouge","Sorcerer","Warlock","Wizard")]
    [string] $NPCType

    [void] AddClassLevel([int] $Level)
    {
        $this.CRRating = $Level
        $this.NPCAlignment = $this.RandomAlignment()
        $this.HitDice = "$($Level)D$($this.NPCHD) + $(($Level * $this.NPCConstitutionModifier))"
        $this.NPCHP = ($this.RollDice($this.NPCHD, $Level) + ($Level * $this.NPCConstitutionModifier))
        $this.ClassSavingThrows($Level)
        $this.NPCSenses = "passive Perception $(10 + $this.GetProficiencyBonus($Level) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
        Write-Host -ForegroundColor Cyan "HD: $($this.HitDice) HP: $($this.NPCHP)`n$($this.NPCSavingThrows)"
    }

    [void] ClassHitDie($npcType)
    {
        switch ($npcType)
        {
            "Non-Combat" 
            { 
                $this.NPCHD = '4'
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Barbarian" 
            { 
                $this.NPCHD = '12'
                $this.NPCSkills = "$( $this.NPCSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Intimidation +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]))"
            }
            "Bard" 
            { 
                $this.NPCHD = '6'
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Cleric" 
            { 
                $this.NPCHD = '8'
                $this.NPCSkills = "$( $this.NPCSkills) Religon +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Druid" 
            { 
                $this.NPCHD = '8'
                $this.NPCSkills = "$( $this.NPCSkills) Nature +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Fighter" 
            { 
                $this.NPCHD = '10'
                $this.NPCSkills = "$( $this.NPCSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Acrobatics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Monk" 
            { 
                $this.NPCHD = '8' 
                $this.NPCSkills = "$( $this.NPCSkills) Athletics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Acrobatics +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Paladin" 
            { 
                $this.NPCHD = '10' 
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
            }
            "Ranger" 
            { 
                $this.NPCHD = '10' 
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Survival +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
            }
            "Rouge" 
            { 
                $this.NPCHD = '8' 
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , Stealth +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]))"
            }
            "Sorcerer" 
            { 
                $this.NPCHD = '6' 
                $this.NPCSkills = "$( $this.NPCSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Warlock" 
            { 
                $this.NPCHD = '6' 
                $this.NPCSkills = "$( $this.NPCSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            "Wizard" 
            { 
                $this.NPCHD = '6' 
                $this.NPCSkills = "$( $this.NPCSkills) Arcana +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]))"
            }
            Default 
            { 
                $this.NPCSkills = "$( $this.NPCSkills) Perception +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
                $this.NPCSkills = "$( $this.NPCSkills) , History +$($this.GetProficiencyBonus($this.CRRating) + $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]))"
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

    [int] GetProficiencyBonus ([int] $level)
    {
        switch ($level)
        {
            {$_ -in '1','2','3','4'} {return 2}
            {$_ -in '5','6','7','8'} {return 3}
            {$_ -in '9','10','11','12'} {return 4}
            {$_ -in '13','14','15','16'} {return 5}
            {$_ -in '17','18','19','20'} {return 6}
            Default {return 2}
        }
        return 0
    }

    [void] ClassSavingThrows($Level)
    {
        switch ($this.NPCType)
        {
            "Non-Combat" 
            { 
                $this.NPCSavingThrows = "Dex +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]) + $this.GetProficiencyBonus($Level)), Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level))"
            }
            "Barbarian" 
            { 
                $this.NPCSavingThrows = "Str +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]) + $this.GetProficiencyBonus($Level)), Con +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2]) + $this.GetProficiencyBonus($Level))"
            }
            "Bard" 
            { 
                $this.NPCSavingThrows = "Dex +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]) + $this.GetProficiencyBonus($Level)), Cha +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]) + $this.GetProficiencyBonus($Level))"
            }
            "Cleric" 
            { 
                $this.NPCSavingThrows = "Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level)), Cha +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]) + $this.GetProficiencyBonus($Level))"
            }
            "Druid" 
            { 
                $this.NPCSavingThrows = "Int +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]) + $this.GetProficiencyBonus($Level)), Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level))"
            }
            "Fighter" 
            { 
                $this.NPCSavingThrows = "Str +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]) + $this.GetProficiencyBonus($Level)), Con +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2]) + $this.GetProficiencyBonus($Level))"
            }
            "Monk" 
            { 
                $this.NPCSavingThrows = "Str +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]) + $this.GetProficiencyBonus($Level)), Dex +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]) + $this.GetProficiencyBonus($Level))"
            }
            "Paladin" 
            { 
                $this.NPCSavingThrows = "Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level)), cha +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]) + $this.GetProficiencyBonus($Level))"
            }
            "Ranger" 
            { 
                $this.NPCSavingThrows = "Str +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0]) + $this.GetProficiencyBonus($Level)), Dex +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]) + $this.GetProficiencyBonus($Level))"
            }
            "Rouge" 
            { 
                $this.NPCSavingThrows = "Dex +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1]) + $this.GetProficiencyBonus($Level)), Int +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]) + $this.GetProficiencyBonus($Level))"
            }
            "Sorcerer" 
            { 
                $this.NPCSavingThrows = "Con +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2]) + $this.GetProficiencyBonus($Level)), Cha +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]) + $this.GetProficiencyBonus($Level))"
            }
            "Warlock" 
            { 
                $this.NPCSavingThrows = "Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level)), Cha +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5]) + $this.GetProficiencyBonus($Level))"
            }
            "Wizard" 
            { 
                $this.NPCSavingThrows = "Int +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]) + $this.GetProficiencyBonus($Level)), Wis +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level))"
            }
            Default 
            { 
                $this.NPCSavingThrows = "Int +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3]) + $this.GetProficiencyBonus($Level)), WIS +$($this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4]) + $this.GetProficiencyBonus($Level))"
            }
        }
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
}

class NPCXML
{
    [xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<root version="4" dataversion="20200528" release="8|CoreRPG:4">
</root>  
"@

    [NPCAbilities] $NPCAbilities

    [NPCRace] $NPCRace

    [NPCCLass] $NPCClass

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
                $charismabonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[5])
                $charismascoreElement.InnerXml = $this.NPCAbilities.AbilityScores[5]
        $abilityRootElement.AppendChild($constitutionElement)
            $constitutionElement.AppendChild($constitutionbonusElement).SetAttribute("type","number")
            $constitutionElement.AppendChild($constitutionscoreElement).SetAttribute("type","number")
                $constitutionbonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[2])
                $constitutionscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[2]
        $abilityRootElement.AppendChild($dexterityElement)
            $dexterityElement.AppendChild($dexteritybonusElement).SetAttribute("type","number")
            $dexterityElement.AppendChild($dexterityscoreElement).SetAttribute("type","number")
                $dexteritybonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[1])
                $dexterityscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[1]
        $abilityRootElement.AppendChild($intelligenceElement)
            $intelligenceElement.AppendChild($intelligencebonusElement).SetAttribute("type","number")
            $intelligenceElement.AppendChild($intelligencescoreElement).SetAttribute("type","number")
                $intelligencebonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[3])
                $intelligencescoreElement.InnerXml = $this.NPCAbilities.AbilityScores[3]
        $abilityRootElement.AppendChild($strengthElement)
            $strengthElement.AppendChild($strengthbonusElement).SetAttribute("type","number")
            $strengthElement.AppendChild($strengthscoreElement).SetAttribute("type","number")
                $strengthbonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[0])
                $strengthscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[0]
        $abilityRootElement.AppendChild($wisdomElement)
            $wisdomElement.AppendChild($wisdombonusElement).SetAttribute("type","number")
            $wisdomElement.AppendChild($wisdomscoreElement).SetAttribute("type","number")
                $wisdombonusElement.InnerXml = $this.NPCAbilities.AssignModifier($this.NPCAbilities.AbilityScores[4])
                $wisdomscoreElement.InnerXml = $this.NPCAbilities.AbilityScores[4]
        $npcRootElement.AppendChild($acRootElement).SetAttribute("type","number")
            $acRootElement.InnerXml = 0
        $npcRootElement.AppendChild($acTextElement).SetAttribute("type","string")
            $acTextElement.InnerXml = 0
        $npcRootElement.AppendChild($alignmentElement).SetAttribute("type","string")
            $alignmentElement.InnerXml = $this.NPCClass.NPCAlignment
        $npcRootElement.AppendChild($crElement).SetAttribute("type","string")
            $crElement.InnerXml = $this.NPCClass.CRRating
        $npcRootElement.AppendChild($hdElement).SetAttribute("type","string")
            $hdElement.InnerXml = $this.NPCClass.HitDice
        $npcRootElement.AppendChild($hpElement).SetAttribute("type","number")
            $hpElement.InnerXml = $this.NPCClass.NPCHP
        $npcRootElement.AppendChild($innateSpellsElement)
        $npcRootElement.AppendChild($isIdentifiedElement).SetAttribute("type","number")
            $isIdentifiedElement.InnerXml = 0
        $npcRootElement.AppendChild($lairactionsElement)
        $npcRootElement.AppendChild($languageElement).SetAttribute("type","string")
            $languageElement.InnerXml = "$($this.NPCRace.NPCRaceLanguages)"
        $npcRootElement.AppendChild($lendaryactionsElement)
        $npcRootElement.AppendChild($lockedElement).SetAttribute("type","number")
            $lockedElement.InnerXml = 1
        $npcRootElement.AppendChild($nameElement).SetAttribute("type","string")
            $nameElement.InnerXml = $this.NPCName
        $npcRootElement.AppendChild($nonid_nameElement).SetAttribute("type","string")
            $nonid_nameElement.InnerXml = "$($this.NPCRace.NPCRace.Split(',')[0]) $($this.NPCType)"
        $npcRootElement.AppendChild($reactionsElement)
        $npcRootElement.AppendChild($savingthrowsElement).SetAttribute("type","string")
            $savingthrowsElement.InnerXml = $this.NPCClass.NPCSavingThrows
        $npcRootElement.AppendChild($sensesElement).SetAttribute("type","string")
            $sensesElement.InnerXml = "$($this.NPCRace.NPCSenses), $($this.NPCClass.NPCSenses)"
        $npcRootElement.AppendChild($sizeElement).SetAttribute("type","string")
            $sizeElement.InnerXML = $this.NPCRace.NPCSize
        $npcRootElement.AppendChild($skillsElement).SetAttribute("type","string")
            $skillsElement.InnerXml = $this.NPCClass.NPCSkills
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

[NPC] $nPC = [NPC]::new("Non-Combat", "human")
$npc.NPCName = "Gealin Nigh"
$nPC.AddLevel(5)
$nPC.Save()