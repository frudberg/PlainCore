#################################################################################################
# Use this script to rename the VS Solution to a custom name.                                   
# Will take care of renaming all namespaces as well as file content                             
#
# Fredrik Rudberg 2018-05-13
#################################################################################################

$TemplateName = "PlainCore"
$CodeFolder = "Source"

Write-Host "!! Important !! Run this script in the indended root folder of the template only !! " -ForegroundColor red
Write-Host "Write new name of VS Solution : " -ForegroundColor Yellow -NoNewline
$NewName = Read-Host

Set-Location -Path $CodeFolder -PassThru

if (-not ([string]::IsNullOrEmpty($NewName)))
{
    Get-ChildItem -r | Where {$_.name -clike "*$TemplateName*"} | Rename-Item -NewName {$_.name -creplace "$TemplateName", "$NewName" }
    Get-ChildItem  -Filter *.* -File -Recurse  | Foreach-Object {       
        $c = ($_ | Get-Content)        
        If ($c | Select-String -Pattern "$TemplateName") {
        $c = $c -creplace "$TemplateName","$NewName"       
        [IO.File]::WriteAllText($_.FullName, ($c -join "`r`n")) }
    }
}