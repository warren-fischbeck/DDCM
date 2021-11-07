[Reflection.Assembly]::LoadWithPartialName("System.Xml.Linq") | Out-Null
[xml]$xmlCompletedFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5" auto_indent="NO">
</compendium>  
"@

$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()


Function Set-Element
{
    [CmdletBinding()]
    [Alias()]
    [OutputType([int])]
    Param
    (
        # Param1 help description
        [Parameter(Mandatory=$true,
                   ValueFromPipelineByPropertyName=$true,
                   Position=0)]
        $XMLElementSource,

        # Param2 help description
        $XMLElementChange,

        [ValidateSet("Level", "Classes", "Ritual", "Time", "Range", "Components", "Duration", "Text", "School")]
        $ElementChanging
    )

    Begin
    {
    }
    Process
    {
        switch ($ElementChanging)
        {
            'Level' 
            {
                if($XMLElementChange.level -ne $null)
                {
                    if(($XMLElementSource.level -ne $null)) { try { $XMLElementSource.RemoveChild("level") } catch { $XMLElementSource.level = $XMLElementChange.level; break } }
                    $item = $xmlCompletedFile.CreateElement("level")
                    $item.InnerXml = $XMLElementChange.level
                    $XMLElementSource.AppendChild($item) | Out-Null
                }
            }
            'Classes' 
            {
                if($XMLElementSource.classes -notcontains $XMLElementChange.classes)
                {
                    $source = $XMLElementSource.classes.split(',')
                    $new = $XMLElementChange.classes.split(',')
                    $collection = @()
                    $string = $null
                    foreach ($s in $source) { if($s.Trim() -ne "Null") { $collection += $s.Trim() } }
                    foreach ($n in $new) { $collection += $n.trim()  }
                    $collection = $collection | Sort
                    $colC = $collection | Get-Unique
                    foreach($item in $colC)
                    {
                        if($string -eq $null) { $string = $item.trim() }
                        else { $string += ", $($item.trim())" }
                    }
                    $XMLElementSource.classes=$string
                }
            }
            'Ritual' 
            {
                if($XMLElementChange.ritual -ne $null)
                {
                    if($XMLElementSource.ritual -ne $null) { try { $XMLElementSource.RemoveChild("ritual") } catch { $XMLElementSource.ritual = $XMLElementChange.ritual; break } }
                    $item = $xmlCompletedFile.CreateElement("ritual")
                    $item.InnerXml = $XMLElementChange.ritual
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            'School' 
            {
                if($XMLElementChange.school -ne $null)
                {
                    if($XMLElementSource.school -ne $null) { try { $XMLElementSource.RemoveChild("school") } catch { $XMLElementSource.school = $XMLElementChange.school; break } }
                    $item = $xmlCompletedFile.CreateElement("school")
                    $item.InnerXml = $XMLElementChange.school
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            'Time' 
            {
                if($XMLElementChange.time -ne $null)
                {
                    if($XMLElementSource.time -ne $null) { try { $XMLElementSource.RemoveChild("time") } catch { $XMLElementSource.time = $XMLElementChange.time; break } }
                    $item = $xmlCompletedFile.CreateElement("time")
                    $item.InnerXml = $XMLElementChange.time
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            'Range' 
            {
                if($XMLElementChange.range -ne $null)
                {
                    if($XMLElementSource.range -ne $null) { try { $XMLElementSource.RemoveChild("range") } catch { $XMLElementSource.range = $XMLElementChange.range; break } }
                    $item = $xmlCompletedFile.CreateElement("range")
                    $item.InnerXml = $XMLElementChange.range
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            'Components' 
            {
                if($XMLElementChange.components -ne $null)
                {
                    if($XMLElementSource.components -ne $null) { try { $XMLElementSource.RemoveChild("components") } catch { $XMLElementSource.components = $XMLElementChange.components; break } }
                    $item = $xmlCompletedFile.CreateElement("components")
                    $item.InnerXml = $XMLElementChange.components
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            'Duration'
            {
                if($XMLElementChange.duration -ne $null)
                {
                    if($XMLElementSource.duration -ne $null) { try { $XMLElementSource.RemoveChild("duration") } catch { $XMLElementSource.duration = $XMLElementChange.duration; break } }
                    $item = $xmlCompletedFile.CreateElement("duration")
                    $item.InnerXml = $XMLElementChange.duration
                    $XMLElementSource.AppendChild($item) | Out-Null
                }  
            }
            Default 
            {
                foreach($objNewText in $XMLElementChange.text) 
                {
                    $objNewTextStart = $null
                    $matched = $false
                    
                    if($objNewText -eq $null){ $objNewElement = $xmlCompletedFile.CreateElement("text"); $objNewElement.InnerXml = ""; $XMLElementSource.AppendChild($objNewElement) | Out-Null }
                    
                    foreach ($objExistingText in $XMLElementSource.text)
                    {
                        if($objNewText.Length -ge $objExistingText.length)
                        {
                            if(($objExistingText.substring(0,$objExistingText.length / 2)) -ne ($objNewText.substring(0,$objExistingText.length / 2)))
                            {
                                <#
                                Write-Host -BackgroundColor Green "     Replacing old text with new text on spell $($XMLElementChange.name)"
                                Write-Host -BackgroundColor Yellow -ForegroundColor Black "          Replacing old text : $($objExistingText)"
                                Write-Host -BackgroundColor Cyan "          With new text : $($objNewText)"
                                #>
                                $objExistingText = $objNewText 
                            }
                            else
                            {
                                $matched = $true
                                break
                            }
                        }
                    }

                    if($matched -eq $false)
                    {                          
                        $objNewElement = $xmlCompletedFile.CreateElement("text"); $objNewElement.InnerXml = $objNewText.replace("&","and"); $XMLElementSource.AppendChild($objNewElement) | Out-Null
                    }
                }
            }
        }
    }
    End
    {
    }
}

Function Combine-Spell
{
    Param(
        $existingXML,
        $newXML
    )

    $matched = $false
    for ($i = 0; $i -lt $existingXML.compendium.spell.count; $i++)
    { 
        if($existingXML.compendium.spell[$i].name -eq $newXML.name)
        {
            $matched = $true
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Level
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Classes
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Ritual
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Text
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Components
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Duration
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Range
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging Time
            Set-Element -XMLElementSource $existingXML.compendium.spell[$i] -XMLElementChange $newXML -ElementChanging School

            Break
        }
    }
    if($matched -eq $false)
    {
        $newSpellElement = $xmlCompletedFile.CreateElement("spell")
        $newSpellComponentElement = $xmlCompletedFile.CreateElement("item")
        $newItemElement = $xmlCompletedFile.compendium.AppendChild($newSpellElement)

        if($newXML.name -ne $null) { $item = $xmlCompletedFile.CreateElement("name"); $item.InnerXml = $newXML.name; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.level -ne $null) { $item = $xmlCompletedFile.CreateElement("level"); $item.InnerXml = $newXML.level; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.ritual -ne $null) { $item = $xmlCompletedFile.CreateElement("ritual"); $item.InnerXml = $newXML.ritual; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.school -ne $null) { $item = $xmlCompletedFile.CreateElement("school"); $item.InnerXml = $newXML.school; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.time -ne $null) { $item = $xmlCompletedFile.CreateElement("time"); $item.InnerXml = $newXML.time; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.range -ne $null) { $item = $xmlCompletedFile.CreateElement("range"); $item.InnerXml = $newXML.range; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.components -ne $null) { $item = $xmlCompletedFile.CreateElement("components"); $item.InnerXml = $newXML.components; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.duration -ne $null) { $item = $xmlCompletedFile.CreateElement("duration"); $item.InnerXml = $newXML.duration; $newItemElement.AppendChild($item) | Out-Null }
        if($newXML.classes -ne $null) { $item = $xmlCompletedFile.CreateElement("classes"); $item.InnerXml = $newXML.classes; $newItemElement.AppendChild($item) | Out-Null }
        if(($newXML.text -ne $null) -and ($newXML.text.Count -eq 1)) { $item = $xmlCompletedFile.CreateElement("text"); $item.InnerXml = $newXML.text; $newItemElement.AppendChild($item) | Out-Null }
        elseif($newXML.text.Count -gt 1)
        {
            foreach($text in $newXML.text) 
            {
                            
                if ($text -eq $null){ $item = $xmlCompletedFile.CreateElement("text"); $item.InnerXml = ""; $newItemElement.AppendChild($item) | Out-Null }
                else { $item = $xmlCompletedFile.CreateElement("text"); $item.InnerXml = $text.replace("&","and"); $newItemElement.AppendChild($item) | Out-Null }
            }
        }

        if(($newXML.components -ne $null) -and ($newXML.components -match "M")) 
        { 
            if((($newXML.components).Split("(")).Count -gt 1)
            {
                $componentName = (($newXML.components).Split("(")[1].replace(")", "").replace(", which the spell consumes","")).Trim()
                $required = $true
                foreach ($currentSpellComponent in $xmlCompletedFile.compendium.item)
                {
                    if($currentSpellComponent.name -match $componentName) {$required = $false}
                }
                if($required)
                {
                    $newItem = $xmlCompletedFile.compendium.AppendChild($newSpellComponentElement)
                    $spellComponent = $xmlCompletedFile.CreateElement("name"); $spellComponent.InnerXml="[Spell component] $($componentName)"; $newItem.AppendChild($spellComponent) | Out-Null
                    $spellComponent = $xmlCompletedFile.CreateElement("type"); $spellComponent.InnerXml="G"; $newItem.AppendChild($spellComponent) | Out-Null
                    $spellComponent = $xmlCompletedFile.CreateElement("value"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                    $spellComponent = $xmlCompletedFile.CreateElement("weight"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                    $spellComponent = $xmlCompletedFile.CreateElement("magic"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                    $spellComponent = $xmlCompletedFile.CreateElement("text"); $spellComponent.InnerXml="[Spell Component] - $($componentName)"; $newItem.AppendChild($spellComponent) | Out-Null
                }
            }
        }
    }
}

Function Combine-Class
{
    Param(
        $existingXML,
        $newXML
    )
    $matched = $false
    for ($i = 0; $i -lt $existingXML.compendium.class.Count ; $i++)
    { 
        if($existingXML.compendium.class[$i].name -eq $newXML.name)
        {
            #Write-Host -BackgroundColor Yellow -ForegroundColor Black "          Matched $($existingXML.compendium.class[$i].name) to $($newXML.name)"
            $matched = $true
            if(($newXML.hd -ne $null) -and ($newXML.hd -ne $existingXML.compendium.class[$i].hd)) { $existingXML.compendium.class[$i].hd = $newXML.hd }
            if(($newXML.armor -ne $null) -and ($newXML.armor -ne $existingXML.compendium.class[$i].armor)) { $existingXML.compendium.class[$i].armor = $newXML.armor }
            if(($newXML.proficiency -ne $null) -and ($newXML.proficiency -ne $existingXML.compendium.class[$i].proficiency)) { $existingXML.compendium.class[$i].proficiency = $newXML.proficiency }
            if(($newXML.spellAbility -ne $null) -and ($newXML.spellAbility -ne $existingXML.compendium.class[$i].spellAbility)) { $existingXML.compendium.class[$i].spellAbility = $newXML.spellAbility }
            if(($newXML.numSkills -ne $null) -and ($newXML.numSkills -ne $existingXML.compendium.class[$i].numSkills)) { $existingXML.compendium.class[$i].numSkills = $newXML.numSkills }
            if(($newXML.weapons -ne $null) -and ($newXML.weapons -ne $existingXML.compendium.class[$i].weapons)) { $existingXML.compendium.class[$i].weapons = $newXML.weapons }
            if(($newXML.tools -ne $null) -and ($newXML.tools -ne $existingXML.compendium.class[$i].tools)) { $existingXML.compendium.class[$i].tools = $newXML.tools }
            if(($newXML.wealth -ne $null) -and ($newXML.wealth -ne $existingXML.compendium.class[$i].wealth)) { $existingXML.compendium.class[$i].wealth = $newXML.wealth }

            $autolevel = 1
            do
            {
                $autolevelfromClass = $newXML.autolevel | Where-Object { $_.level -eq $autolevel }
                if($autolevelfromClass -ne $null) 
                {
                    if(($autolevelfromClass.slots -ne $null) -and ($existingXML.compendium.class[$i].autolevel[$autolevel - 1].slots -eq $null))
                    {
                        if($autolevelfromClass.slots.optional -ne $null) 
                        {
                            $autolevelSlots = $xmlCompletedFile.CreateElement("slots")
                            $existingXML.compendium.class[$i].autolevel[$autolevel - 1].AppendChild($autolevelSlots) | Out-Null
                            $autolevelSlots.SetAttribute("optional", "YES")
                            $autolevelSlots.InnerXml = $autolevelfromClass.slots.InnerXml
                        }
                        else 
                        { 
                            $autolevelSlots = $xmlCompletedFile.CreateElement("slots")
                            $existingXML.compendium.class[$i].autolevel[$autolevel - 1].AppendChild($autolevelSlots) | Out-Null
                            $autolevelSlots.InnerXml = $autolevelfromClass.slots
                            $slots = $autolevelSlots.InnerXml.Trim()
                            $autolevelSlots.InnerXml = $slots
                        }
                    }

                    foreach  ($featureInAutoLevel in $autolevelfromClass.feature)                        
                    {
                        $featureRequired = $true
                        foreach ($XmlFeature in $existingXML.compendium.class[$i].autolevel[$autolevel - 1].feature)
                        {
                            if($XmlFeature.name -eq $featureInAutoLevel.name)
                            {
                                foreach($lineOfTextinAutolevel in $featureInAutoLevel.text)
                                {
                                    $textChangeRequired = $true
                                    foreach($lineOfTextInxmlFile in $XmlFeature.text)
                                    {
                                        if($lineOfTextInxmlFile -ne $lineOfTextinAutolevel)
                                        {
                                            $lineOfTextInxmlFile = $lineOfTextinAutolevel
                                        }
                                    }
                                }
                                $featureRequired = $false
                                break
                            }
                        }
                        if(($featureRequired) -and ($featureInAutoLevel -ne $null))
                        {
                            $import = $xmlCompletedFile.compendium.OwnerDocument.ImportNode($featureInAutoLevel, 1)
                            $existingXML.compendium.class[$i].autolevel[$autolevel - 1].AppendChild($import) | Out-Null
                        }
                    }

                    foreach ($counterInAutoLevel in $autolevelfromClass.counter)
                    {
                        $counterRequired = $true
                        if($counterInAutoLevel -eq $null) { $counterRequired = $false }
                        foreach ($counterinXml in $existingXML.compendium.class[$i].autolevel[$autolevel -1].counter)
                        {
                            if($counterInAutoLevel.name -eq $counterinXml.name)
                            {
                                $counterRequired = $false
                            }
                        }
                        if($counterRequired)
                        {
                            $counter = $xmlCompletedFile.compendium.OwnerDocument.ImportNode($counterInAutoLevel, 1)
                            $existingXML.compendium.class[$i].autolevel[$autolevel -1].AppendChild($counter) | Out-Null
                        }
                    }
                }
                $autolevel++
            }
            until ($autolevel -gt 21)

            break
        }
    }
    if($matched -eq $false)
    {
        #Write-Host -BackgroundColor Black -ForegroundColor Cyan "          Creating $($newXML.name)"
        $newClassElement = $xmlCompletedFile.CreateElement("class")
        $newXMLElement = $xmlCompletedFile.compendium.AppendChild($newClassElement)
                
        $item = $xmlCompletedFile.CreateElement("name"); $item.InnerXml = $newXML.name; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("hd"); $item.InnerXml = $newXML.hd; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("proficiency"); $item.InnerXml = $newXML.proficiency; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("spellAbility"); $item.InnerXml = $newXML.spellAbility; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("numSkills"); $item.InnerXml = $newXML.numSkills; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("armor"); $item.InnerXml = $newXML.armor; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("weapons"); $item.InnerXml = $newXML.weapons; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("tools"); $item.InnerXml = $newXML.tools; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("wealth"); $item.InnerXml = $newXML.wealth; $newXMLElement.AppendChild($item) | Out-Null                
        $item = $xmlCompletedFile.CreateElement("slotsReset")
            if($newXML.name -match "warlock") { $item.InnerXml = "S" } else { $item.InnerXml = "L" }
            $newXMLElement.AppendChild($item) | Out-Null

        $index = 1
        do
        {
            $item = $xmlCompletedFile.CreateElement("autolevel")
            $newXMLElement.AppendChild($item) | Out-Null
            $item.SetAttribute("level", "$($index)")
            switch ($index)
            {
                '4' { $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                '6' { if($newXML.name -match "fighter") { $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement"); $optional.InnerXml="YES"; $item.Attributes.Append($optional) | Out-Null } }
                '8' { $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                '12' { $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                '16' {  $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                '19' { $optional = $xmlCompletedFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                Default {}
            }

            #$autolevelSlots = $xmlCompletedFile.CreateElement("slots")
            #$item.AppendChild($autolevelSlots) | Out-Null

            $autolevelfromClass = $newXML.autolevel | Where-Object { $_.level -eq $index }
            if($autolevelfromClass -ne $null) 
            {
                foreach ($autoLevelFeature in $autolevelfromClass.feature)
                {
                    $feature = $xmlCompletedFile.CreateElement("feature"); $item.AppendChild($feature) | Out-Null; if($autoLevelFeature.optional -ne $null) { $feature.SetAttribute("optional", "YES") }
                    $featureName = $xmlCompletedFile.CreateElement("name"); $featurename.InnerXml = $autoLevelFeature.name; $feature.AppendChild($featureName) | Out-Null
                    foreach ($text in $autoLevelFeature.text) 
                    {
                        $featureText = $xmlCompletedFile.CreateElement("text")
                        try{
                            $featureText.InnerXml = $text
                        } catch { Write-Host $text }
                        $feature.AppendChild($featureText) | Out-Null
                    }
                }

                if($autoLevelFeature.counter -ne $null)
                {
                    foreach($levelCounter in $autoLevelFeature.counter)
                    {
                        $counter = $xmlCompletedFile.compendium.OwnerDocument.ImportNode($levelCounter, 1)
                        $item.AppendChild($counter) | Out-Null
                    }
                }
            }
            $autolevelfromClass = $null
            $index ++                                                      
        }
        until ($index -eq 21)
    }
}

$temp = $null
for ($i = 0; $i -lt (($MyInvocation.InvocationName.Split("\")).Count -2); $i++)
{
    if($temp -eq $null) { $temp = "$(($MyInvocation.InvocationName.Split("\"))[$i])" }
    else { $temp += "\$(($MyInvocation.InvocationName.Split("\"))[$i])" }
}

$colSourceFile = Get-ChildItem -Path "$($temp)\Sources" -Recurse -Include *.xml
$colSourceFile = $colSourceFile | select -Property fullname,length | sort -Descending -Property length

foreach ($objSourceFile in $colSourceFile)
{
    Write-Host "$($objSourceFile.FullName)"
    [xml]$objSourceXML = $null

    if($objSourceXMLBackground.Count -ne 0) { $objSourceXMLBackground = $null  }
    if($objSourceXMLMonster.Count -ne 0) { $objSourceXMLMonster = $null }
    if($objSourceXMLClass.Count -ne 0) { $objSourceXMLClass = $null }
    if($objSourceXMLFeat.Count -ne 0) { $objSourceXMLFeat = $null }
    if($objSourceXMLItem.Count -ne 0) { $objSourceXMLItem = $null }
    if($objSourceXMLRace.Count -ne 0) { $objSourceXMLRace = $null }
    if($objSourceXMLSpell.Count -ne 0) { $objSourceXMLSpell = $null }
    if($objSourceXMLContainer.Count -ne 0) { $objSourceXMLContainer = $null }

    [xml]$objSourceXML = Get-Content -Path $objSourceFile.FullName -Encoding UTF8
    #Start-Sleep -Seconds 2

    if($objSourceXML.compendium.background -ne $null) { $objSourceXMLBackground = $objSourceXML.compendium.background }
    if($objSourceXML.compendium.monster -ne $null) { $objSourceXMLMonster = $objSourceXML.compendium.monster }
    if($objSourceXML.compendium.class -ne $null) { $objSourceXMLClass = $objSourceXML.compendium.class }
    if($objSourceXML.compendium.feat -ne $null) { $objSourceXMLFeat = $objSourceXML.compendium.feat }
    if( ( $objSourceXML.compendium.item -ne $null ) -and ( $objSourceXML.compendium.Item.Name -ne "Item" ) ) { $objSourceXMLItem = $objSourceXML.compendium.item }
    if($objSourceXML.compendium.race -ne $null) { $objSourceXMLRace = $objSourceXML.compendium.race }
    if($objSourceXML.compendium.spell -ne $null) { $objSourceXMLSpell = $objSourceXML.compendium.spell }
    if($objSourceXML.compendium.container -ne $null) { $objSourceXMLContainer = $objSourceXML.compendium.container}
    
    if(($objSourceXMLBackground -ne $null) -and ($objSourceXMLBackground.Count -eq $null))
    {
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLBackground,1)) | Out-Null
        #Write-Host "     Processing Background : $($objSourceXMLBackground.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLBackground.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLBackground[$i].name)" -PercentComplete (($i/$objSourceXMLBackground.count) * 100)
            #Write-Host "     Processing Background : $($objSourceXMLBackground[$i].name)"
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLBackground[$i],1)) | Out-Null
        }
    }


    if(($objSourceXMLMonster -ne $null) -and ($objSourceXMLMonster.Count -eq $null))
    {
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLMonster,1)) | Out-Null
        #Write-Host "     Processing Monster : $($objSourceXMLMonster.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLMonster.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLMonster[$i].name)" -PercentComplete (($i/$objSourceXMLMonster.count) * 100)
            #Write-Host "     Processing Monster : $($objSourceXMLMonster[$i].name)"
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLMonster[$i],1)) | Out-Null
        }
    }


    if(($objSourceXMLClass -ne $null) -and ($objSourceXMLClass.Count -eq $null))
    {
        Combine-Class -existingXML $xmlCompletedFile -newXML $objSourceXMLClass
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLClass.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLClass[$i].name)" -PercentComplete (($i/$objSourceXMLClass.count) * 100)
            Combine-Class -existingXML $xmlCompletedFile -newXML $objSourceXMLClass[$i]
        }
    }


    if(($objSourceXMLFeat -ne $null) -and ($objSourceXMLFeat.Count -eq $null))
    {
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLFeat,1)) | Out-Null
        #Write-Host "     Processing Feat : $($objSourceXMLFeat.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLFeat.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLFeat[$i].name)" -PercentComplete (($i/$objSourceXMLFeat.count) * 100)
            #Write-Host "     Processing Feat : $($objSourceXMLFeat[$i].name)"
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLFeat[$i],1)) | Out-Null
        }
    }


    if(($objSourceXMLItem -ne $null) -and ($objSourceXMLItem.Count -eq $null))
    {
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLItem,1)) | Out-Null
        #Write-Host "     Processing Item : $($objSourceXMLItem.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLItem.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLItem[$i].name)" -PercentComplete (($i/$objSourceXMLItem.count) * 100)
            #Write-Host "     Processing Item : $($objSourceXMLItem[$i].name)"
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLItem[$i],1)) | Out-Null
        }
    }

    if(($objSourceXMLRace -ne $null) -and ($objSourceXMLRace.Count -eq $null))
    {
        #Write-Host "     Processing Race : $($objSourceXMLRace.name)"
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLRace,1)) | Out-Null
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLRace.Count; $i++)
        { 
            #Write-Host "     Processing Race : $($objSourceXMLRace[$i].name)"
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLRace[$i].name)" -PercentComplete (($i/$objSourceXMLRace.count) * 100)
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLRace[$i],1)) | Out-Null
        }
    }


    if(($objSourceXMLSpell -ne $null) -and ($objSourceXMLSpell.Count -eq $null))
    {
        #$xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLSpell,1)) | Out-Null
        Combine-Spell -existingXML $xmlCompletedFile -newXML $objSourceXMLSpell
        #Write-Host "     Processing Spell : $($objSourceXMLSpell.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLSpell.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLSpell[$i].name)" -PercentComplete (($i/$objSourceXMLSpell.count) * 100)
            #Write-Host "     Processing Spell : $($objSourceXMLSpell[$i].name)"
            Combine-Spell -existingXML $xmlCompletedFile -newXML $objSourceXMLSpell[$i]
            #$xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLSpell[$i],1)) | Out-Null
        }
    }


    if(($objSourceXMLContainer -ne $null) -and ($objSourceXMLContainer.Count -eq $null))
    {
        $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLContainer,1)) | Out-Null
        #Write-Host "     Processing Container : $($objSourceXMLContainer.name)"
    }
    else
    {
        for ($i = 0; $i -lt $objSourceXMLContainer.Count; $i++)
        { 
            Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Status "$($objSourceXMLContainer[$i].name)" -PercentComplete (($i/$objSourceXMLContainer.count) * 100)
            #Write-Host "     Processing Container : $($objSourceXMLContainer[$i].name)"
            $xmlCompletedFile.compendium.AppendChild($xmlCompletedFile.compendium.OwnerDocument.ImportNode($objSourceXMLContainer[$i],1)) | Out-Null
        }
    }


    Write-Progress -Id 0 -Activity "Processing $($objSourceFile.FullName)" -Completed
}

