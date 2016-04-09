set PackagePath=%~1
set OutputPath=%~2
set VersionNumber=%3
set NugetPath=%4
set NugetSource=%~5

powershell.exe -executionpolicy remotesigned -File %~dp0release.ps1 %PackagePath% %OutputPath% %VersionNumber% %NugetPath% %NugetSource%