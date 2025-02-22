@echo off
setlocal enabledelayedexpansion
set "GAMEPATH=%CD%"
set "DRIVE=%GAMEPATH:~0,2%"
set "JUNCTION_PATH=%DRIVE%\X4CAT"

:: Extract the last part of the path
for %%A in ("%GAMEPATH%") do set "LASTFOLDER=%%~nxA"

:: Check if the last folder name is "X4 Foundations"
if /I "%LASTFOLDER%" NEQ "X4 Foundations" (
    echo The x4_cat_unpack.bat file must be located within the game's directory.
    echo Please execute this file from the correct directory.
    pause
    exit /b
)

:: Validate if XRCatTool.exe exists
if not exist "%GAMEPATH%\XRCatTool.exe" (
    echo:
    echo Missing required XRCatTool.exe file
    echo Please download the X4 Cat Tool:
    echo https://wiki.egosoft.com:1337/X4%%20Foundations%%20Wiki/Modding%%20Support/X%%20Catalog%%20Tool
    echo And place the file in the game's directory, before running the unpack script.
    pause
    exit /b
)

echo Decompressing cat files takes a long time, don't close this window
echo until you see "Finished decompression, you can close this window now."
echo:

echo Creating temporary junction to prevent long file path issues
if not exist "%JUNCTION_PATH%" (
    mklink /J "%JUNCTION_PATH%" "%GAMEPATH%"
) else (
    fsutil reparsepoint query "%JUNCTION_PATH%" >nul 2>&1
    if %errorlevel%==0 (
        echo Junction "%JUNCTION_PATH%" already exists, overwriting with X4 path..
        rmdir "%JUNCTION_PATH%"
        :: Recreate junction to X4 path
        mklink /J "%JUNCTION_PATH%" "%GAMEPATH%"
    ) else (
        echo "%JUNCTION_PATH%" exists, but it is NOT a junction. Manual action required.
        pause
        exit /b
    )
)

if exist "%JUNCTION_PATH%\unpacked-cat-files" (
    echo:
    echo Removing existing "unpacked-cat-files" folder, this may take a while...
    rmdir /s /q "%JUNCTION_PATH%\unpacked-cat-files"
)

:: Ensuring new output directories exist
mkdir "%JUNCTION_PATH%\unpacked-cat-files" 2>nul
mkdir "%JUNCTION_PATH%\unpacked-cat-files\ego_base_game" 2>nul

echo:
echo Started extracting base game .cat files
for %%f in (*.cat) do "%JUNCTION_PATH%\XRCatTool.exe" -in "%%f" -out "%JUNCTION_PATH%\unpacked-cat-files\ego_base_game"

echo:
echo Started extracting DLC .cat files from extensions folder
for /d %%d in (extensions\ego_dlc*) do (
    set "DLC_NAME=%%~nxd"
    mkdir "%JUNCTION_PATH%\unpacked-cat-files\!DLC_NAME!"
    for %%f in (%%d\*.cat) do "%JUNCTION_PATH%\XRCatTool.exe" -in "%%f" -out "%JUNCTION_PATH%\unpacked-cat-files\!DLC_NAME!"
)
echo:

echo Removing junction "%JUNCTION_PATH%"
rmdir "%JUNCTION_PATH%"
echo:

echo Finished decompression, you can close this window now.
pause >nul