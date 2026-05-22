$phonePattern = '^(\d{3}-|\(\d{3}\) )\d{3}-\d{4}$'
Get-Content $PSScriptRoot\file.txt `
    | Select-String $phonePattern `
    | ForEach-Object { $_.Line } 