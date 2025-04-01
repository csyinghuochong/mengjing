@echo off
setlocal enabledelayedexpansion

rem 获取当前脚本所在目录
set SOURCE_DIR=%~dp0

rem 设置中间目录（Config同级目录，去掉.bin后缀）
set CONFIG_DIR=..\..\Config\Recast

rem 设置最终目标目录（Unity目录，改为.bytes扩展名）
set UNITY_DIR=..\..\Unity\Assets\Bundles\Recast

rem 确保Config目录存在
if not exist "%CONFIG_DIR%" (
    mkdir "%CONFIG_DIR%"
)

rem 确保Unity目录存在
if not exist "%UNITY_DIR%" (
    mkdir "%UNITY_DIR%"
)

rem 第一步：移动.bin文件到Config目录（去掉.bin后缀）
for %%f in ("%SOURCE_DIR%*.bin") do (
    set FILENAME=%%~nf
    move /y "%%f" "%CONFIG_DIR%\!FILENAME!"
)

rem 第二步：从Config目录复制无后缀文件到Unity目录（加上.bytes后缀）
for %%f in ("%CONFIG_DIR%\*") do (
    set FILENAME=%%~nf
    copy /y "%%f" "%UNITY_DIR%\!FILENAME!.bytes"
)

pause