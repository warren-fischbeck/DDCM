$sw = [Diagnostics.Stopwatch]::StartNew()

$scriptPath = $MyInvocation.MyCommand.path.substring(0,($MyInvocation.MyCommand.path.Length - ($MyInvocation.MyCommand.Name.Length) -1 ))
#$beastFile = "$($scriptPath)\Complete\beast.xml"
$beastFile = "$($scriptPath)\Complete\_Complete.xml"

$monsters = @()
$count = 83
for ($i = 1; $i -lt $count; $i++)
{ 
    $name = $null
    $uri = "Https://www.dndbeyond.com/monsters?page=$($i)"
    $response = Invoke-WebRequest -Uri $uri
    $html = New-Object -ComObject "HTMLFile"
    $html.ihtmldocument2_Write($response.Content)
    $line = 0
    foreach ($item in $html.getElementsByTagName("div") )
    {
        $line ++
        Write-Progress -Id 0 -Activity "Processing $($i) of $($count)" -Status "Working on line $($line) of $($html.getElementsByTagName("div").length)" -PercentComplete (($line/($html.getElementsByTagName("div").length))*100)
        foreach($attrib in $item.attributes) 
        {
            
            if($attrib.nodename -eq "data-slug") 
            { 
                $name = ([string]$attrib.textContent).Replace('-', " ")
                #$name
                #$attrib
                if($item.innerHTML.Contains('class="row monster-envi'))
                {
                    foreach($child in $item.children)
                    {
                        if($child.className -match "row monster-envi")
                        {
                            foreach($span in $child.children)
                            {
                                if($span.title -ne $null)
                                {
                                    $envirn = $span.title
                                }
                                else
                                {
                                    $envirn = $span.innerText
                                }
                                $monsters += New-Object -TypeName psobject -Property @{
                                    name = $name
                                    environment = $envirn
                                }
                            }                        
                        }
                    }
                }
            }
        }
    }
    $wait = 10
    for($t=1;$t -le $wait; $t ++)
    {
        Write-Progress -Id 1 -Activity "Sleeping for $($wait) seconds" -Status "On second $($t)" -PercentComplete (($t/$wait)*100) 
        Start-Sleep -Seconds 1
    }
    Write-Progress -Id 1 -Activity "Sleeping for 10 seconds" -Completed
    Write-Progress -Id 0 -Activity "Processing $($i) of $($count)" -Completed
}

[xml] $beast = Get-Content -Path $beastFile
[System.Xml.XmlElement] $colXMLItem = $beast.compendium

$count = 0
foreach($monster in $colXMLItem.monster)
{
    $count ++
    Write-Progress -Id 0 -Activity "Processing Monster $($count) of $($colXMLItem.monster.Count)" -Status "Monster: $($monster.name)" -PercentComplete (($count/$colXMLItem.monster.Count)*100)
    $monsterName = $monster.name
    foreach ($m in $monsters)
    {
        if($m.name -eq $monsterName)
        {
            $monster.environment = $m.environment
        }
    }
    $beast.Save($beastFile)
}
Write-Progress -Id 0 -Activity "Processing Monster $($count) of $($colXMLItem.monster.Count)" -Completed

$sw.Stop()
Write-Host "It took $($sw.Elapsed.Minutes) minute(s) and $($sw.Elapsed.Seconds) seconds to run."