Get-Content $PSScriptRoot\words.txt `
    | ForEach-Object { $_ -split '\s+' } `
    | Where-Object { $_ -ne '' } `
    | Group-Object `
    | Sort-Object Count -Descending `
    | ForEach-Object { "$($_.Name) $($_.Count)" }