# MP3TagExtractor
 
 A .NET6 command-line application to extract (recursively, if needed) IDv3 metadata from audio files
 
 ## Usage
 
* `-d` - This switch is required. Please provide a directory where you want this tool to scan for MP3 files. Please note, if you're ONLY using this switch, it'll ONLY look for files in this directory, and not recursively.
* `-r` - This switch is optional. If you add `-r` to the end of your command, it'll recurse the specified directory you provided for `-d` for MP3 files residing in subfolders.
* `--debug` - This switch is optional. This will allow for more verbosity in the console logging, which will show you which directory and file(s) are being processed as they're being processed by the application.

## Example Commands

`.\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r`

The above command will provide console messaging similar to below, as of v0.1:

```
PS C:\temp> .\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r
Located 36 folders and 462 .mp3 files in the specified path.
CSV file created successfully at K:\Music\Megadeth\Megadeth_20230626_095321.csv with 463 rows. File size: 50824 bytes.  
```

This output will be refined over time, as needed.

### Using `--debug`

`.\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r --debug`

Adding `--debug` to your command will show which folders and files are being processed as they're being processed:

```
PS Z:\MP3TagExtractor> .\MP3TagExtractor.exe -d 'K:\Music\Megadeth' -r --debug
Located 36 folders and 462 .mp3 files in the specified path.
Processing directory: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\01 - Last Rites - Loved to Death.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\02 - Killing Is My Business... And Business Is Good!.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\03 - Skull Beneath the Skin.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\04 - These Boots (Nancy Sinatra Cover).mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\05 - Rattlehead.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\06 - Chosen Ones.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\07 - Looking Down the Cross.mp3
Processing file: K:\Music\Megadeth\1985 - Killing Is My Business... And Business Is Good!\08 - Mechanix.mp3
Processing directory: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\1 - Wake Up Dead.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\2 - The Conjuring.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\3 - Peace Sells.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\4 - Devils Island.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\5 - Good Mourning - Black Friday.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\6 - Bad Omen.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\7 - I Ain't Superstitious.mp3
Processing file: K:\Music\Megadeth\1986 - Peace Sells... But Who's Buying\8 - My Last Words.mp3
Processing directory: K:\Music\Megadeth\1988 - So Far, So Good... So What!
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\1 - Into the Lungs of Hell.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\2 - Set the World Afire.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\3 - Anarchy in the U.K..mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\4 - Mary Jane.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\5 - 502.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\6 - In My Darkest Hour.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\7 - Liar.mp3
Processing file: K:\Music\Megadeth\1988 - So Far, So Good... So What!\8 - Hook in Mouth.mp3
Processing directory: K:\Music\Megadeth\1990 - Rust in Peace
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\1 - Holy Wars...The Punishment Due.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\2 - Hangar 18.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\3 - Take No Prisoners.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\4 - Five Magics.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\5 - Poison Was the Cure.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\6 - Lucretia.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\7 - Tornado of Souls.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\8 - Dawn Patrol.mp3
Processing file: K:\Music\Megadeth\1990 - Rust in Peace\9 - Rust in Peace...Polaris.mp3
```

## Feedback

Any ideas or suggestions are welcome! This tool was created to serve a single-use purpose for me to mass review IDv3 tags in a CSV format in Timeline Explorer.
