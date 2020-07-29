[Reflection.Assembly]::LoadWithPartialName("System.Xml.Linq") | Out-Null
[xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5">
</compendium>  
"@

$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

Function Create-LogEntry {
    [CmdletBinding(DefaultParameterSetName='Parameter Set 1', 
                    SupportsShouldProcess=$true, 
                    PositionalBinding=$false,
                    HelpUri = 'http://www.microsoft.com/',
                    ConfirmImpact='Medium')]
	Param(
        [Parameter(Mandatory=$True,
                   ValueFromPipeline=$True,
                   ValueFromPipelinebyPropertyName=$True)]
        [string]
	    $sComponent,
        [Parameter(Mandatory=$True,
                   ValueFromPipeline=$True,
                   ValueFromPipelinebyPropertyName=$True)]
        [string]
	    $sLogFile,
        [Parameter(Mandatory=$True,
                   ValueFromPipeline=$True,
                   ValueFromPipelinebyPropertyName=$True)]
        [string]
	    $sLogMsg,
	    [Parameter(Mandatory=$false,
                   ValueFromPipeline=$True,
                   ValueFromPipelinebyPropertyName=$True)]
        [ValidateSet("INFO","WARNING","FAILURE")]
	    $sLogType
	)
    Process
    {
	    # Populate the variables to log

        switch ($sLogType)
        {
            'INFO' {$sType=1}
            'WARNING' {$sType=2}
            'FAILURE' {$sType=3}
            Default {$sType=$null}
        }

	    $sTime = (Get-Date -Format HH:mm:ss) + ".000+000"
	    $sDate = Get-Date -Format MM-dd-yyyy
	    $sTempMsg = "<![LOG[$sLogMsg]LOG]!><time=""$sTime"" date=""$sDate"" component=""$sComponent"" context="""" type=""$sType"" thread=""$($PID)"" file=""$sComponent"">"


	    # Create the component log entry

	    Write-Output $sTempMsg | Out-File -FilePath $sLogFile -Encoding "Default" -Append

    }
} # End of Create-LogEntry function

Function Collect-XMLFiles
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
        $SourceFolder
    )

    Begin
    {
        $tempComponent = $logMSG.sComponent
        $logMSG.sComponent = "Collect-XMLFiles"
    }
    Process
    {
        $logMSG | Create-LogEntry -sLogMsg "Collecting all files from $($SourceFolder)" -sLogType INFO
        return Get-ChildItem -Path $SourceFolder -Recurse -Include *.xml
    }
    End
    {
        $logMSG.sComponent = $tempComponent
    }
}

Function Get-Modifier 
{
    param (
        $Score = 0
    )
    
    return [math]::Truncate(($Score - 10) / 2)
}

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
        $tempComponent = $logMSG.sComponent
        $logMSG.sComponent = "Set-Element"
    }
    Process
    {
        switch ($ElementChanging)
        {
            'Level' 
            {
                if($XMLElementChange.level -ne $null)
                {
                    if($XMLElementSource.level -ne $null) { try { $XMLElementSource.RemoveChild("level") } catch { } }
                    $item = $xmlFile.CreateElement("level")
                    $item.InnerXml = $XMLElementChange.level
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting level on $($XMLElementSource.name)" -sLogType INFO
                }
            }
            'Classes' 
            {
                if($XMLElementSource.classes -notcontains $XMLElementChange.classes)
                {
                    $source = $XMLElementSource.classes.split(',')
                    $new = $XMLElementChange.classes.split(',')
                    foreach ($n in $new)
                    {
                        $add = $true
                        foreach($e in $source)
                        {
                            if($e -match $n)
                            {
                                $add = $false
                                break;
                            }
                        }
                        if($add) { $source += $n }
                    }
                    $string = $null
                    foreach ($e in $source) {if($string -eq $null){ $string = "$($e)" } else {$string += ",$($e.Trim())"}}
                    $XMLElementSource.classes=$string
                }
                $logMSG | Create-LogEntry -sLogMsg "Setting classes on $($XMLElementSource.name)" -sLogType INFO
            }
            'Ritual' 
            {
                if($XMLElementChange.ritual -ne $null)
                {
                    if($XMLElementSource.ritual -ne $null) { try { $XMLElementSource.RemoveChild("ritual") } catch { } }
                    $item = $xmlFile.CreateElement("ritual")
                    $item.InnerXml = $XMLElementChange.ritual
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting ritual on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            'School' 
            {
                if($XMLElementChange.school -ne $null)
                {
                    if($XMLElementSource.school -ne $null) { try { $XMLElementSource.RemoveChild("school") } catch { } }
                    $item = $xmlFile.CreateElement("school")
                    $item.InnerXml = $XMLElementChange.school
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting school on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            'Time' 
            {
                if($XMLElementChange.time -ne $null)
                {
                    if($XMLElementSource.time -ne $null) { try { $XMLElementSource.RemoveChild("time") } catch { } }
                    $item = $xmlFile.CreateElement("time")
                    $item.InnerXml = $XMLElementChange.time
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting time on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            'Range' 
            {
                if($XMLElementChange.range -ne $null)
                {
                    if($XMLElementSource.range -ne $null) { try { $XMLElementSource.RemoveChild("range") } catch { } }
                    $item = $xmlFile.CreateElement("range")
                    $item.InnerXml = $XMLElementChange.range
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting range on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            'Components' 
            {
                if($XMLElementChange.components -ne $null)
                {
                    if($XMLElementSource.components -ne $null) { try { $XMLElementSource.RemoveChild("components") } catch { } }
                    $item = $xmlFile.CreateElement("components")
                    $item.InnerXml = $XMLElementChange.components
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting components on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            'Duration'
            {
                if($XMLElementChange.duration -ne $null)
                {
                    if($XMLElementSource.duration -ne $null) { try { $XMLElementSource.RemoveChild("duration") } catch { } }
                    $item = $xmlFile.CreateElement("duration")
                    $item.InnerXml = $XMLElementChange.duration
                    $XMLElementSource.AppendChild($item) | Out-Null
                    $logMSG | Create-LogEntry -sLogMsg "Setting duration on $($XMLElementSource.name)" -sLogType INFO
                }  
            }
            Default 
            {
                #if($XMLElementSource.text.Count -ne 0 ){$XMLElementSource.RemoveChild("text")}
                foreach($text in $XMLElementChange.text) 
                {                            
                    if ($text -eq $null){ $item = $xmlFile.CreateElement("text"); $item.InnerXml = ""; $XMLElementSource.AppendChild($item) | Out-Null }
                    else { $item = $xmlFile.CreateElement("text"); $item.InnerXml = $text.replace("&","and"); $XMLElementSource.AppendChild($item) | Out-Null }
                }
                $logMSG | Create-LogEntry -sLogMsg "Setting text on $($XMLElementSource.name)" -sLogType INFO
            }
        }
    }
    End
    {
        $logMSG.sComponent = $tempComponent
    }
}

Function Create-XMLFile
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
        [ValidateSet("Background", "Monster", "Class", "Feat", "Item", "Race", "Spell", "Container")]
        $Component,

        [Parameter(Mandatory=$true,
                   ValueFromPipelineByPropertyName=$true,
                   Position=1)]
        $SourceFile
    )

    Begin
    {
        $tempComponent = $logMSG.sComponent
        $logMSG.sComponent = "Create-XMLFile"
    }
    Process
    {
        [xml]$source = Get-Content -Path $SourceFile.FullName -Encoding UTF8
        $sourceItem = @()
        $newItemElement = $null
        switch ($Component)
        {
            'Background' 
            {
                $sourceItem = $source.compendium.background
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing background             $($sourceItem[$i].name)" -sLogType INFO
                    $backgroundRequired = $true
                    foreach($backgroundinXML in $xmlFile.compendium.background)
                    {
                        if($backgroundinXML.name -eq $sourceItem[$i].name)
                        {
                            $backgroundRequired = $false
                        }
                    }
                    if($backgroundRequired)
                    {
                        $import = $xmlFile.compendium.OwnerDocument.ImportNode($sourceItem[$i], 1)
                        $xmlFile.compendium.AppendChild($import) | Out-Null
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            'Monster' 
            {
                $sourceItem = $source.compendium.monster
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($sourceItem[$i].name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing monster             $($sourceItem[$i].name)" -sLogType INFO
                    $required = $true
                    foreach($monsterInXML in $xmlFile.compendium.monster)
                    {
                        if($monsterInXML.name -eq $sourceItem[$i].name)
                        {
                            $required = $false
                            $logMSG | Create-LogEntry -sLogMsg "Located monster $($monsterInXML.Name)" -sLogType FAILURE
                            if(($sourceItem[$i].size) -ne $null) { if($monsterInXML.size -ne $sourceItem[$i].size) { $monsterInXML.size = $sourceItem[$i].size; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed size to $($sourceItem[$i].size)" -sLogType WARNING } }
                            if(($sourceItem[$i].type) -ne $null) { if($monsterInXML.type -ne $sourceItem[$i].type) { $monsterInXML.type = $sourceItem[$i].type.ToLower(); $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed type to $($sourceItem[$i].type)" -sLogType WARNING } }
                            if(($sourceItem[$i].alignment) -ne $null) { if($monsterInXML.alignment -ne $sourceItem[$i].alignment) { $monsterInXML.alignment = $sourceItem[$i].alignment; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed alignment to $($sourceItem[$i].alignment)" -sLogType WARNING } }
                            if(($sourceItem[$i].ac) -ne $null) { if($monsterInXML.ac -ne $sourceItem[$i].ac) { $monsterInXML.ac = $sourceItem[$i].ac; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed ac to $($sourceItem[$i].ac)" -sLogType WARNING } }
                            if(($sourceItem[$i].hp) -ne $null) { if($monsterInXML.hp -ne $sourceItem[$i].hp) { $monsterInXML.hp = $sourceItem[$i].hp; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed hp to $($sourceItem[$i].hp)" -sLogType WARNING } }
                            if(($sourceItem[$i].speed) -ne $null) { if($monsterInXML.speed -ne $sourceItem[$i].speed) { $monsterInXML.speed = $sourceItem[$i].speed; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed speed to $($sourceItem[$i].speed)" -sLogType WARNING } }
                            if(($sourceItem[$i].init) -ne $null)  { if($monsterInXML.init -ne $sourceItem[$i].init) { $monsterInXML.init = $sourceItem[$i].init; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed init to $($sourceItem[$i].init)" -sLogType WARNING } }
                            if(($sourceItem[$i].str) -ne $null) { if($monsterInXML.str -ne $sourceItem[$i].str) { $monsterInXML.str = $sourceItem[$i].str; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed str to $($sourceItem[$i].str)" -sLogType WARNING } }
                            if(($sourceItem[$i].dex) -ne $null) { if($monsterInXML.dex -ne $sourceItem[$i].dex) { $monsterInXML.dex = $sourceItem[$i].dex; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed dex to $($sourceItem[$i].dex)" -sLogType WARNING } }
                            if(($sourceItem[$i].con) -ne $null) { if($monsterInXML.con -ne $sourceItem[$i].con) { $monsterInXML.con = $sourceItem[$i].con; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed con to $($sourceItem[$i].con)" -sLogType WARNING } }
                            if(($sourceItem[$i].int) -ne $null) { if($monsterInXML.int -ne $sourceItem[$i].int) { $monsterInXML.int = $sourceItem[$i].int; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed int to $($sourceItem[$i].int)" -sLogType WARNING } }
                            if(($sourceItem[$i].wis) -ne $null) { if($monsterInXML.wis -ne $sourceItem[$i].wis) { $monsterInXML.wis = $sourceItem[$i].wis; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed wis to $($sourceItem[$i].wis)" -sLogType WARNING } }
                            if(($sourceItem[$i].cha) -ne $null) { if($monsterInXML.cha -ne $sourceItem[$i].cha) { $monsterInXML.cha = $sourceItem[$i].cha; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed cha to $($sourceItem[$i].cha)" -sLogType WARNING } }
                            if(($sourceItem[$i].save) -ne $null) { if($monsterInXML.save -ne $sourceItem[$i].save) { $monsterInXML.save = $sourceItem[$i].save; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed save to $($sourceItem[$i].save)" -sLogType WARNING } }
                            if(($sourceItem[$i].skill) -ne $null) { if($monsterInXML.skill -ne $sourceItem[$i].skill) { $monsterInXML.skill = $sourceItem[$i].skill; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed skill to $($sourceItem[$i].skill)" -sLogType WARNING } }
                            if(($sourceItem[$i].vulnerable) -ne $null) { if($monsterInXML.vulnerable -ne $sourceItem[$i].vulnerable) { $monsterInXML.vulnerable = $sourceItem[$i].vulnerable; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed vulnerable to $($sourceItem[$i].vulnerable)" -sLogType WARNING } }
                            if(($sourceItem[$i].resist) -ne $null) { if($monsterInXML.resist -ne $sourceItem[$i].resist) { $monsterInXML.resist = $sourceItem[$i].resist; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed resist to $($sourceItem[$i].resist)" -sLogType WARNING } }
                            if(($sourceItem[$i].immune) -ne $null) { if($monsterInXML.immune -ne $sourceItem[$i].immune) { $monsterInXML.immune = $sourceItem[$i].immune; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed immune to $($sourceItem[$i].immune)" -sLogType WARNING } }
                            if(($sourceItem[$i].conditionImmune) -ne $null) { if($monsterInXML.conditionImmune -ne $sourceItem[$i].conditionImmune) { $monsterInXML.conditionImmune = $sourceItem[$i].conditionImmune; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed conditionImmune to $($sourceItem[$i].conditionImmune)" -sLogType WARNING } }
                            if(($sourceItem[$i].senses) -ne $null) { if($monsterInXML.senses -ne $sourceItem[$i].senses) { $monsterInXML.senses = $sourceItem[$i].senses; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed senses to $($sourceItem[$i].senses)" -sLogType WARNING } }
                            if(($sourceItem[$i].passive) -ne $null) { if($monsterInXML.passive -ne $sourceItem[$i].passive) { $monsterInXML.passive = $sourceItem[$i].passive; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed passive to $($sourceItem[$i].passive)" -sLogType WARNING } }
                            if(($sourceItem[$i].languages) -ne $null) { if($monsterInXML.languages -ne $sourceItem[$i].languages) { $monsterInXML.languages = $sourceItem[$i].languages; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed languages to $($sourceItem[$i].languages)" -sLogType WARNING } }
                            if(($sourceItem[$i].cr) -ne $null) { if($monsterInXML.cr -ne $sourceItem[$i].cr) { $monsterInXML.cr = $sourceItem[$i].cr; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed cr to $($sourceItem[$i].cr)" -sLogType WARNING } }
                            if(($sourceItem[$i].slots) -ne $null) { if($monsterInXML.slots -ne $sourceItem[$i].slots) { $monsterInXML.slots = $sourceItem[$i].slots; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed slots to $($sourceItem[$i].slots)" -sLogType WARNING } }
                            if(($sourceItem[$i].spells) -ne $null) { if($monsterInXML.spells -ne $sourceItem[$i].spells) { $monsterInXML.spells = $sourceItem[$i].spells; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed spells to $($sourceItem[$i].spells)" -sLogType WARNING } }
                            if(($sourceItem[$i].environment) -ne $null) { if($monsterInXML.environment -ne $sourceItem[$i].environment) { $monsterInXML.environment = $sourceItem[$i].environment; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed environment to $($sourceItem[$i].environment)" -sLogType WARNING } }
                            if(($sourceItem[$i].description) -ne $null) { if($monsterInXML.description -ne $sourceItem[$i].description) { $monsterInXML.description = $sourceItem[$i].description; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed description to $($sourceItem[$i].description)" -sLogType WARNING } }
                            if(($sourceItem[$i].action.count) -ge 1) { for ($a = 0; $a -lt $sourceItem[$i].action.Count; $a++) { $actionRequired = $true ; for ($b = 0; $b -lt $monsterInXML.action.Count; $b++) { if($sourceItem[$i].action[$a].name -eq $monsterInXML.action[$b].name) { $actionRequired = $false; break; } } if($actionRequired) { $actionItem = $xmlFile.CreateElement("action"); $monsterInXML.AppendChild($actionItem) | Out-Null; $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].action[$a].name; $actionItem.AppendChild($item) | Out-Null; $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].action[$a].text; $actionItem.AppendChild($item) | Out-Null; $item = $xmlFile.CreateElement("attack"); $item.InnerXml = $sourceItem[$i].action[$a].attack; $actionItem.AppendChild($item) | Out-Null; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed action to $($sourceItem[$i].action[$a].name)" -sLogType WARNING; } } }
                            if(($sourceItem[$i].trait.Count) -ge 1) { for($a = 0; $a -lt $sourceItem[$i].action.Count; $a++) { $actionRequired = $true; for ($b = 0; $b -lt $monsterInXML.trait.Count; $b ++) { if($sourceItem[$i].trait[$a].name -eq $monsterInXML.trait[$b].name) { $actionRequired = $false; break; } } if($actionRequired) { $actionItem = $xmlFile.CreateElement("trait"); $monsterInXML.AppendChild($actionItem) | Out-Null; $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].trait[$a].name; $actionItem.AppendChild($item) | Out-Null; $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].trait[$a].text; $actionItem.AppendChild($item) | Out-Null; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed trait to $($sourceItem[$i].trait[$a].name)" -sLogType WARNING; } } }
                            if(($sourceItem[$i].reaction.Count) -ge 1) { for($a = 0; $a -lt $sourceItem[$i].reaction.Count; $a++) { $actionRequired = $true; for ($b = 0; $b -lt $monsterInXML.reaction.Count; $b ++) { if($sourceItem[$i].reaction[$a].name -eq $monsterInXML.reaction[$b].name) { $actionRequired = $false; break; } } if($actionRequired) { $actionItem = $xmlFile.CreateElement("reaction"); $monsterInXML.AppendChild($actionItem) | Out-Null; $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].reaction[$a].name; $actionItem.AppendChild($item) | Out-Null; $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].reaction[$a].text; $actionItem.AppendChild($item) | Out-Null; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed reaction to $($sourceItem[$i].reaction[$a].name)" -sLogType WARNING; } } }
                            if(($sourceItem[$i].legendary.Count) -ge 1) { for($a = 0; $a -lt $sourceItem[$i].legendary.Count; $a++) { $actionRequired = $true; for ($b = 0; $b -lt $monsterInXML.legendary.Count; $b ++) { if($sourceItem[$i].legendary[$a].name -eq $monsterInXML.legendary[$b].name) { $actionRequired = $false; break; } } if($actionRequired) { $actionItem = $xmlFile.CreateElement("legendary"); $monsterInXML.AppendChild($actionItem) | Out-Null; $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].legendary[$a].name; $actionItem.AppendChild($item) | Out-Null; $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].legendary[$a].text; $actionItem.AppendChild($item) | Out-Null; $logMSG | Create-LogEntry -sLogMsg "     [$($monsterInXML.Name)] changed legendary to $($sourceItem[$i].legendary[$a].name)" -sLogType WARNING; } } }
                        }
                    }
                    if($required)
                    {
                        $newMonsterElement = $xmlFile.CreateElement("monster")
                        $newMonster = $xmlFile.compendium.AppendChild($newMonsterElement)
                        $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].name; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("size"); $item.InnerXml = $sourceItem[$i].size; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("type"); $item.InnerXml = $sourceItem[$i].type.ToLower(); $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("alignment"); $item.InnerXml = $sourceItem[$i].alignment; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("ac"); $item.InnerXml = $sourceItem[$i].ac; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("hp"); $item.InnerXml = $sourceItem[$i].hp; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("speed"); $item.InnerXml = $sourceItem[$i].speed; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("init"); $item.InnerXml = $sourceItem[$i].init; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("str"); $item.InnerXml = $sourceItem[$i].str; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("dex"); $item.InnerXml = $sourceItem[$i].dex; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("con"); $item.InnerXml = $sourceItem[$i].con; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("int"); $item.InnerXml = $sourceItem[$i].int; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("wis"); $item.InnerXml = $sourceItem[$i].wis; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("cha"); $item.InnerXml = $sourceItem[$i].cha; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("save"); $item.InnerXml = $sourceItem[$i].save; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("skill"); $item.InnerXml = $sourceItem[$i].skill; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("vulnerable"); $item.InnerXml = $sourceItem[$i].vulnerable; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("resist"); $item.InnerXml = $sourceItem[$i].resist; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("immune"); $item.InnerXml = $sourceItem[$i].immune; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("conditionImmune"); $item.InnerXml = $sourceItem[$i].conditionImmune; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("senses"); $item.InnerXml = $sourceItem[$i].senses; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("passive"); $item.InnerXml = $sourceItem[$i].passive; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("languages"); $item.InnerXml = $sourceItem[$i].languages; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("cr"); $item.InnerXml = $sourceItem[$i].cr; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("slots"); $item.InnerXml = $sourceItem[$i].slots; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("spells"); $item.InnerXml = $sourceItem[$i].spells; $newMonster.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("environment"); $item.InnerXml = $sourceItem[$i].environment; $newMonster.AppendChild($item) | Out-Null 
                        for($a = 0; $a -lt $sourceItem[$i].trait.Count; $a++)
                        {
                            $item = $xmlFile.CreateElement("trait"); $newMonster.AppendChild($item) | Out-Null 
                                $TraitName = $xmlFile.CreateElement("name"); $TraitName.InnerXml = $sourceItem[$i].trait[$a].name; $item.AppendChild($TraitName) | Out-Null
                                $TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $sourceItem[$i].trait[$a].text; $item.AppendChild($TraitText) | Out-Null
                        }
                        if($sourceItem[$i].action.Count -ne $null)
                        {
                            for($a = 0; $a -lt $sourceItem[$i].action.Count; $a++)
                            {
                                $item = $xmlFile.CreateElement("action"); $newMonster.AppendChild($item) | Out-Null 
                                    $TraitName = $xmlFile.CreateElement("name"); $TraitName.InnerXml = $sourceItem[$i].action[$a].name; $item.AppendChild($TraitName) | Out-Null
                                    foreach($text in $sourceItem[$i].action[$a].text)
                                    {
                                        #$TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $sourceItem[$i].action[$a].text; $item.AppendChild($TraitText) | Out-Null
                                        #$text
                                        $TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $text; $item.AppendChild($TraitText) | Out-Null
                                    }
                                    foreach($attack in $sourceItem[$i].action[$a].attack)
                                    {
                                        #$TraitAttack = $xmlFile.CreateElement("attack"); $TraitAttack.InnerXml = $sourceItem[$i].action[$a].attack; $item.AppendChild($Traitattack) | Out-Null
                                        $TraitAttack = $xmlFile.CreateElement("attack"); $TraitAttack.InnerXml = $attack; $item.AppendChild($Traitattack) | Out-Null
                                    }
                            }
                        }
                        else
                        {
                            $item = $xmlFile.CreateElement("action"); $newMonster.AppendChild($item) | Out-Null 
                            $TraitName = $xmlFile.CreateElement("name"); $TraitName.InnerXml = $sourceItem[$i].action.name; $item.AppendChild($TraitName) | Out-Null
                            foreach($text in $sourceItem[$i].action.text)
                            {
                                #$TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $sourceItem[$i].action[$a].text; $item.AppendChild($TraitText) | Out-Null
                                #$text
                                $TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $text; $item.AppendChild($TraitText) | Out-Null
                            }
                            foreach($attack in $sourceItem[$i].action.attack)
                            {
                                #$TraitAttack = $xmlFile.CreateElement("attack"); $TraitAttack.InnerXml = $sourceItem[$i].action[$a].attack; $item.AppendChild($Traitattack) | Out-Null
                                $TraitAttack = $xmlFile.CreateElement("attack"); $TraitAttack.InnerXml = $attack; $item.AppendChild($Traitattack) | Out-Null
                            }

                        }
                        for($a = 0; $a -lt $sourceItem[$i].reaction.Count; $a++)
                        {
                            $item = $xmlFile.CreateElement("reaction"); $item.InnerXml = $sourceItem[$i].reaction; $newMonster.AppendChild($item) | Out-Null 
                                $TraitName = $xmlFile.CreateElement("name"); $TraitName.InnerXml = $sourceItem[$i].reaction[$a].name; $item.AppendChild($TraitName) | Out-Null
                                $TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $sourceItem[$i].reaction[$a].text; $item.AppendChild($TraitText) | Out-Null
                        }
                        for($a = 0; $a -lt $sourceItem[$i].legendary.Count; $a++)
                        {
                            $item = $xmlFile.CreateElement("legendary"); $newMonster.AppendChild($item) | Out-Null 
                                $TraitName = $xmlFile.CreateElement("name"); $TraitName.InnerXml = $sourceItem[$i].legendary[$a].name; $item.AppendChild($TraitName) | Out-Null
                                $TraitText = $xmlFile.CreateElement("text"); $TraitText.InnerXml = $sourceItem[$i].legendary[$a].text; $item.AppendChild($TraitText) | Out-Null
                        }
                        try
                        {
                            if(($sourceItem[$i].description) -ne $null) { $item = $xmlFile.CreateElement("description"); $item.InnerXml = $sourceItem[$i].description; $newMonster.AppendChild($item) | Out-Null }
                            else {  $item = $xmlFile.CreateElement("description"); $newMonster.AppendChild($item) | Out-Null  }
                        }
                        catch
                        {
                            Write-Host "description failed on $($sourceItem[$i].name)"
                        }
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            'Class' 
            {
                foreach($class in $source.compendium.class)
                {
                    $classdoesntExist = $true
                    foreach($xmlFileClass in $xmlFile.compendium.class)
                    {
                        #$xmlFileClass.name
                        if($xmlFile.compendium.class.Count -lt 1) { break }
                        else { if($class.name -eq $xmlFileClass.name) { 
                            if(($class.armor -ne $null) -and ($class.armor -ne $xmlFileClass.armor)) { $xmlFileClass.armor = $class.armor }
                            if(($class.hd -ne $null) -and ($class.hd -ne $xmlFileClass.hd)) { $xmlFileClass.hd = $class.hd }
                            if(($class.proficiency -ne $null) -and ($class.proficiency -ne $xmlFileClass.proficiency)) { $xmlFileClass.proficiency = $class.proficiency }
                            if(($class.spellAbility -ne $null) -and ($class.spellAbility -ne $xmlFileClass.spellAbility)) { $xmlFileClass.spellAbility = $class.spellAbility }
                            if(($class.numSkills -ne $null) -and ($class.numSkills -ne $xmlFileClass.numSkills)) { $xmlFileClass.numSkills = $class.numSkills }
                            if(($class.weapons -ne $null) -and ($class.weapons -ne $xmlFileClass.weapons)) { $xmlFileClass.weapons = $class.weapons }
                            if(($class.tools -ne $null) -and ($class.tools -ne $xmlFileClass.tools)) { $xmlFileClass.tools = $class.tools }
                            if(($class.wealth -ne $null) -and ($class.wealth -ne $xmlFileClass.wealth)) { $xmlFileClass.wealth = $class.wealth }

                            $autolevel = 1
                            do
                            {
                                $autolevelfromClass = $class.autolevel | Where-Object { $_.level -eq $autolevel }
                                if($autolevelfromClass -ne $null) 
                                {
                                    if(($autolevelfromClass.slots -ne $null) -and ($xmlFileClass.autolevel[$autolevel - 1].slots -eq $null))
                                    {
                                        if($autolevelfromClass.slots.optional -ne $null) 
                                        {
                                            $autolevelSlots = $xmlFile.CreateElement("slots")
                                            $xmlFileClass.autolevel[$autolevel - 1].AppendChild($autolevelSlots) | Out-Null
                                            $autolevelSlots.SetAttribute("optional", "YES")
                                            $autolevelSlots.InnerXml = $autolevelfromClass.slots.InnerXml
                                        }
                                        else 
                                        { 
                                            $autolevelSlots = $xmlFile.CreateElement("slots")
                                            $xmlFileClass.autolevel[$autolevel - 1].AppendChild($autolevelSlots) | Out-Null
                                            $autolevelSlots.InnerXml = $autolevelfromClass.slots
                                            $slots = $autolevelSlots.InnerXml.Trim()
                                            $autolevelSlots.InnerXml = $slots
                                        }
                                    }

                                    foreach  ($featureInAutoLevel in $autolevelfromClass.feature)                        
                                    {
                                        $featureRequired = $true
                                        foreach ($XmlFeature in $xmlFileClass.autolevel[$autolevel - 1].feature)
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
                                            $import = $xmlFile.compendium.OwnerDocument.ImportNode($featureInAutoLevel, 1)
                                            $xmlFileClass.autolevel[$autolevel - 1].AppendChild($import) | Out-Null
                                        }
                                    }

                                    foreach ($counterInAutoLevel in $autolevelfromClass.counter)
                                    {
                                        $counterRequired = $true
                                        if($counterInAutoLevel -eq $null) { $counterRequired = $false }
                                        foreach ($counterinXml in $xmlFileClass.autolevel[$autolevel -1].counter)
                                        {
                                            if($counterInAutoLevel.name -eq $counterinXml.name)
                                            {
                                                $counterRequired = $false
                                            }
                                        }
                                        if($counterRequired)
                                        {
                                            $counter = $xmlFile.compendium.OwnerDocument.ImportNode($counterInAutoLevel, 1)
                                            $xmlFileClass.autolevel[$autolevel -1].AppendChild($counter) | Out-Null
                                        }
                                    }
                                }
                                $autolevel++
                            }
                            until ($autolevel -gt 21)

                            $classdoesntExist = $false
                            break; 
                        } }
                    }
                    if($classdoesntExist)
                    {
                            $newClassElement = $xmlFile.CreateElement("class")
                            $classElement = $xmlFile.compendium.AppendChild($newClassElement)
                
                            $item = $xmlFile.CreateElement("name"); $item.InnerXml = $class.name; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("hd"); $item.InnerXml = $class.hd; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("proficiency"); $item.InnerXml = $class.proficiency; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("spellAbility"); $item.InnerXml = $class.spellAbility; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("numSkills"); $item.InnerXml = $class.numSkills; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("armor"); $item.InnerXml = $class.armor; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("weapons"); $item.InnerXml = $class.weapons; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("tools"); $item.InnerXml = $class.tools; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("wealth"); $item.InnerXml = $class.wealth; $classElement.AppendChild($item) | Out-Null 
                
                            $item = $xmlFile.CreateElement("slotsReset")
                                if($class.name -match "warlock") { $item.InnerXml = "S" } else { $item.InnerXml = "L" }
                                $classElement.AppendChild($item) | Out-Null

                            $index = 1
                            do
                            {
                                $item = $xmlFile.CreateElement("autolevel")
                                $classElement.AppendChild($item) | Out-Null
                                $item.SetAttribute("level", "$($index)")
                                switch ($index)
                                {
                                    '4' { $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                                    '6' { if($class.name -match "fighter") { $optional = $xmlFile.CreateAttribute("scoreImprovement"); $optional.InnerXml="YES"; $item.Attributes.Append($optional) | Out-Null } }
                                    '8' { $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                                    '12' { $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                                    '16' {  $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                                    '19' { $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null }
                                    Default {}
                                }

                                #$autolevelSlots = $xmlFile.CreateElement("slots")
                                #$item.AppendChild($autolevelSlots) | Out-Null

                                $autolevelfromClass = $class.autolevel | Where-Object { $_.level -eq $index }
                                if($autolevelfromClass -ne $null) 
                                {
                                    foreach ($autoLevelFeature in $autolevelfromClass.feature)
                                    {
                                        $feature = $xmlFile.CreateElement("feature"); $item.AppendChild($feature) | Out-Null; if($autoLevelFeature.optional -ne $null) { $feature.SetAttribute("optional", "YES") }

                                        $featureName = $xmlFile.CreateElement("name"); $featurename.InnerXml = $autoLevelFeature.name; $feature.AppendChild($featureName) | Out-Null

                                        foreach ($text in $autoLevelFeature.text) { $featureText = $xmlFile.CreateElement("text"); $featureText.InnerXml = $text; $feature.AppendChild($featureText) | Out-Null }
                                    }

                                    if($autoLevelFeature.counter -ne $null)
                                    {
                                        foreach($levelCounter in $autoLevelFeature.counter)
                                        {
                                            $counter = $xmlFile.compendium.OwnerDocument.ImportNode($levelCounter, 1)
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

<#
                $sourceItem = $source.compendium.class
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing class" -sLogType INFO
                    $logMSG | Create-LogEntry -sLogMsg "             $($sourceItem[$i].name)" -sLogType INFO
                    $newClassElement = $xmlFile.CreateElement("class")

                    if($xmlFile.compendium.class.count -le 0)
                    {
                        $index = 1
                        $newItemElement = $xmlFile.compendium.AppendChild($newClassElement)
                        $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].name; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("hd"); $item.InnerXml = $sourceItem[$i].hd; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("proficiency"); $item.InnerXml = $sourceItem[$i].proficiency; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("spellAbility"); $item.InnerXml = $sourceItem[$i].spellAbility; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("numSkills"); $item.InnerXml = $sourceItem[$i].numSkills; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("armor"); $item.InnerXml = $sourceItem[$i].armor; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("weapons"); $item.InnerXml = $sourceItem[$i].weapons; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("tools"); $item.InnerXml = $sourceItem[$i].tools; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("wealth"); $item.InnerXml = $sourceItem[$i].wealth; $newItemElement.AppendChild($item) | Out-Null 
                        $item = $xmlFile.CreateElement("slotsReset")
                            if(($sourceItem[$i].slotsReset) -ne $null) { $item.InnerXml = $sourceItem[$i].slotsReset; $newItemElement.AppendChild($item) | Out-Null }
                            elseif($sourceItem[$i].name -match "warlock") { $item.InnerXml = "S"; $newItemElement.AppendChild($item) | Out-Null }
                            else { $item.InnerXml = "S"; $newItemElement.AppendChild($item) | Out-Null }
                        $feature = $sourceItem[$i].autolevel  
                        do
                        {
                            $item = $xmlFile.CreateElement("autolevel")
                            $newItemElement.AppendChild($item) | Out-Null
                            $item.SetAttribute("level", "$($index)")
                            foreach ($f in $feature) 
                            {
                                if($f.level -eq $index)
                                {
                                    $import = $xmlFile.compendium.OwnerDocument.ImportNode($f.feature, 1)
                                    $item.AppendChild($import) | Out-Null
                                }
                            }
                            $index ++                                                      
                        }
                        until ($index -eq 21)
                        $logMSG | Create-LogEntry -sLogMsg "Created a new class: $($sourceItem[$i].name)" -sLogType INFO
                    }
                    else
                    {
                        foreach($c in $xmlFile.compendium.class)
                        {
                            $required = $true
                            if($c.name -eq $sourceItem[$i].name)
                            {
                                $logMSG | Create-LogEntry -sLogMsg "Found a matching class: $($sourceItem[$i].name)" -sLogType INFO
                                $required = $false
                                if($sourceItem[$i].hd -ne $null) { $c.hd = $sourceItem[$i].hd }
                                if($sourceItem[$i].proficiency -ne $null) { $c.proficiency = $sourceItem[$i].proficiency }
                                if($sourceItem[$i].spellAbility -ne $null) { $c.spellAbility = $sourceItem[$i].spellAbility }
                                if($sourceItem[$i].numSkills -ne $null) { $c.numSkills = $sourceItem[$i].numSkills }
                                if($sourceItem[$i].armor -ne $null) { $c.armor = $sourceItem[$i].armor }
                                if($sourceItem[$i].weapons -ne $null) { $c.weapons = $sourceItem[$i].weapons }
                                if($sourceItem[$i].tools -ne $null) { $c.tools = $sourceItem[$i].tools }
                                if($sourceItem[$i].wealth -ne $null) { $c.wealth = $sourceItem[$i].wealth }
                                if($sourceItem[$i].slotsReset -ne $null) { $c.slotsReset = $sourceItem[$i].slotsReset } else {if($c.name -match "warlock"){$c.slotsReset = "S"} else {$c.slotsReset = "L"}}
                                $feature = $sourceItem[$i].autolevel
                                $autolevel = $c.autolevel
                                $index = 1
                                do
                                {
                                    $level = $feature | Where-Object {$_.level -eq $index}
                                    $xmlAutolevel = $autolevel | Where-Object {$_.level -eq $index}
                                    foreach($levelfeature in $level.feature)
                                    {
                                        $featureRequired = $true
                                        foreach ($xmlAutoFeature in $xmlAutolevel.feature)
                                        {
                                            if($levelfeature.name -eq $xmlAutoFeature.name) { $featureRequired = $false; break }
                                        }
                                        if($featureRequired)
                                        {
                                            if($levelfeature -ne $null)
                                            {
                                                $import = $xmlFile.compendium.OwnerDocument.ImportNode($levelfeature, 1)
                                                $xmlAutolevel.AppendChild($import) | Out-Null
                                            }
                                        }
                                    }
                                    if($level.slots -ne $null)
                                    {
                                        foreach ($slot in $level.slots)
                                        {
                                            if($slot -ne $null)
                                            {
                                                $string = $slot
                                                $item = $xmlFile.CreateElement("slots")
                                                $xmlAutolevel.AppendChild($item) | Out-Null
                                                if($slot.optional -ne $null)
                                                {
                                                    $item.SetAttribute("optional", "YES")
                                                    $string = $slot.InnerXML
                                                }
                                                $item.InnerXML = $string
                                            }
                                        }
                                    }
                                    switch ($index)
                                    {
                                        '4' {if($xmlAutolevel.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$xmlAutolevel.Attributes.Append($optional) | Out-Null } }
                                        '6' {if($xmlAutolevel.scoreImprovement -eq $null){  if($sourceItem[$i].name -eq "fighter") { $optional = $xmlFile.CreateAttribute("scoreImprovement"); $optional.InnerXml="YES"; $xmlAutolevel.Attributes.Append($optional) | Out-Null } } }
                                        '8' {if($xmlAutolevel.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$xmlAutolevel.Attributes.Append($optional) | Out-Null } }
                                        '12' {if($xmlAutolevel.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$xmlAutolevel.Attributes.Append($optional) | Out-Null } }
                                        '16' {if($xmlAutolevel.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$xmlAutolevel.Attributes.Append($optional) | Out-Null } }
                                        '19' {if($xmlAutolevel.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$xmlAutolevel.Attributes.Append($optional) | Out-Null } }
                                        Default {}
                                    }
                                    $index ++ 
                                }
                                until ($index -eq 21)
                                break
                            }
                        }
                        if($required)
                        {
                            $index = 1
                            $newItemElement = $xmlFile.compendium.AppendChild($newClassElement)
                            $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].name; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("hd"); $item.InnerXml = $sourceItem[$i].hd; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("proficiency"); $item.InnerXml = $sourceItem[$i].proficiency; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("spellAbility"); $item.InnerXml = $sourceItem[$i].spellAbility; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("numSkills"); $item.InnerXml = $sourceItem[$i].numSkills; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("armor"); $item.InnerXml = $sourceItem[$i].armor; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("weapons"); $item.InnerXml = $sourceItem[$i].weapons; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("tools"); $item.InnerXml = $sourceItem[$i].tools; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("wealth"); $item.InnerXml = $sourceItem[$i].wealth; $newItemElement.AppendChild($item) | Out-Null 
                            $item = $xmlFile.CreateElement("slotsReset")
                                if(($sourceItem[$i].slotsReset) -ne $null) { $item.InnerXml = $sourceItem[$i].slotsReset; $newItemElement.AppendChild($item) | Out-Null }
                                elseif($sourceItem[$i].name -match "warlock") { $item.InnerXml = "S"; $newItemElement.AppendChild($item) | Out-Null }
                                else { $item.InnerXml = "S"; $newItemElement.AppendChild($item) | Out-Null }

                            $feature = $sourceItem[$i].autolevel
                            do
                            {
                                $item = $xmlFile.CreateElement("autolevel")
                                $newItemElement.AppendChild($item) | Out-Null
                                $item.SetAttribute("level", "$($index)")
                                foreach ($f in $feature) 
                                {
                                    if($f.level -eq $index)
                                    {
                                        foreach($iFeature in $f.feature)
                                        {
                                            $import = $xmlFile.compendium.OwnerDocument.ImportNode($iFeature, 1)
                                            $item.AppendChild($import) |Out-Null
                                        }
                                    }
                                    switch ($index)
                                    {
                                        '4' {if($item.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null } }
                                        '6' {if($item.scoreImprovement -eq $null){  if($sourceItem[$i].name -eq "fighter") { $optional = $xmlFile.CreateAttribute("scoreImprovement"); $optional.InnerXml="YES"; $item.Attributes.Append($optional) | Out-Null } } }
                                        '8' {if($item.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null } }
                                        '12' {if($item.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null } }
                                        '16' {if($item.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null } }
                                        '19' {if($item.scoreImprovement -eq $null){ $optional = $xmlFile.CreateAttribute("scoreImprovement");$optional.InnerXml="YES";$item.Attributes.Append($optional) | Out-Null } }
                                        Default {}
                                    }
                                }
                                $index ++                                                      
                            }
                            until ($index -eq 21)
                        }
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)"
#>
            }
            'Feat' 
            {
                $sourceItem = $source.compendium.feat
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing feat             $($sourceItem[$i].name)" -sLogType INFO
                    $featRequired = $true
                    foreach($featinXml in $xmlFile.compendium.feat)
                    {
                        if($featinXml.name -eq $sourceItem[$i].name)
                        {
                            $featRequired = $false
                        }
                    }
                    if($featRequired)
                    {
                        $import = $xmlFile.compendium.OwnerDocument.ImportNode($sourceItem[$i], 1)
                        $xmlFile.compendium.AppendChild($import) | Out-Null
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            'Item' 
            {
                $sourceItem = $source.compendium.item
                if($sourceItem.Count -ge 2)
                {
                    for ($i = 0; $i -lt $sourceItem.Count; $i++)
                    {
                        Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                        $logMSG | Create-LogEntry -sLogMsg "Processing item             $($sourceItem[$i].name)" -sLogType INFO
                        $itemRequired =$true                        
                        foreach ($itemInXML in $xmlfile.compendium.item)
                        {
                            if($itemInXML.name -eq $sourceItem[$i].name)
                            {
                                $itemRequired = $false
                            }
                        }
                        if($itemRequired)
                        {
                            $import = $xmlFile.compendium.OwnerDocument.ImportNode($sourceItem[$i], 1)
                            $xmlFile.compendium.AppendChild($import) | Out-Null
                        }
                    }
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
                }
            }
            'Container'
            {
                $sourceItem = $source.compendium.container
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing container             $($sourceItem[$i].name)" -sLogType INFO
                    $containerRequired = $true
                    foreach($containerXML in $xmlFile.compendium.container)
                    {
                        if($containerXML.name -eq $sourceItem[$i].name)
                        {
                            $containerRequired = $false
                        }
                    }
                    if($containerRequired)
                    {
                        $import = $xmlFile.compendium.OwnerDocument.ImportNode($sourceItem[$i], 1)
                        $xmlFile.compendium.AppendChild($import) | Out-Null
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            'Race' 
            {
                $sourceItem = $source.compendium.race
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing race             $($sourceItem[$i].name)" -sLogType INFO
                    $raceRequired = $true
                    foreach($raceinXML in $xmlFile.compendium.race)
                    {
                        if($raceinXML.name -eq $sourceItem[$i].name)
                        {
                            $raceRequired = $false
                        }
                    }
                    if($raceRequired)
                    {
                        $import = $xmlFile.compendium.OwnerDocument.ImportNode($sourceItem[$i], 1)
                        $xmlFile.compendium.AppendChild($import) | Out-Null
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            'Spell' 
            {
                $sourceItem = $source.compendium.spell
                for ($i = 0; $i -lt $sourceItem.Count; $i++)
                {
                    Write-Progress -Id 0 -Activity "Processing $($Component)" -Status "$($SourceFile.Name)" -PercentComplete (($i/$sourceItem.count) * 100)
                    $logMSG | Create-LogEntry -sLogMsg "Processing spell" -sLogType INFO
                    $logMSG | Create-LogEntry -sLogMsg "             $($sourceItem[$i].name) - $($sourceItem[$i].level) - $($sourceItem[$i].ritual) - $($sourceItem[$i].school) - $($sourceItem[$i].time) - $($sourceItem[$i].range) - $($sourceItem[$i].components) - $($sourceItem[$i].classes) - $($sourceItem[$i].text)" -sLogType INFO
                    $newSpellElement = $xmlFile.CreateElement("spell")
                    $newSpellComponentElement = $xmlFile.CreateElement("item")

                    if($xmlFile.compendium.spell.count -gt 0)
                    {
                        foreach($existingSpell in $xmlFile.compendium.spell)
                        {
                            $required = $true
                            if($existingSpell.name -eq $sourceItem[$i].name)
                            {
                                $required = $false
                                break;
                            }
                        }
                        if($required)
                        {
                            $newItemElement = $xmlFile.compendium.AppendChild($newSpellElement)
                            if($sourceItem[$i].name -ne $null) { $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].name; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].level -ne $null) { $item = $xmlFile.CreateElement("level"); $item.InnerXml = $sourceItem[$i].level; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].ritual -ne $null) { $item = $xmlFile.CreateElement("ritual"); $item.InnerXml = $sourceItem[$i].ritual; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].school -ne $null) { $item = $xmlFile.CreateElement("school"); $item.InnerXml = $sourceItem[$i].school; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].time -ne $null) { $item = $xmlFile.CreateElement("time"); $item.InnerXml = $sourceItem[$i].time; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].range -ne $null) { $item = $xmlFile.CreateElement("range"); $item.InnerXml = $sourceItem[$i].range; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].components -ne $null) { $item = $xmlFile.CreateElement("components"); $item.InnerXml = $sourceItem[$i].components; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].duration -ne $null) { $item = $xmlFile.CreateElement("duration"); $item.InnerXml = $sourceItem[$i].duration; $newItemElement.AppendChild($item) | Out-Null }
                            if($sourceItem[$i].classes -ne $null) { $item = $xmlFile.CreateElement("classes"); $item.InnerXml = $sourceItem[$i].classes; $newItemElement.AppendChild($item) | Out-Null }
                            if(($sourceItem[$i].text -ne $null) -and ($sourceItem[$i].text.Count -eq 1)) { $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].text; $newItemElement.AppendChild($item) | Out-Null }
                            elseif($sourceItem[$i].text.Count -gt 1)
                            {
                                foreach($text in $sourceItem[$i].text) 
                                {
                            
                                    if ($text -eq $null){ $item = $xmlFile.CreateElement("text"); $item.InnerXml = ""; $newItemElement.AppendChild($item) | Out-Null }
                                    else { $item = $xmlFile.CreateElement("text"); $item.InnerXml = $text.replace("&","and"); $newItemElement.AppendChild($item) | Out-Null }
                                }
                            }
                            if(($sourceItem[$i].components -ne $null) -and ($sourceItem[$i].components -match "M")) 
                            { 
                                if((($sourceItem[$i].components).Split("(")).Count -gt 1)
                                {
                                    $componentName = (($sourceItem[$i].components).Split("(")[1].replace(")", "").replace(", which the spell consumes","")).Trim()
                                    $required = $true
                                    foreach ($currentSpellComponent in $xmlFile.compendium.item)
                                    {
                                        if($currentSpellComponent.name -match $componentName) {$required = $false}
                                    }
                                    if($required)
                                    {
                                        $newItem = $xmlFile.compendium.AppendChild($newSpellComponentElement)
                                        $spellComponent = $xmlFile.CreateElement("name"); $spellComponent.InnerXml="Spell component, $($componentName)"; $newItem.AppendChild($spellComponent) | Out-Null
                                        $spellComponent = $xmlFile.CreateElement("type"); $spellComponent.InnerXml="G"; $newItem.AppendChild($spellComponent) | Out-Null
                                        $spellComponent = $xmlFile.CreateElement("value"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                                        $spellComponent = $xmlFile.CreateElement("weight"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                                        $spellComponent = $xmlFile.CreateElement("magic"); $spellComponent.InnerXml="0"; $newItem.AppendChild($spellComponent) | Out-Null
                                        $spellComponent = $xmlFile.CreateElement("text"); $spellComponent.InnerXml="[Spell Component] - $($componentName)"; $newItem.AppendChild($spellComponent) | Out-Null
                                    }
                                }
                            }
                            elseif($sourceItem[$i].components -match "M")
                            {
                                Write-Host "     Found Material Component for $($sourceItem[$i].name): $($sourceItem[$i].components) but the material isn't in the list" -ForegroundColor Cyan -BackgroundColor Black                                
                            }
                        }
                        else
                        {
                            #Write-Host -ForegroundColor Yellow "$($sourceItem[$i].name) exists already"
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Level
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Classes
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Ritual
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Text
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Components
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Duration
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Range
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging Time
                            Set-Element -XMLElementSource $existingSpell -XMLElementChange $sourceItem[$i] -ElementChanging School
                        }
                    }
                    else
                    {
                        $newItemElement = $xmlFile.compendium.AppendChild($newSpellElement)
                        if($sourceItem[$i].name -ne $null) { $item = $xmlFile.CreateElement("name"); $item.InnerXml = $sourceItem[$i].name; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].level -ne $null) { $item = $xmlFile.CreateElement("level"); $item.InnerXml = $sourceItem[$i].level; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].ritual -ne $null) { $item = $xmlFile.CreateElement("ritual"); $item.InnerXml = $sourceItem[$i].ritual; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].school -ne $null) { $item = $xmlFile.CreateElement("school"); $item.InnerXml = $sourceItem[$i].school; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].time -ne $null) { $item = $xmlFile.CreateElement("time"); $item.InnerXml = $sourceItem[$i].time; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].range -ne $null) { $item = $xmlFile.CreateElement("range"); $item.InnerXml = $sourceItem[$i].range; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].components -ne $null) { $item = $xmlFile.CreateElement("components"); $item.InnerXml = $sourceItem[$i].components; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].duration -ne $null) { $item = $xmlFile.CreateElement("duration"); $item.InnerXml = $sourceItem[$i].duration; $newItemElement.AppendChild($item) | Out-Null }
                        if($sourceItem[$i].classes -ne $null) { $item = $xmlFile.CreateElement("classes"); $item.InnerXml = $sourceItem[$i].classes; $newItemElement.AppendChild($item) | Out-Null }
                        if(($sourceItem[$i].text -ne $null) -and ($sourceItem[$i].text.Count -eq 1)) { $item = $xmlFile.CreateElement("text"); $item.InnerXml = $sourceItem[$i].text; $newItemElement.AppendChild($item) | Out-Null }
                        elseif($sourceItem[$i].text.Count -gt 1)
                        {
                            foreach($text in $sourceItem[$i].text) 
                            {
                            
                                if ($text -eq $null){ $item = $xmlFile.CreateElement("text"); $item.InnerXml = ""; $newItemElement.AppendChild($item) | Out-Null }
                                else { $item = $xmlFile.CreateElement("text"); $item.InnerXml = $text.replace("&","and"); $newItemElement.AppendChild($item) | Out-Null }
                            }
                        }
                        if(($sourceItem[$i].components -ne $null) -and ($sourceItem[$i].components -match "M")) 
                        { 
                            Write-Host "Found Material Component for $($sourceItem[$i].name): $($sourceItem[$i].components)"
                            #$comp = ($sourceItem[$i].components).Split(" m ")
                        }
                    }
                }
                Write-Progress -Id 0 -Activity "Processing $($Component)" -Completed
            }
            Default 
            {
                $sourceItem = $source.compendium
                $sourceItem.Count
                $sourceItem
            }
        }
    }
    End
    {
        $xmlFile = $null
        $logMSG.sComponent = $tempComponent
    }
}

# /********************************************************************************
# *                            Script Main                                        *
# ********************************************************************************/
$temp = $null
for ($i = 0; $i -lt (($MyInvocation.InvocationName.Split("\")).Count -2); $i++)
{
    if($temp -eq $null) { $temp = "$(($MyInvocation.InvocationName.Split("\"))[$i])" }
    else { $temp += "\$(($MyInvocation.InvocationName.Split("\"))[$i])" }
}

$array = @{
  sComponent = "$(($MyInvocation.MyCommand.Name).Split('.')[0])"
  sLogFile = "$($temp)\Logs\$(($MyInvocation.MyCommand.Name).Split('.')[0])_$(Get-Date -Format yyyy-MM-dd).log"
  sLogMsg = "$($MyInvocation.MyCommand.Name) has started"
  sLogType = "INFO"
}
$logMSG = New-Object -TypeName psobject -Property $array

$logMSG | Create-LogEntry -sLogType INFO

$file = Collect-XMLFiles -SourceFolder "$($temp)\Sources"
$progress = 0
foreach($item in $file)
{
    Write-Progress -Id 1 -Activity "Overall Progress" -Status "Working on $($item.Name)" -PercentComplete (($progress/$file.Count)*100)
    $logMSG | Create-LogEntry -sLogMsg "Processing File: $($item.Name)" -sLogType WARNING
    Create-XMLFile -Component Spell -SourceFile $item 
    Create-XMLFile -Component Race -SourceFile $item
    Create-XMLFile -Component Class -SourceFile $item 
    Create-XMLFile -Component Item -SourceFile $item
    Create-XMLFile -Component Feat -SourceFile $item
    Create-XMLFile -Component Background -SourceFile $item
    Create-XMLFile -Component Monster -SourceFile $item
    Create-XMLFile -Component Container -SourceFile $item
    $progress++
}
Write-Progress -Id 1 -Activity "Overall Progress" -Completed

foreach($spell in $xmlFile.compendium.spell)
{
    if((($spell.level -match "1") -or ($spell.level -match "2") -or ($spell.level -match "3")) -and ($spell.name -notmatch "\*") -and ($spell.name -notmatch "\[") -and ($spell.classes -match ("wizard")) )
    {
        $import = $xmlFile.compendium.OwnerDocument.ImportNode($spell,1)
        if((($spell.level -match "1") -or ($spell.level -match "2")) -and ($spell.name -notmatch "\["))
        {
            $import.name += " [Spell Mastery]"
            $import.classes = "Wizard (Spell Mastery)"
            $text = $xmlFile.CreateElement("text")
            $text2 = $xmlFile.CreateElement("text")
            $import.AppendChild($text2) | Out-Null
            $newText = $import.AppendChild($text) | Out-Null
            $text.InnerXML = "[Spell Mastery] You can cast this spell at its lowest level without expending a spell slot, when you have it prepared."
        }
        if(($spell.level -match "3") -and ($spell.name -notmatch "\["))
        {
            $import.name += " [Signature Spell]"
            $import.classes = "Wizard (Signature Spell)"
            $text = $xmlFile.CreateElement("text")
            $text2 = $xmlFile.CreateElement("text")
            $import.AppendChild($text2) | Out-Null
            $newText = $import.AppendChild($text) | Out-Null
            $text.InnerXML = "[Signature Spell] You always have this spell prepared, and it doesn't count against the number of spells you have prepared.  Once per rest, you can cast this spell at 3rd level without expending a spell slot."
        }
        $xmlFile.compendium.AppendChild($import) | Out-Null
    }
}

$xmlFile.compendium.spell | sort level | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort ritual | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort school | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort time | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort range | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort componets | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort duration | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort classes | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.race | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.background | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.class | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.Feat | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.item | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.container | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.monster | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}

foreach ($class in $xmlFile.compendium.class)
{
    foreach ($autolevel in $class.autolevel)
    {
        [System.Xml.XmlNode]$test = $autolevel
        $test.feature | sort name | foreach {[void]$autolevel.AppendChild($_)}
    }
}

$xmlFile.Save("$($temp)\Complete\temp.xml")
$xmlFile.Save("C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\_Complete.xml")
$logMSG | Create-LogEntry -sLogMsg "$($MyInvocation.MyCommand.Name) has completed" -sLogType INFO

[xml] $content = Get-Content -Path "C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\_Complete.xml" -Encoding UTF8
$class = $content.compendium.class
foreach ($objClass in $class)
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
$monster = $content.compendium.monster
foreach ($objMonster in $monster)
{
    foreach($trait in $objMonster.trait)
    {
        if([string]::IsNullOrEmpty($trait.name))
        {
            $trait.ParentNode.RemoveChild($trait) | Out-Null
        }
    }
    foreach($action in $objMonster.action)
    {
        if([string]::IsNullOrEmpty($action.name))
        {
            $action.ParentNode.RemoveChild($action) | Out-Null
        }
    }
}
$content.Save("C:\Users\wfischbeck\OneDrive\Documents\Dungeon & Dragons\xml_Sheets\Complete\_Complete.xml")
$content.Save("$($temp)\Complete\temp.xml")
#Clear-Host
Write-Host "`r`n`r`n"
Write-Host "There are a total of $($xmlFile.compendium.spell.count) spell(s)"
Write-Host "There are a total of $($xmlFile.compendium.class.Count) class(es)"
Write-Host "There are a total of $($xmlFile.compendium.background.Count) background(s)"
Write-Host "There are a total of $($xmlFile.compendium.feat.Count) feat(s)"
Write-Host "There are a total of $($xmlFile.compendium.item.Count) item(s)"
Write-Host "There are a total of $($xmlFile.compendium.container.Count) containers(s)"
Write-Host "There are a total of $($xmlFile.compendium.race.Count) race(s)"
Write-Host "There are a total of $($xmlFile.compendium.monster.Count) monster(s)"

$stopwatch.Stop()
Write-Host "Script took $(($stopwatch.Elapsed).Minutes) minutes(s) and $(($stopwatch.Elapsed).Seconds) second(s) to complete"