@echo off

set PackagePath=%~1
set OutputPath=%~2
set TestSettings=%~3

powershell.exe -executionpolicy remotesigned -File %~dp0test.ps1 %PackagePath% %OutputPath% %TestSettings%