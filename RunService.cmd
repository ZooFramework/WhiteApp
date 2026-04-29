@ECHO OFF
IF [%1] == [] (
  set /p ENV="Please enter env to start: "
) else (
  set ENV=%1
)
IF [%2] == [] (
  set /p SERVICE="Please enter service to start: "
) else (
  set SERVICE=%2
)

@ECHO OFF
cd bin/Debug/%SERVICE%
@ECHO ON
echo Updating ZooFramework.Hosting.Console
dotnet tool update -g ZooFramework.Hosting.Console --configfile NuGet.config
echo ZooFramework.Hosting.Console Updated
start zoo-hosting -c "Config\%ENV%\Services\%SERVICE%.json"
@ECHO OFF
cd ../../..