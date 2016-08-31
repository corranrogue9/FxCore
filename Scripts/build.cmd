@echo off

set reporoot=%1
set PackagePath=%2

powershell.exe -executionpolicy remotesigned -File %~dp0build.ps1 %reporoot% %PackagePath%