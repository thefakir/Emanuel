@ECHO OFF
del *.nupkg
.\nuget.exe pack .\Caliburn.Micro.Core.nuspec -symbols
.\nuget.exe pack .\Caliburn.Micro.nuspec -symbols
.\nuget.exe pack .\Caliburn.Micro.Start.nuspec
