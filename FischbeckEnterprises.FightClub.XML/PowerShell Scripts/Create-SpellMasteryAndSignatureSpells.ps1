﻿[Reflection.Assembly]::LoadWithPartialName("System.Xml.Linq") | Out-Null
[xml]$xmlFile = @"
<?xml version="1.0" encoding="UTF-8"?>
<compendium version="5">
</compendium>  
"@


[xml]$content = Get-Content -Path C:\Users\wfischbeck\source\repos\DDCM\FischbeckEnterprises.FightClub.XML\Complete\temp.xml

$spells = $content.compendium.spell

foreach($spell in $spells)
{
    if((($spell.level -match "1") -or ($spell.level -match "2") -or ($spell.level -match "3")) -and ($spell.name -notmatch "\*") -and ($spell.name -notmatch "\[") -and ($spell.classes -match ("wizard")) )
    {
        if((($spell.level -match "1") -or ($spell.level -match "2")) -and ($spell.name -notmatch "\["))
        {
            $spell.name += " [Spell Mastery]"
            $spell.classes = "Wizard (Spell Mastery)"
            $text = $content.CreateElement("text")
            $text2 = $content.CreateElement("text")
            $spell.AppendChild($text2)
            $newText = $spell.AppendChild($text)
            $newText.InnerXML = "[Spell Mastery] You can cast this spell at its lowest level without expending a spell slot, when you have it prepared."
        }
        if(($spell.level -match "3") -and ($spell.name -notmatch "\["))
        {
            $spell.name += " [Signature Spell]"
            $spell.classes = "Wizard (Signature Spell)"
            $text = $content.CreateElement("text")
            $text2 = $content.CreateElement("text")
            $spell.AppendChild($text2)
            $newText = $spell.AppendChild($text)
            $newText.InnerXML = "[Signature Spell] You always have this spell prepared, and it doesn't count against the number of spells you have prepared.  Once per rest, you can cast this spell at 3rd level without expending a spell slot."
        }
        $import = $xmlFile.compendium.OwnerDocument.ImportNode($spell,1)
        $xmlFile.compendium.AppendChild($import)
    }
}

$xmlFile.compendium.spell | sort Name | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort level | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort ritual | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort school | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort time | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort range | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort componets | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort duration | % {[void]$xmlFile.compendium.AppendChild($_)}
$xmlFile.compendium.spell | sort classes | % {[void]$xmlFile.compendium.AppendChild($_)}

$xmlFile.Save("C:\Users\wfischbeck\source\repos\DDCM\FischbeckEnterprises.FightClub.XML\Sources\Spells-Wizard-HighLevel.xml")