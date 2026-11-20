<#
.SYNOPSIS
    Extracts BenchmarkDotNet result tables from a BenchmarkDotNet.Artifacts folder.

.DESCRIPTION
    Every class run by BenchmarkDotNet writes its Markdown result table twice: next to the
    reports in results/<Class>-report-github.md and inside the console log
    <Class>-<yyyyMMdd>-<HHmmss>.log. This script reads both, normalises the units
    (ms for time, KB for allocation) and emits two CSV files:

        measurements-all.csv      one row per measurement, for every run found in the folder
        measurements-latest.csv   one row per (date, class, method), latest run of each date

    The decimal separator in the output is always '.' (invariant culture), independent of
    the host culture, so the files can be consumed by any spreadsheet or script.

.PARAMETER Artifacts
    Path to the BenchmarkDotNet.Artifacts folder that contains the .log files.

.PARAMETER Out
    Output folder for the CSV files. Defaults to the current directory.

.EXAMPLE
    pwsh tools/parse-bdn-artifacts.ps1 -Artifacts .\Benchmarks.Runner.Net8.SqlServer\bin\Release\net8.0\BenchmarkDotNet.Artifacts -Out .\docs\results
#>

param(
    [Parameter(Mandatory = $true)]
    [string]$Artifacts,
    [string]$Out = '.'
)

function Convert-TimeToMs([string]$text) {
    if ([string]::IsNullOrWhiteSpace($text) -or $text.Trim() -eq '-') { return $null }
    $t = $text.Trim() -replace ',', ''
    $m = [regex]::Match($t, '^([0-9]*\.?[0-9]+)\s*(\S+)$')
    if (-not $m.Success) { return $null }
    $v = [double]::Parse($m.Groups[1].Value, [cultureinfo]::InvariantCulture)
    $u = $m.Groups[2].Value.ToLowerInvariant()
    if ($u -eq 'ns') { return $v / 1e6 }
    if ($u -eq 'ms') { return $v }
    if ($u -eq 's')  { return $v * 1e3 }
    return $v / 1e3   # us, with either micro sign
}

function Convert-SizeToKB([string]$text) {
    if ([string]::IsNullOrWhiteSpace($text) -or $text.Trim() -eq '-') { return $null }
    $t = $text.Trim() -replace ',', ''
    $m = [regex]::Match($t, '^([0-9]*\.?[0-9]+)\s*(B|KB|MB|GB)$')
    if (-not $m.Success) { return $null }
    $v = [double]::Parse($m.Groups[1].Value, [cultureinfo]::InvariantCulture)
    $u = $m.Groups[2].Value
    if ($u -eq 'B')  { return $v / 1KB }
    if ($u -eq 'KB') { return $v }
    if ($u -eq 'MB') { return $v * 1024 }
    if ($u -eq 'GB') { return $v * 1024 * 1024 }
}

function Format-Number($value) {
    if ($null -eq $value) { return '' }
    return ([double]$value).ToString('0.####', [cultureinfo]::InvariantCulture)
}

function Clean-MethodName([string]$raw) {
    $s = $raw.Trim()
    $s = $s -replace '&#39;', "'"
    $s = $s -replace "^'", ''
    $s = $s -replace "'$", ''
    return $s.Trim()
}

$rows = New-Object System.Collections.Generic.List[object]

foreach ($file in Get-ChildItem $Artifacts -Filter '*.log' -File) {
    $fileMatch = [regex]::Match($file.Name, '\.([A-Za-z0-9_]+)-(\d{8})-(\d{6})\.log$')
    if (-not $fileMatch.Success) { continue }
    $className = $fileMatch.Groups[1].Value
    $runDate   = $fileMatch.Groups[2].Value
    $runTime   = $fileMatch.Groups[3].Value

    $lines = Get-Content $file.FullName
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -notmatch '^\|\s*Method\s*\|') { continue }

        $header = @($lines[$i].Trim().Trim('|').Split('|') | ForEach-Object { $_.Trim() })
        if (-not ($header -contains 'Mean')) { continue }

        $j = $i + 1
        if ($j -lt $lines.Count -and $lines[$j] -match '^\|[\s\-:|]+\|') { $j++ }

        while ($j -lt $lines.Count -and $lines[$j].TrimStart().StartsWith('|')) {
            $cells = @($lines[$j].Trim().Trim('|').Split('|') | ForEach-Object { $_.Trim() })
            if ($cells.Count -eq $header.Count) {
                $record = @{}
                for ($k = 0; $k -lt $header.Count; $k++) { $record[$header[$k]] = $cells[$k] }

                $rows.Add([pscustomobject]@{
                    RunDate    = $runDate
                    RunTime    = $runTime
                    Class      = $className
                    Method     = (Clean-MethodName $cells[0])
                    Mean_ms    = (Format-Number (Convert-TimeToMs $record['Mean']))
                    Error_ms   = (Format-Number (Convert-TimeToMs $record['Error']))
                    StdDev_ms  = (Format-Number (Convert-TimeToMs $record['StdDev']))
                    Median_ms  = (Format-Number (Convert-TimeToMs $record['Median']))
                    Alloc_KB   = (Format-Number (Convert-SizeToKB $record['Allocated']))
                    SourceFile = $file.Name
                })
            }
            $j++
        }
        $i = $j
    }
}

if ($rows.Count -eq 0) {
    Write-Error "No BenchmarkDotNet tables found under '$Artifacts'."
    exit 1
}

$rows | Export-Csv -Path (Join-Path $Out 'measurements-all.csv') -NoTypeInformation -Encoding UTF8

$latest = $rows | Group-Object RunDate, Class, Method | ForEach-Object {
    $_.Group | Sort-Object RunTime -Descending | Select-Object -First 1
}
$latest | Sort-Object RunDate, Class, Method | Export-Csv -Path (Join-Path $Out 'measurements-latest.csv') -NoTypeInformation -Encoding UTF8

Write-Host ("measurements-all.csv     : {0} rows" -f $rows.Count)
Write-Host ("measurements-latest.csv  : {0} rows" -f @($latest).Count)
Write-Host ("classes                  : {0}" -f (($rows | Select-Object -ExpandProperty Class -Unique).Count))
