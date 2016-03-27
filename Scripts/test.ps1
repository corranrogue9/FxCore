$packagePath = [System.IO.Path]::GetFullPath($args[0])
$outputPath = [System.IO.Path]::GetFullPath($args[1])
if ($args[2] -ne $null)
{
    $testSettings = [System.IO.Path]::GetFullPath($args[2])
    $testSettings = "/testsettings:$testSettings"
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
            $frameworks = Get-ChildItem -Path $architecturePath -Directory
            ForEach ($framework in $frameworks)
            {
                $frameworkPath = Join-Path -Path $architecturePath -ChildPath $framework

                $binaries = Get-ChildItem -Path $frameworkPath -Filter *.dll
                $testContainers = ""
                ForEach ($binary in $binaries)
                {
                    $testContainer = Join-Path $frameworkPath -ChildPath $binary
                    $testContainers = "$testContainers/testcontainer:$testContainer "
                }

                $resultDirectory = Join-Path $outputPath -ChildPath (Join-Path $project -ChildPath (Join-Path $configuration -ChildPath (Join-Path $architecture -ChildPath $framework)))
                New-Item -ItemType Directory -Force -Path $resultDirectory | out-null

                $resultName = "Test"
                For ($i = 1; Test-Path -LiteralPath (Join-Path $resultDirectory -ChildPath $resultName); $i++)
                {
                    $resultName = "Test[$i]"
                }

                $resultPath = Join-Path $resultDirectory -ChildPath "$resultName.trx"
                $logPath = Join-Path $resultDirectory -ChildPath "$resultName.txt"
                $output = Invoke-Expression "mstest $testContainers /resultsfile:$resultPath $testSettings 2>&1"
                if ($LASTEXITCODE -ne 0)
                {
                    $output | Out-File -LiteralPath $logPath
                    Invoke-Expression "type $logPath"
                }
                else
                {
                    $output | Out-File -LiteralPath $logPath
                }
            }
        }
    }
}