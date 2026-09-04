@echo off
setlocal EnableDelayedExpansion

title Luban Config Export
powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0ShowExportWindow.ps1"

call :Export
set "EXPORT_EXIT_CODE=!errorlevel!"
if not "!EXPORT_EXIT_CODE!"=="0" (
    echo.
    echo ==================== Luban export FAILED [exit code !EXPORT_EXIT_CODE!] ====================
    echo Please check the error messages above.
)
echo.
pause
exit /b !EXPORT_EXIT_CODE!

:Export
set WORKSPACE=..\..
set LUBAN_DLL=%WORKSPACE%\Tools\Luban\LubanRelease\Luban.dll
set CONF_ROOT=%WORKSPACE%\Unity\Assets\Config\Excel

call :GenerateMain all Client c
if errorlevel 1 exit /b %errorlevel%
call :GenerateMain all Server s
if errorlevel 1 exit /b %errorlevel%
call :GenerateMain all ClientServer cs
if errorlevel 1 exit /b %errorlevel%

call :GenerateStartWithCode Release s Server
if errorlevel 1 exit /b %errorlevel%
call :GenerateStartWithCode Release cs ClientServer
if errorlevel 1 exit /b %errorlevel%

for %%E in (Benchmark Beta Localhost RouterTest) do (
    call :GenerateStartData %%E s
    if errorlevel 1 exit /b !errorlevel!
    call :GenerateStartData %%E cs
    if errorlevel 1 exit /b !errorlevel!
)

echo ==================== Luban export finished ====================
exit /b 0

:GenerateMain
dotnet "%LUBAN_DLL%" ^
    --customTemplateDir CustomTemplate ^
    -t %1 ^
    -c cs-bin ^
    -d bin ^
    -d json ^
    --conf "%CONF_ROOT%\__luban__.conf" ^
    -x outputCodeDir="%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\%2\Config" ^
    -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%3" ^
    -x json.outputDataDir="%WORKSPACE%\Config\Json\%3" ^
    -x lineEnding=CRLF
exit /b !errorlevel!

:GenerateStartWithCode
dotnet "%LUBAN_DLL%" ^
    --customTemplateDir CustomTemplate ^
    -t all ^
    -c cs-bin ^
    -d bin ^
    -d json ^
    --conf "%CONF_ROOT%\StartConfig\%1\__luban__.conf" ^
    -x outputCodeDir="%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\%3\Config\StartConfig" ^
    -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%2\StartConfig\%1" ^
    -x json.outputDataDir="%WORKSPACE%\Config\Json\%2\StartConfig\%1" ^
    -x lineEnding=CRLF
exit /b !errorlevel!

:GenerateStartData
dotnet "%LUBAN_DLL%" ^
    --customTemplateDir CustomTemplate ^
    -t all ^
    -d bin ^
    -d json ^
    --conf "%CONF_ROOT%\StartConfig\%1\__luban__.conf" ^
    -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%2\StartConfig\%1" ^
    -x json.outputDataDir="%WORKSPACE%\Config\Json\%2\StartConfig\%1"
exit /b !errorlevel!