$xmlCompletedFile.compendium.spell | sort level | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort ritual | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort school | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort time | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort range | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort componets | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort duration | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort classes | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.spell | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.race | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.background | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.class | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.Feat | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.item | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.container | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}
$xmlCompletedFile.compendium.monster | sort Name | % {[void]$xmlCompletedFile.compendium.AppendChild($_)}

foreach ($class in $xmlCompletedFile.compendium.class)
{
    foreach ($autolevel in $class.autolevel)
    {
        [System.Xml.XmlNode]$test = $autolevel
        $test.feature | sort name | foreach {[void]$autolevel.AppendChild($_)}
    }
}

foreach ($objClass in $xmlCompletedFile.compendium.class)
{
    Write-Host "Organizing class features for: $($objClass.name)"
    foreach($autolevel in $objClass.autolevel)
    {
        foreach($feature in $autolevel.feature)
        {
            #Write-Host "Feature - $($feature.name)"
            if([string]::IsNullOrEmpty($feature.name))
            {
                #Write-Host "Found One - $($autolevel.level)"
                $feature.ParentNode.RemoveChild($feature) | Out-Null
            }
        }
    }
}


$xmlCompletedFile.Save("$($temp)\Complete.xml")
if(Test-Path -Path "C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\Complete.xml") 
{
    $xmlCompletedFile.Save("C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\Complete.xml")
}
elseif (Test-Path -Path "C:\Users\warre\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\Complete.xml")
{
    $xmlCompletedFile.Save("C:\Users\warre\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\Complete.xml")
}

$stopwatch.Stop()
Write-Host "Script took $(($stopwatch.Elapsed).Minutes) minutes(s) and $(($stopwatch.Elapsed).Seconds) second(s) to complete"