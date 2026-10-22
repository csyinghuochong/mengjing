@echo off
setlocal EnableDelayedExpansion

title Luban Config Export

rem Work from the directory that contains this script so CustomTemplate resolves.
cd /d "%~dp0"
for %%I in ("%~dp0..\..") do set "WORKSPACE=%%~fI"

set "LUBAN_DLL=%WORKSPACE%\Tools\Luban\LubanRelease\Luban.dll"
set "CONF_ROOT=%WORKSPACE%\Unity\Assets\Config\Excel"
set "CLIENT_BYTES_DIR=%WORKSPACE%\Config\Excel\c"
set "UNITY_CLIENT_BYTES_DIR=%WORKSPACE%\Unity\Assets\Bundles\Config"
set "CLIENT_CODE_DIR=%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\Client\Config"
set "SERVER_CODE_DIR=%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\Server\Config"
set "CLIENT_SERVER_CODE_DIR=%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\ClientServer\Config"
set "META_BACKUP_DIR=%TEMP%\luban-meta-backup-%RANDOM%%RANDOM%"

powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0ShowExportWindow.ps1"

set "FAIL="

rem The window stays open after the export (success or failure) so the log can be read.
rem Set LUBAN_NO_PAUSE=1 to skip that, e.g. for automation.

rem ---- back up .meta files (Unity must keep the same GUIDs) ----
if exist "%META_BACKUP_DIR%" rd /s /q "%META_BACKUP_DIR%"
mkdir "%META_BACKUP_DIR%" >nul 2>nul
if exist "%CLIENT_CODE_DIR%" robocopy "%CLIENT_CODE_DIR%" "%META_BACKUP_DIR%\ClientConfig" *.meta /S /NJH /NJS /NFL /NDL /NP >nul
if exist "%SERVER_CODE_DIR%" robocopy "%SERVER_CODE_DIR%" "%META_BACKUP_DIR%\ServerConfig" *.meta /S /NJH /NJS /NFL /NDL /NP >nul
if exist "%CLIENT_SERVER_CODE_DIR%" robocopy "%CLIENT_SERVER_CODE_DIR%" "%META_BACKUP_DIR%\ClientServerConfig" *.meta /S /NJH /NJS /NFL /NDL /NP >nul

rem ---- main config tables ----
for %%T in ("client Client c" "server Server s" "all ClientServer cs") do (
    for /f "tokens=1-3" %%A in (%%T) do (
        dotnet "%LUBAN_DLL%" --customTemplateDir CustomTemplate -t %%A -c cs-bin -d bin -d json --conf "%CONF_ROOT%\__luban__.conf" -x outputCodeDir="%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\%%B\Config" -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%%C" -x json.outputDataDir="%WORKSPACE%\Config\Json\%%C" -x lineEnding=CRLF
        if errorlevel 1 set "FAIL=1"
    )
)

rem ---- StartConfig code ----
for %%T in ("Release s Server" "Release cs ClientServer") do (
    for /f "tokens=1-3" %%A in (%%T) do (
        dotnet "%LUBAN_DLL%" --customTemplateDir CustomTemplate -t all -c cs-bin -d bin -d json --conf "%CONF_ROOT%\StartConfig\%%A\__luban__.conf" -x outputCodeDir="%WORKSPACE%\Unity\Assets\Scripts\Model\Generate\%%C\Config\StartConfig" -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%%B\StartConfig\%%A" -x json.outputDataDir="%WORKSPACE%\Config\Json\%%B\StartConfig\%%A" -x lineEnding=CRLF
        if errorlevel 1 set "FAIL=1"
    )
)

rem ---- StartConfig data ----
for %%E in (Benchmark Beta Localhost RouterTest) do (
    for %%G in (s cs) do (
        dotnet "%LUBAN_DLL%" --customTemplateDir CustomTemplate -t all -d bin -d json --conf "%CONF_ROOT%\StartConfig\%%E\__luban__.conf" -x bin.outputDataDir="%WORKSPACE%\Config\Excel\%%G\StartConfig\%%E" -x json.outputDataDir="%WORKSPACE%\Config\Json\%%G\StartConfig\%%E"
        if errorlevel 1 set "FAIL=1"
    )
)

rem ---- restore .meta files ----
if exist "%CLIENT_CODE_DIR%" if exist "%META_BACKUP_DIR%\ClientConfig" robocopy "%META_BACKUP_DIR%\ClientConfig" "%CLIENT_CODE_DIR%" *.meta /S /NJH /NJS /NFL /NDL /NP >nul
if exist "%SERVER_CODE_DIR%" if exist "%META_BACKUP_DIR%\ServerConfig" robocopy "%META_BACKUP_DIR%\ServerConfig" "%SERVER_CODE_DIR%" *.meta /S /NJH /NJS /NFL /NDL /NP >nul
if exist "%CLIENT_SERVER_CODE_DIR%" if exist "%META_BACKUP_DIR%\ClientServerConfig" robocopy "%META_BACKUP_DIR%\ClientServerConfig" "%CLIENT_SERVER_CODE_DIR%" *.meta /S /NJH /NJS /NFL /NDL /NP >nul
if exist "%META_BACKUP_DIR%" rd /s /q "%META_BACKUP_DIR%"

if defined FAIL (
    echo.
    echo ==================== Luban export FAILED ====================
    echo Please check the error messages above.
    echo.
    if not defined LUBAN_NO_PAUSE pause
    exit /b 1
)

rem ---- copy client config into the Unity project ----
if not exist "%CLIENT_BYTES_DIR%" (
    echo [ERROR] Client config bytes not found: "%CLIENT_BYTES_DIR%"
    if not defined LUBAN_NO_PAUSE pause
    exit /b 1
)
if not exist "%UNITY_CLIENT_BYTES_DIR%" mkdir "%UNITY_CLIENT_BYTES_DIR%" >nul 2>nul

rem Keep .meta on the Unity side (GUIDs must not change); drop only the old content.
for /f "delims=" %%F in ('dir /b /s /a-d "%UNITY_CLIENT_BYTES_DIR%" 2^>nul') do (
    if /I not "%%~xF"==".meta" del /q "%%F"
)
robocopy "%CLIENT_BYTES_DIR%" "%UNITY_CLIENT_BYTES_DIR%" /E /XF *.meta /NJH /NJS /NFL /NDL /NP >nul
if errorlevel 8 set "FAIL=1"

pushd "%CLIENT_BYTES_DIR%"
for /r %%F in (*.bytes) do (
    set "REL=%%F"
    set "REL=!REL:%CD%\=!"
    fc /b "%%F" "%UNITY_CLIENT_BYTES_DIR%\!REL!" >nul || set "FAIL=1"
)
popd

if defined FAIL (
    echo.
    echo ==================== Luban export FAILED while syncing Unity client config ====================
    if not defined LUBAN_NO_PAUSE pause
    exit /b 1
)

rem ---- drop .meta files whose asset no longer exists ----
for %%D in ("%UNITY_CLIENT_BYTES_DIR%" "%CLIENT_CODE_DIR%" "%SERVER_CODE_DIR%" "%CLIENT_SERVER_CODE_DIR%") do (
    for /f "delims=" %%F in ('dir /b /s /a-d "%%~D\*.meta" 2^>nul') do (
        if not exist "%%~dpnF" del /q "%%F"
    )
)

echo ==================== Luban export finished ====================
echo.
if not defined LUBAN_NO_PAUSE pause
exit /b 0
