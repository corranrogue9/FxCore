@echo off

set version=%1
IF "%2"=="short" (
	set short=%2
) ELSE (
	set short=
)

IF "%3"=="" (
	set resultDirectory=%~dp0..\
) ELSE (
	set resultDirectory=%~f3\
)

call %~dp0init.cmd %~dp0..\FxCore.sln %~dp0..\.nuget\nuget.exe
call %~dp0build.cmd %~dp0..\FxCore.sln %resultDirectory%package
call %~dp0test.cmd %resultDirectory%package %resultDirectory%testresults %short% %~dp0..\Testing\Local.TestSettings
call %~dp0release.cmd %resultDirectory%package %resultDirectory%release %version% %~dp0..\.nuget\nuget.exe