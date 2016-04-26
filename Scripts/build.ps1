$repoRoot = [System.IO.Path]::GetFullPath($args[0])
$packagePath = [System.IO.Path]::GetFullPath($args[1])

$configurations = "Debug","Release"
$architectures = "AnyCPU","x86"
$frameworks = "NET30","NET35","NET40","NET45","NET46"

ForEach ($configuration in $configurations)
{
    ForEach ($architecture in $architectures)
    {
        ForEach ($framework in $frameworks)
        {
            $output = Invoke-Expression "msbuild $repoRoot /t:Clean /t:Rebuild /property:Configuration=$configuration /property:Platform=$architecture.$framework 2>&1"
            if ($LASTEXITCODE -ne 0)
            {
                $output
            }
        }
    }
}