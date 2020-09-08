[xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5">
</compendium>  
"@

class Modifier
{
    [string] $Name

    [ValidateSet("melee attacks +1",
                 "melee attacks +2",
                 "melee attacks +3",
                 "melee damage +1",
                 "melee damage +2",
                 "melee damage +3",
                 "initiative +1",
                 "initiative +2",
                 "initiative +3",
                 "initiative +4",
                 "initiative +5",
                 "initiative +6",
                 "initiative +7",
                 "initiative +8",
                 "initiative +9",
                 "initiative +10",
                 "ac +1",
                 "ac +2",
                 "ac +3",
                 "ac +4",
                 "ac +5",
                 "spell attack +1",
                 "spell attack +2",
                 "spell attack +3",
                 "spell attack +4",
                 "spell attack +5",
                 "ranged attacks +1",
                 "ranged attacks +2",
                 "ranged attacks +3",
                 "ranged damage +1",
                 "ranged damage +2",
                 "ranged damage +3",
                 "saving throws +1",
                 "saving throws +2",
                 "saving throws +3",
                 "saving throws +4",
                 "saving throws +5",
                 "weapon attacks +1",
                 "weapon attacks +2",
                 "weapon attacks +3",
                 "weapon damage +1",
                 "weapon damage +2",
                 "weapon damage +3",
                 "speed -1",
                 "speed -2",
                 "speed -3",
                 "speed -4",
                 "speed -5",
                 "speed -6",
                 "speed -7",
                 "speed -8",
                 "speed -9",
                 "speed -10",
                 "speed +1",
                 "speed +2",
                 "speed +3",
                 "speed +4",
                 "speed +5",
                 "speed +6",
                 "speed +7",
                 "speed +8",
                 "speed +9",
                 "speed +10",
                 "arcana+%0",
                 "history+%0",
                 "spell dc +1",
                 "spell dc +2",
                 "spell dc +3",
                 "strength +1",
                 "strength +2",
                 "strength +3",
                 "strength +4",
                 "strength +5",
                 "dexterity +1",
                 "dexterity +2",
                 "dexterity +3",
                 "dexterity +4",
                 "dexterity +5",
                 "constitution +1",
                 "constitution +2",
                 "constitution +3",
                 "constitution +4",
                 "constitution +5",
                 "intelligence +1",
                 "intelligence +2",
                 "intelligence +3",
                 "intelligence +4",
                 "intelligence +5",
                 "wisdom +1",
                 "wisdom +2",
                 "wisdom +3",
                 "wisdom +4",
                 "wisdom +5",
                 "charisma +1",
                 "charisma +2",
                 "charisma +3",
                 "charisma +4",
                 "charisma +5",
                 "proficiency bonus +1",
                 "proficiency bonus +2",
                 "proficiency bonus +3",
                 "proficiency bonus +4",
                 "proficiency bonus +5",
                 "proficiency bonus +6",
                 "proficiency bonus +7",
                 "proficiency bonus +8",
                 "proficiency bonus +9",
                 "proficiency bonus +10"
                 )]
    [string[]] $Text

    [string] $Category
}

class ItemXML
{
    [string] $Name

    [ValidateSet("LA","MA","HA","S","M","R","A","RD","ST","WD","RG","P","SC","W","G","$")]
    [string] $Type

    [string] $Value

    [string] $Weight

    [string[]] $Text

    [string] $AC

    [string] $Strength

    [ValidateSet(1,0)]
    $Stealth

    [string] $Dmg1

    [string] $Dmg2

    [ValidateSet("B","P","S","A","C","F","FC","L","N","PS","R","T")]
    $DmgType

    [ValidateSet("A","F","H","L","LD","R","S","T","2H","V","M")]
    [string[]] $Property

    [string] $Range

    [Modifier[]] $Modifier

    [string[]] $Roll

    [string] $Magic

    [xml] $XML

    [string[]] $FilesLocatedIn

    ItemXML ([string] $Name)
    {
        $this.Name = $Name.Trim()
        $this.Modifier = [Modifier]::new()
    }

    CreateXML($XMLFile)
    {
        $this.XML = $XMLFile
        $this.Compare()
    }

    Compare ()
    {
        $Create = $true

        foreach($item in $this.XML.compendium.item)
        {
            if($item.name -eq $this.Name)
            {
                $Create = $false
                $this.CompareFiles($item)
                $this.CompareType($item)
                $this.CompareValue($item)
                $this.CompareWeight($item)
                $this.CompareAC($item)
                $this.CompareStrength($item)
                $this.CompareStealth($item)
                $this.CompareDmg($item)
                $this.CompareProperty($item)

                Write-Host -ForegroundColor White -BackgroundColor Black "Found - $($this.Name) - $($item.FilesLocatedIn)"
            }
        }
        if($Create)
        {
            #Write-Host -ForegroundColor White -BackgroundColor Black "Creating - $($this.Name)"
            $this.CreateNew()
        }
    }

    Hidden CreateNew()
    {
        $NewItem = $this.XML.CreateElement("item")
        $ItemName = $this.XML.CreateElement("name")
        $ItemType = $this.XML.CreateElement("type")
        $ItemValue = $this.XML.CreateElement("value")
        $ItemWeight = $this.XML.CreateElement("weight")
        $ItemAC = $this.XML.CreateElement("ac")
        $ItemStrength = $this.XML.CreateElement("strength")
        $ItemStealth = $this.XML.CreateElement("stealth")
        $ItemDmg1 = $this.XML.CreateElement("dmg1")
        $ItemDmg2 = $this.XML.CreateElement("dmg2")
        $ItemDmgType = $this.XML.CreateElement("dmgType")
        $ItemRange = $this.XML.CreateElement("range")
        $ItemMagic = $this.XML.CreateElement("magic")
        $ItemFiles = $this.XML.CreateElement("filesLocatedIn")
        $ItemProperty = $this.XML.CreateElement("property")

        if( ($this.name -ne [string]::Empty) -and ($this.Name -ne $null) ) { $ItemName.InnerXml = $this.Name } 
        if( ($this.Type -ne [string]::Empty) -and ($this.Type -ne $null) ) { $ItemType.InnerXml = $this.Type } else { $ItemType.InnerXml = "G" }
        if( ($this.Value -ne [string]::Empty) -and ($this.Value -ne $null) ) { $ItemValue.InnerXml = $this.Value } else { $ItemValue.InnerXml = "0" }
        if( ($this.Weight -ne [string]::Empty ) -and ( $this.Weight -ne $null ) ) { $ItemWeight.InnerXml = $this.Weight } else { $ItemWeight.InnerXml = "0.001" }
        if( ($this.AC -ne [string]::Empty ) -and ( $this.AC -ne $null ) ) { $ItemAC.InnerXml = $this.AC }
        if( ($this.Strength -ne [string]::Empty ) -and ( $this.Strength -ne $null ) ) {$ItemStrength.InnerXml = $this.Strength }
        if( ($this.Stealth -ne [string]::Empty ) -and ( $this.Stealth -ne $null ) ) {$ItemStealth.InnerXml = $this.Stealth }
        if( ($this.Dmg1 -ne [string]::Empty ) -and ( $this.Dmg1 -ne $null ) ) {$ItemDmg1.InnerXml = $this.Dmg1 }
        if( ($this.Dmg2 -ne [string]::Empty ) -and ( $this.Dmg2 -ne $null ) ) {$ItemDmg2.InnerXml = $this.Dmg2 }
        if( ($this.DmgType -ne [string]::Empty ) -and ( $this.DmgType -ne $null ) ) {$ItemDmgType.InnerXml = $this.DmgType }
        if( ($this.Range -ne [string]::Empty ) -and ( $this.Range -ne $null ) ) {$ItemRange.InnerXml = $this.Range }
        if( ($this.Magic -ne [string]::Empty ) -and ( $this.Magic -ne $null ) ) {$ItemMagic.InnerXml = $this.Magic }
        if( ($this.FilesLocatedIn -ne [string]::Empty) -and ($this.FilesLocatedIn -ne $null) ) { $ItemFiles.InnerXml = $this.FilesLocatedIn }

        $ItemProperty.InnerXml = $this.Property

        $NewItem.AppendChild($ItemName)
        $NewItem.AppendChild($ItemType)
        $NewItem.AppendChild($ItemValue)
        $NewItem.AppendChild($ItemWeight)
        $NewItem.AppendChild($ItemAC)
        $NewItem.AppendChild($ItemStrength)
        $NewItem.AppendChild($ItemStealth)
        $NewItem.AppendChild($ItemDmg1)
        $NewItem.AppendChild($ItemDmg2)
        $NewItem.AppendChild($ItemDmgType)
        $NewItem.AppendChild($ItemRange)
        $NewItem.AppendChild($ItemMagic)
        $NewItem.AppendChild($ItemProperty)
        $NewItem.AppendChild($ItemFiles)

        foreach($i in $this.Text)
        {
            $NewItem.AppendChild($this.CreateText($i))
        }
        foreach($i in $this.Roll)
        {
            $NewItem.AppendChild($this.CreateRoll($i))
        }
        foreach($i in $this.Modifier)
        {
            $NewItem.AppendChild($this.CreateModifier($i))
        }
        foreach($i in $this.Property)
        {
          if( ($ItemProperty.InnerXml -eq $null) -and () )
          {

          }
        }

        $this.XML.compendium.AppendChild($NewItem)
    }

    ItemXML ([System.Xml.XmlElement] $XMLElement)
    {
        $this.Name = $XMLElement.name
        $this.AC = $XMLElement.ac
        $this.Dmg1 = $XMLElement.dmg1
        $this.Dmg2 = $XMLElement.dmg2
        if(($XMLElement.dmgtype -ne $null) -and ($XMLElement.dmgtype -ne [string]::Empty)) { $this.DmgType = $XMLElement.dmgtype }
        $this.Range = $XMLElement.range
        if(($XMLElement.stealth -ne $null) -and ($XMLElement.stealth -ne [string]::Empty)) { if($XMLElement.stealth = "1") { $this.Stealth = 1 } else { $this.Stealth = 0 } } else { $this.Stealth = 0 }
        if(($XMLElement.strength -ne $null) -and ($XMLElement.strength -ne [string]::Empty)) { $this.Strength = $XMLElement.strength }
        if(($XMLElement.value -ne $null) -and ($XMLElement.value -ne [string]::Empty)) { $this.Value = $XMLElement.value }
        if(($XMLElement.weight -ne $null) -and ($XMLElement.weight -ne [string]::Empty)) { $this.Weight = $XMLElement.weight }
        if(($XMLElement.type -ne $null) -and ($XMLElement.type -ne [string]::Empty)) { $this.Type = $XMLElement.type }
        $this.ItemModifier($XMLElement)
        $this.ItemText($XMLElement)
        $this.ItemProperty($XMLElement)
        $this.ItemRoll($XMLElement)
        $this.Magic = $XMLElement.magic
    }

    Hidden ItemText ($XMLELEMENT)
    {
        foreach ($t in $XMLELEMENT.text)
        {
            $this.Text += $t
        }
    }
    
    Hidden ItemProperty($XMLELEMENT)
    {
        if($XMLELEMENT.property -ne $null) 
        {
            foreach($p in $XMLELEMENT.property.split(','))
            {
                if($p -ne [string]::Empty) 
                { 
                    $this.Property += $p.Trim() 
                }
            }
        }
    }

    Hidden ItemModifier($XMLELEMENT)
    {
        foreach($mod in $XMLELEMENT.modifier)
        {
            $ItemModifier = [Modifier]::new()
            $ItemModifier.Category = $mod.category
            $ItemModifier.Text = $mod.InnerXML
            $ItemModifier.Name = "$($mod.category) $($mod.InnerXML)"
            $this.Modifier += ($ItemModifier)
        }
    }

    Hidden ItemRoll($XMLELEMENT)
    {
        if(($XMLELEMENT.roll -ne $null) -and ($XMLELEMENT.roll -ne [string]::Empty))
        {
            foreach ($roll in $XMLELEMENT.roll)
            {
                $this.Roll += $roll
            }
        }
    }

    Hidden [XML.XMLElement] CreateText ($item)
    {
        $ItemText = $null
        $ItemText = $this.XML.CreateElement("text")
        $ItemText.InnerXml = $item
        return $ItemText
    }

    Hidden [XML.XMLElement] CreateRoll ($item)
    {
        $ItemRoll = $null
        $ItemRoll = $this.XML.CreateElement("rolls")
        $ItemRoll.InnerXml = $item
        return $ItemRoll
    }

    Hidden [XML.XMLElement] CreateModifier ($item)
    {
        $ItemModifier = $null
        $ItemModifier = $this.XML.CreateElement("modifier")
        $ItemModifier.SetAttribute("category",$item.Category)        
        $ItemModifier.InnerXml = $item.Text
        return $ItemModifier
    }

    Hidden [XML.XMLElement] CompareFiles ($item)
    {
        if($item.filesLocatedIn -notmatch $this.FilesLocatedIn) 
        {
            if( ($item.filesLocatedIn -eq [string]::Empty) -or ($item.filesLocatedIn -eq $null) ) 
            {   
                $item.filesLocatedIn += "$($this.FilesLocatedIn)" 
            }
            else 
            { 
                $item.filesLocatedIn += ", $($this.FilesLocatedIn)" 
            }
        }
        return $item
    }

    Hidden [XML.XMLElement] CompareType ($item)
    {
        if($item.type -notmatch $this.Type)
        {
            $item.Type = $this.Type
        }
        return $item
    }

     Hidden [XML.XMLElement] CompareValue ($item)
     {
        if($item.value -notmatch $this.Value)
        {
            $item.value = $this.Value
        }
        return $item
     }

    Hidden [XML.XMLElement] CompareWeight ($item)
    {
        if($item.weight -notmatch $this.Weight)
        {
            $item.weight = $this.Weight
        }
        return $item
    }
    
    Hidden [XML.XMLElement] CompareAC ($item)
    {
        if($item.ac -notmatch $this.AC)
        {
            $item.ac = $this.AC
        }
        return $item
    }

    Hidden [XML.XMLElement] CompareStrength ($item)
    {
        if($item.strength -notmatch $this.Strength)
        {
            $item.strength = $this.Strength
        }
        return $item
    }

    Hidden [XML.XMLElement] CompareStealth ($item)
    {
        if($item.stealth -notmatch $this.Stealth)
        {
            $item.stealth = "$($this.Stealth)"
        }
        return $item
    }

    Hidden [XML.XMLElement] CompareDmg ($item)
    {
        if($item.dmg1 -notmatch $this.Dmg1)
        {
            $item.dmg1 = $this.Dmg1
        }
        if($item.dmg2 -notmatch $this.Dmg2)
        {
            $item.dmg2 = $this.Dmg2
        }

        if($Item.dmgType -ne $this.DmgType)
        {
            $item.dmgType = "$($this.DmgType)"
        }

        return $item
    }

    Hidden [XML.XMLElement] CompareProperty ($item)
    {
        if($item.property -ne $null) 
        {
            foreach($p in $item.property.split(','))
            {
                $Needed = $true
                if($p -ne [string]::Empty) 
                { 
                    ForEach ($property in $this.Property)
                    {
                        if($p -eq $property)
                        {
                            $Needed = $false
                        }
                    }
                    if($Needed)
                    {
                        $item.property += $p.Trim()
                    }
                }
            }
        }
        return $item
    }
}

$items = $null
ForEach ($Files in (Get-ChildItem -Path "C:\Users\wfischbeck\source\repos\warren-fischbeck\DDCM\FischbeckEnterprises.FightClub.XML\Sources\"))
{
    [xml] $content = Get-Content -Path $Files.FullName
    $items = $content.compendium.item

    if(($items[0].InnerXml -ne $null) -and ($items.Count -ge 1))
    {
        Write-Host "This file $($Files.Name) has $($items.Count) items in it."
    }
    if(($items[0].InnerXml -ne $null) -and ($items.Count -ge 1))
    {
        foreach($objItem in $items)
        {
            #Write-Host -ForegroundColor Yellow -BackgroundColor Black "$($objItem.name)"
            [ItemXML] $item = [ItemXML]::new($objItem)
            $item.FilesLocatedIn = "$($Files.Name)"
            $item.CreateXML($xmlFile)
        }
    }
}

$xmlFile.compendium.item | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
Write-Host "A total of $($xmlFile.compendium.item.Count) items"
$xmlFile.Save("$($env:OneDriveConsumer)\Documents\Dungeon & Dragons\xml_Sheets\Complete\_ItemComplete.xml")