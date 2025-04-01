@echo off
setlocal enabledelayedexpansion

rem 获取当前脚本所在目录
set SOURCE_DIR=%~dp0

rem 设置目标目录
set TARGET_DIR=..\..\Unity\Assets\Bundles\Recast

rem 确保目标目录存在
if not exist "%TARGET_DIR%" (
    mkdir "%TARGET_DIR%"
)

rem 遍历当前目录下的所有 .bin 文件
for %%f in ("%SOURCE_DIR%*.bin") do (
    rem 获取文件名（不带扩展名）
    set FILENAME=%%~nf
    rem 复制文件并修改扩展名为 .bytes，强制替换已存在文件
    copy /y "%%f" "%TARGET_DIR%\!FILENAME!.bytes"
)

pause
