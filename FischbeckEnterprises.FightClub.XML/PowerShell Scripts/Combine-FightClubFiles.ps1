[xml]$MasterXML = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5" auto_indent="NO">
<spell>
<classes />
<components />
<duration />
<level />
<name />
<range />
<ritual />
<school />
<time />
<text />
</spell>
<race>
<ability />
<name />
<proficiency />
<size />
<speed />
<spellAbility />
<trait>
<name />
<text />
</trait>
</race>
<background>
<name />
<proficiency />
<trait>
<name />
<text />
</trait>
</background>
<class>
<name />
<hd />
<proficiency />
<spellAbility />
<numSkills />
<armor />
<weapons />
<tools />
<wealth />
<slotsReset />
<autolevel level="1">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="2">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="3">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="4" scoreImprovement="YES">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="5">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="6">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="7">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="8" scoreImprovement="YES">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="9">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="10">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="11">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="12" scoreImprovement="YES">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="13">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="14">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="15">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="16" scoreImprovement="YES">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="17">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="18">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="19" scoreImprovement="YES">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
<autolevel level="20">
<feature>
<name />
<text />
</feature>
<feature optional="YES">
<name />
<text/>
</feature>
</autolevel>
</class>
<feat>
<name />
<prerequisite />
<text />
<modifier category=""></modifier>
</feat>
<item>
<name />
<type />
<value />
<weight />
<magic />
<text />
<modifier category="" />
</item>
<monster>
<name />
<size />
<type />
<alignment />
<ac />
<hp />
<speed />
<str />
<dex />
<con />
<int />
<wis />
<cha />
<save />
<skill />
<passive />
<languages />
<cr />
<resist />
<immune />
<vulnerable />
<conditionImmune />
<senses />
<trait>
<name />
<text />
</trait>
<action>
<name />
<text />
</action>
<slots />
<spells />
<description />
<environment />
</monster>
</compendium>
"@
[xml]$combinedFileXML = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5" auto_indent="NO">
</compendium>  
"@
$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()
$SourceXMLFileBackground = $null 
$SourceXMLFileMonster = $null
$SourceXMLFileClass = $null
$SourceXMLFileFeat = $null
$SourceXMLFile = $null
$SourceXMLFileRace = $null
$SourceXMLFileContainer = $null

Function Combine-Spell
{
    Param 
    (
        $SourceXMLSpell
    )
    Begin
    { 
        <#
        $newSpell = $MasterXML.compendium.spell.Clone()
        $newSpell.Name = "$($SourceXMLSpell.spell[$b].name)"
        $combinedFileXML.compendium.AppendChild($combinedFileXML.compendium.OwnerDocument.ImportNode($newSpell, 1) )
        $combinedFileXML.compendium.spell
        #>
    }
    Process
    {
        if($SourceXMLSpell.Count -eq 1) { $SourceXMLSpell  }

    }
    End
    {
    }
}

Function Start-XMLFileProcess
{
    Param 
    (
        [xml]$SourceXMLFile
    )
    Begin
    {
        $SourceXMLFileBackground = $null 
        $SourceXMLFileMonster = $null
        $SourceXMLFileClass = $null
        $SourceXMLFileFeat = $null
        $SourceXMLFileRace = $null
        $SourceXMLFileContainer = $null
    }
    Process
    {
        if( $SourceXMLFile.compendium.spell.Count -ge 1 ) { Combine-Spell -SourceXMLSpell $SourceXMLFile.compendium.spell } else { Write-Host "No spell found in $($objSourceFile.Name)" } 
    }
    End
    {
    }
}

$temp = $null
for ($i = 0; $i -lt (($MyInvocation.InvocationName.Split("\")).Count -2); $i++)
{
    if($temp -eq $null) { $temp = "$(($MyInvocation.InvocationName.Split("\"))[$i])" }
    else { $temp += "\$(($MyInvocation.InvocationName.Split("\"))[$i])" }
}
$colSourceFile = Get-ChildItem -Path "$($temp)\Sources" -Recurse -Include *.xml
$colSourceFile = $colSourceFile | select -Property name,fullname,length | sort -Descending -Property length

foreach ($objSourceFile in $colSourceFile)
{
    Write-Host "$($objSourceFile.FullName)`n     Length - $($objSourceFile.Length)"
    Start-XMLFileProcess -SourceXMLFile (Get-Content -Path ($objSourceFile.FullName) -Encoding UTF8)
}


$combinedFileXML.Save('C:\Temp\Temp.xml')
$stopwatch.Stop()
Write-Host "Script took $(($stopwatch.Elapsed).Minutes) minutes(s) and $(($stopwatch.Elapsed).Seconds) second(s) to complete"