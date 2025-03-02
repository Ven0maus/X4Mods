:: ##############################################################
:: #                                                            #
:: #  x4_cat_unpack.bat - Created by Venomaus (2025)            #
:: #                                                            #
:: #  This script is released under the GNU General Public      #
:: #  License (GPL) as defined on the GitHub repository.        #
:: #                                                            #
:: #  For details, see:                                         #
:: #  https://github.com/Ven0maus/X4Mods/blob/main/LICENSE      #
:: #                                                            #
:: ##############################################################

@echo off
setlocal enabledelayedexpansion
set "GAMEPATH=%CD%"
set "DRIVE=%GAMEPATH:~0,2%"
set "JUNCTION_PATH=%DRIVE%\X4CAT"

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

if exist "%JUNCTION_PATH%\extracted" (
    echo:
    echo Removing existing "extracted" folder, this may take a while...
    rmdir /s /q "%JUNCTION_PATH%\extracted"
)

:: Ensuring new output directories exist
mkdir "%JUNCTION_PATH%\extracted" 2>nul
mkdir "%JUNCTION_PATH%\extracted\extensions" 2>nul

echo:
echo Started extracting base game .cat files
for %%f in (*.cat) do (
    set "FILENAME=%%~nf"
    if /i "!FILENAME:~-4!" NEQ "_sig" "%JUNCTION_PATH%\XRCatTool.exe" -in "%%f" -out "%JUNCTION_PATH%\extracted"
)

echo:
echo Started extracting DLC .cat files from extensions folder
for /d %%d in (extensions\ego_dlc*) do (
    set "DLC_NAME=%%~nxd"
    mkdir "%JUNCTION_PATH%\extracted\extensions\!DLC_NAME!"
    for %%f in (%%d\*.cat) do (
        set "FILENAME=%%~nf"
        if /i "!FILENAME:~-4!" NEQ "_sig" "%JUNCTION_PATH%\XRCatTool.exe" -in "%%f" -out "%JUNCTION_PATH%\extracted\extensions\!DLC_NAME!"
    )
)
echo:

echo Removing junction "%JUNCTION_PATH%"
rmdir "%JUNCTION_PATH%"
echo:

echo Finished decompression, you can close this window now.
pause >nul