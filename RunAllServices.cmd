@ECHO OFF

set SEARCHTEXT=.json
set REPLACETEXT=

SET cmdDirectory=%~dp0

IF [%1] == [] (
  set /p ENV="Please enter env to start: "
) else (
  set ENV=%1
)

echo Updating ZooFramework.Hosting.Console
dotnet tool update -g ZooFramework.Hosting.Console --configfile NuGet.config
echo ZooFramework.Hosting.Console Updated

setlocal enabledelayedexpansion
echo "Getting services from : %cmdDirectory%../Config/%ENV%/Services/"
for %%f in (%cmdDirectory%Library/Config/%ENV%/Services/*.json) do (
  SET string=%%f
  SET serviceJsonName=!string:%cmdDirectory%=%REPLACETEXT%!
  SET serviceName=!serviceJsonName:%SEARCHTEXT%=%REPLACETEXT%!
  echo Starting !serviceName!
  cd %cmdDirectory%/bin/Debug/!serviceName!
  start zoo-hosting -c "Config\!ENV!\Services\!serviceJsonName!"
)

cd %cmdDirectory%

PAUSE