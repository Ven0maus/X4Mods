# X4 Cat Unpack Script

## Overview

The batch script (`x4_cat_unpack.bat`) is designed to extract `.cat` files from *X4: Foundations*, including both the base game and any installed DLCs. The script ensures proper execution by verifying the game directory, checking for required tools, and handling long file paths via a junction link.

## Requirements

1. **X4: Foundations** must be installed, and the script must be run from within the game directory.
2. **XRCatTool.exe** must be placed in the game's root directory.
   - You can download it from the official Egosoft wiki:  
     [X4 Cat Tool](https://wiki.egosoft.com:1337/X4%20Foundations%20Wiki/Modding%20Support/X%20Catalog%20Tool)

## How to Use the Script

1. **Place `x4_cat_unpack.bat` in the `X4 Foundations` game folder.**
2. **Ensure `XRCatTool.exe` is present in the same directory.**
3. **Wait for the extraction to complete.**
4. **The extracted files will be located in `extracted`.**

## **Extraction process**

### **Base Game Files**

- The script searches for all `.cat` files in the game root and extracts them using `XRCatTool.exe` into `extracted`.

### **DLC Files**

- The script iterates through each DLC folder (`extensions/ego_dlc*`) and extracts its `.cat` files into corresponding subfolder(s) under `extracted/extensions` for each DLC.

## Troubleshooting

### **Error: "The x4_cat_unpack.bat file must be located within the game's directory."**

- Move the script to the correct game installation folder and try again.

### **Error: "Missing required XRCatTool.exe file"**

- Download `XRCatTool.exe` and place it in the game folder before running the script.

### **Error: "X4CAT exists but is NOT a junction. Manual action required."**

- The `X4CAT` path exists but is not a valid junction. This means a folder called X4CAT already exists on the drive of the game's directory, which was put there by the user. Either remove the folder or change the junction path in the x4_cat_unpack.bat script to something else and try again.

### **Extraction Takes a Long Time**

- This is normal. The script extracts large amounts of data, so wait until the "Finished decompression" message appears.

## Notes

- Running this script **does not modify the game files**; it only extracts them for modding purposes.
- If the game updates to a new version, just run the unpack script again. It will remove the previous unpacked files automatically.
- Ensure you have enough storage space on the drive of the game's directory.

---

This script simplifies the extraction process for modders by automating file management and avoiding long file path issues. Happy modding!
