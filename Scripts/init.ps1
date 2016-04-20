$repoRoot = [System.IO.Path]::GetFullPath($args[0])
$nugetPath = [System.IO.Path]::GetFullPath($args[1])

$output = Invoke-Expression "$nugetPath restore $repoRoot 2>&1"
if ($LASTEXITCODE -ne 0)
{
    $output
}