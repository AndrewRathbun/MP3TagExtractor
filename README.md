# MP3TagExtractor
 
 A command-line application to extract (recursively, if needed) IDv3 metadata from audio files
 
 ## Usage
 
* `-d` - This switch is required. Please provide a directory where you want this tool to scan for MP3 files. Please note, if you're ONLY using this switch, it'll ONLY look for files in this directory, and not recursively.
* `-r` - This switch is optional. If you add `-r` to the end of your command, it'll recurse the specified directory you provided for `-d` for MP3 files residing in subfolders. 

## Example Command

`.\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r`

The above command will provide console messaging similar to below, as of v0.1:

```powershell  
PS C:\temp> .\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r
Located 36 folders and 462 .mp3 files in the specified path.
CSV file created successfully at K:\Music\Megadeth\Megadeth_20230626_095321.csv with 463 rows. File size: 50824 bytes.  
```

This output will be refined over time, as needed.

## Feedback

Any ideas or suggestions are welcome! This tool was created to serve a single-use purpose for me to mass review IDv3 tags in a CSV format in Timeline Explorer.
