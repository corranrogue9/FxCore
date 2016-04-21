robocopy %~dp0ProjectTemplates "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ProjectTemplates\CSharp\FxCore\1033" /MIR
robocopy %~dp0ItemTemplates "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ItemTemplates\CSharp\FxCore" /MIR
devenv /installvstemplates