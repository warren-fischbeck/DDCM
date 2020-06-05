
[xml]$xmlFile = @"
<?xml version="1.0" encoding="ISO-8859-1"?>
<root version="3.1">
<reference static="true">
</reference>
</root>
"@

[xml] $FightClubData = Get-Content -Path 'C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\_Complete.xml' -Encoding UTF8
$SpellData = $FightClubData.compendium.spell
$Asterik = '[*]$'
$Parenthesis = '[)]$'
$Bracket = '[\]]$'
$spellNumber = 1

$newSpellDataElement = $xmlFile.CreateElement("spelldata")
$XMLSpellData = $xmlFile.root.reference.AppendChild($newSpellDataElement)


foreach($Spell in $SpellData)
{
    $MoveSpell = $false

    if((($Spell.name.ToString()) -notmatch $Asterik) -AND 
        (($Spell.name.ToString()) -notmatch $Parenthesis) -AND 
        (($Spell.name.ToString()) -notmatch $Bracket))
    {
        #Write-host -ForegroundColor Cyan "$($Spell.name)"
        $MoveSpell = $true
        if(($Spell.name -match "Invocation: ") -or
        ($Spell.classes -match "Fighter \("))
        {
            $MoveSpell = $false
        }
        foreach($Text in $Spell.text)
        {
            if(($Text -match "Source: Player's Handbook,") -OR 
                ($Text -match "Source: Xanathar's Guide to Everything,") -OR
                ($Text -match "Source: Sword Coast Adventurer's Guide,"))
            {
                $MoveSpell = $false
            }
        }
    }

    if($MoveSpell)
    {
        Write-host -ForegroundColor Yellow "$($Spell.name)"
        $sText = ""
        $shtext = ""
        foreach($t in $Spell.text)
        {
            $sText +="<p>$($t)</p>"
            $shtext += $t
        }
        $sText = $sText.Replace("`n","").Replace("`r","")
        $shtext = $shtext.Replace("`n","").Replace("`r","").Replace("      ","").split('.')[0]
        $name = $Spell.name.Replace(' ','').Replace("'", '')
        $school = switch ($Spell.school)
        {
            'A' {"Abjuration"}
            "EV" {"Evocation"}
            "C" {"Conjuration"}
            "EN" {"Enchantment"}
            "I" {"Illusion"}
            "D" {"Divination"}
            "N" {"Necromancy"}
            "T" {"Transmutation"}
            Default {""}
        }
        $SpellID = "id-$(($spellNumber.ToString()).PadLeft(5,'0'))"

        $classes = ""
        foreach($class in ($Spell.classes.Split(',').Trim() | sort ))
        {
            if(($class -notmatch '\(') -AND 
            ($class -notmatch "Superior") -AND
            ($class -notmatch "Martial"))
            {
                if($classes.Length -gt 0)
                {
                    $classes += ", $($class.Trim())"
                }
                else
                {
                    $classes = $class.Trim()
                }
            }
            elseif(($class -match "Wizard") -or
                ($class -match "Fighter"))
            {
                $class = $class.Substring(0,$class.IndexOf("(")-1).Replace(" ",'')

                if($classes -notmatch $class)
                {
                    if($classes.Length -gt 0)
                    {
                        $classes += ", $($class)"
                    }
                    else
                    {
                        $classes = $class
                    }
                }
            }
        }
        
        $newNameAttribute = $xmlFile.CreateAttribute("type")
        $newNameAttribute.InnerXml = "string"
                
        $newDescriptionAttribute = $xmlFile.CreateAttribute("type")
        $newDescriptionAttribute.InnerXml = "formattedtext"

        $newLevelattribute = $xmlFile.CreateAttribute("type")
        $newLevelattribute.InnerXml = "number"
        
        $newSchoolAttribute = $xmlFile.CreateAttribute("type")
        $newSchoolAttribute.InnerXml = "string"

        $newSourceAttribute = $xmlFile.CreateAttribute("type")
        $newSourceAttribute.InnerXml = "string"
        
        $newCastingTimeAttribute = $xmlFile.CreateAttribute("type")
        $newCastingTimeAttribute.InnerXml = "string"

        $newRangeAttribute = $xmlFile.CreateAttribute("type")
        $newRangeAttribute.InnerXml = "string"

        $newDurationAttribute = $xmlFile.CreateAttribute("type")
        $newDurationAttribute.InnerXml = "string"

        $newCompontentsAttribute = $xmlFile.CreateAttribute("type")
        $newCompontentsAttribute.InnerXml = "string"

        $newShortDescritionAttribute = $xmlFile.CreateAttribute("type")
        $newShortDescritionAttribute.InnerXml = "string"

        $newSpellElement = $xmlFile.CreateElement($SpellID)
        
        $newSpell = $XMLSpellData.AppendChild($newSpellElement)  
            
            $newSpellName = $xmlFile.CreateElement("name")
                $newSpellName.InnerXml = "$($name)"
                $newSpellName.Attributes.Append($newNameAttribute) | Out-Null
                $newSpell.AppendChild($newSpellName) | Out-Null

            $newSpellDescription = $xmlFile.CreateElement("description")
                $newSpellDescription.Attributes.Append($newDescriptionAttribute) | Out-Null
                $newSpellDescription.InnerXml = $sText
                $newSpell.AppendChild($newSpellDescription) | Out-Null

            $newSpellShortDescription = $xmlFile.CreateElement("shortdescription")
                $newSpellShortDescription.Attributes.Append($newShortDescritionAttribute) | Out-Null
                $newSpellShortDescription.InnerXml = $shtext
                $newSpell.AppendChild($newSpellShortDescription) | Out-Null

            $newSpellLevel = $xmlFile.CreateElement("level")
                $newSpellLevel.Attributes.Append($newLevelattribute) | Out-Null
                $newSpellLevel.InnerXml = $Spell.level
                $newSpell.AppendChild($newSpellLevel) | Out-Null

            $newSpellSchool = $xmlFile.CreateElement("school")
                $newSpellSchool.Attributes.Append($newSchoolAttribute) | Out-Null
                $newSpellSchool.InnerXml = $school
                $newSpell.AppendChild($newSpellSchool) | Out-Null  

            $newSpellSource = $xmlFile.CreateElement("source")
                $newSpellSource.Attributes.Append($newSourceAttribute) | Out-Null
                $newSpellSource.InnerXml = $classes | sort
                $newSpell.AppendChild($newSpellSource) | Out-Null 

            $newSpellCastingTime = $xmlFile.CreateElement("castingtime")
                $newSpellCastingTime.Attributes.Append($newCastingTimeAttribute) | Out-Null
                $newSpellCastingTime.InnerXml = $Spell.time
                $newSpell.AppendChild($newSpellCastingTime) | Out-Null  

            $newSpellRange = $xmlFile.CreateElement("range")
                $newSpellRange.Attributes.Append($newRangeAttribute) | Out-Null
                $newSpellRange.InnerXml = $Spell.range
                $newSpell.AppendChild($newSpellRange) | Out-Null  

            $newSpellDuration = $xmlFile.CreateElement("duration")
                $newSpellDuration.Attributes.Append($newDurationAttribute) | Out-Null
                $newSpellDuration.InnerXml = $Spell.duration
                $newSpell.AppendChild($newSpellDuration) | Out-Null  

            $newSpellComponents = $xmlFile.CreateElement("components")
                $newSpellComponents.Attributes.Append($newCompontentsAttribute) | Out-Null
                $newSpellComponents.InnerXml = $Spell.components
                $newSpell.AppendChild($newSpellComponents) | Out-Null  
        
        $spellNumber ++
    }
}


$xmlFile.Save( "$($env:OneDriveConsumer)\Documents\Dungeon & Dragons\World of Koreth\Fantasy_Grounds_Data\Spell.xml")