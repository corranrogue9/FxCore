set reporoot=%1
set nugetpath=%2

powershell.exe -executionpolicy remotesigned -File %~dp0init.ps1 %reporoot% %nugetpath%