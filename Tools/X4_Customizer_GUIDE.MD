# X4 Customizer Guide

## Initial Setup
1. Open **X4 Customizer**.
2. Navigate to **View → Configuration**.
3. Set the following paths:
   - **X4 folder**
   - **Documents folder**
   - **Output folder** (used primarily for Python-generated content)

## Utilities Overview

### Extensions Utility
- Shows all installed mods in the `extensions` folder.
- Allows testing for XPath errors without launching the game.
- Enables you to set which mods are considered active.

### Virtual File System (VFS) Utility
- Loads a file as it appears after all active mods have modified it.
- Can be used to extract patched files (with only DLCs active) for diff generation.

---

## Example: Patching `wares.xml` with Split DLC Enabled

### **Preparation**
1. In the **X4 Customizer** tool folder, create a new folder named `extracted_patched`.
2. Inside `extracted_patched`, create another folder named `modified_files`.

### **Extracting the Patched `wares.xml`**
3. Open **X4 Customizer** and navigate to the **Extensions** window.
4. Disable all mods except the **Split DLC**, then click **Test All**.
5. Once finished, open **VFS** and double-click on `wares.xml` to load it.
6. Go back to **VFS**, find `wares.xml` (it should now be highlighted in blue).
7. Right-click `wares.xml` and select **Save to file (patched)**.
8. Save it inside the `extracted_patched` folder.

### **Preparing for Diff Generation**
9. Copy the `wares.xml` file you just saved into the `modified_files` folder.
10. Make your changes in this copy.

### **Generating the Diff File**
11. Create a new `.bat` file in the **X4 Customizer** tool folder with the following content:

    ```bat
    @echo off
    set "PATCHED_PATH=%CD%\extracted_patched"
    "%~dp0\bin\X4_Customizer_console.exe" -nogui Generate_Diffs -argpass "%PATCHED_PATH%" "%PATCHED_PATH%\modified_files" "%PATCHED_PATH%\diffs" -s%*
    pause
    ```

12. Run the `.bat` file. This will automatically create a `diffs` folder inside `extracted_patched`, containing your generated diff files.

---

Now you have a clean workflow to modify and generate diffs using X4 Customizer! 🚀

