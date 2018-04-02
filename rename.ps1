Get-ChildItem -r | Where {$_.name -clike "*PlainCore*"} | Rename-Item -NewName {$_.name -creplace "PlainCore", "PlainCore" }

Get-ChildItem  -Filter *.* -File -Recurse  | Foreach-Object {       

$c = ($_ | Get-Content)        

If ($c | Select-String -Pattern "PlainCore") {

$c = $c -creplace "PlainCore","PlainCore"       

[IO.File]::WriteAllText($_.FullName, ($c -join "`r`n")) }

}