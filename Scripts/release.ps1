$packagePath = [System.IO.Path]::GetFullPath($args[0])
$outputPath = [System.IO.Path]::GetFullPath($args[1])
$version = $args[2]
$nugetPath = $args[3]
$nugetSource = $args[4]
if ($nugetSource -eq $null)
{
    $nugetSource = Join-Path -Path $outputPath -ChildPath "source"
}
else
{
    $nugetSource = [System.IO.Path]::GetFullPath($nugetSource)
}

$projects = Get-ChildItem -Path $packagePath
ForEach ($project in $projects)
{
    $projectPath = Join-Path -Path $packagePath -ChildPath $project
    $configurations = Get-ChildItem -Path $projectPath
    ForEach ($configuration in $configurations)
    {
        $configurationPath = Join-Path -Path $projectPath -ChildPath $configuration
        $architectures = Get-ChildItem -Path $configurationPath
        ForEach ($architecture in $architectures)
        {
            $architecturePath = Join-Path -Path $configurationPath -ChildPath $architecture
	        $nuspecPath = Join-Path -Path $architecturePath -ChildPath "$project.nuspec"

            New-Item -ItemType Directory -Force -Path $outputPath | out-null
            $finalConfiguration = ""
            $finalArchitecture = ""
	        if ($configuration.Name.CompareTo("Release") -ne 0 -Or $architecture.Name.CompareTo("AnyCPU") -ne 0)
	        {
   	            $finalConfiguration = ".$configuration"
                $finalArchitecture = ".$architecture"
            }

            $prefix = "$project$finalConfiguration$finalArchitecture.$version"
            $packLogPath = Join-Path $outputPath -ChildPath "$prefix.pack.txt"
	        Invoke-Expression "$nugetPath pack $nuspecPath -properties debug=$finalConfiguration -properties architecture=$finalArchitecture -properties version=$version -OutputDirectory $outputPath > $packLogPath 2>&1"
            if ($LASTEXITCODE -ne 0)
            {
                Invoke-Expression "type $packLogPath"
            }

            $pushLogPath = Join-Path $outputPath -ChildPath "$prefix.push.txt"
            $nupkgPath = Join-Path $outputPath -ChildPath "Fx.$prefix.nupkg"
	        Invoke-Expression "$nugetPath push $nupkgPath -Source $nugetSource > $pushLogPath 2>&1"
            if ($LASTEXITCODE -ne 0)
            {
                Invoke-Expression "type $pushLogPath"
            }
        }
    }
}