using System.Diagnostics;
using System.Text;

namespace MP3TagExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recurse = false;
            bool debug = false;
            string dirPath = "";

            // Parse command line arguments
            for (int i = 0; i < args.Length; i++)
            {
                // Check if recursion is set
                if (args[i] == "-r") // recursive switch
                {
                    recurse = true;
                }
                // Check if directory path is set
                else if (args[i] == "-d" && i + 1 < args.Length) // directory parameter
                {
                    dirPath = args[i + 1];
                    i++;
                }
                else if (args[i] == "--debug")
                {
                    debug = true;
                }
            }

            // Validate directory path. If no directory is provided when running this tool, output a message to the user
            if (string.IsNullOrEmpty(dirPath) || !Directory.Exists(dirPath))
            {
                Console.WriteLine("Please provide a valid directory path");
                return;
            }

            // Set search option based on whether recursion is set or not
            SearchOption searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            // Count number of directories and .mp3 files in the specified path
            int dirCount = Directory.GetDirectories(dirPath, "*", searchOption).Length; // count of subdirectories
            var directories = Directory.GetDirectories(dirPath, "*", searchOption); // get list of directories
            var files = Directory.EnumerateFiles(dirPath, "*.mp3", searchOption)
                .ToList(); // gather list of .mp3 files
            int fileCount = files.Count; // count of files

            Console.WriteLine($"Located {dirCount} folders and {fileCount} .mp3 files in the specified path.");

            // Prepare CSV file content
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine(
                "Artist,Year,Album,Disc,Title,Duration,Comment,Genre,FileSize(MB),Bitrate(kbps),FilePath");

            // Starts measuring time
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Debug message if user enabled --debug switch
            if (debug)
            {
                foreach (var directory in directories)
                {
                    Console.WriteLine($"Processing directory: {directory}");

                    // Get the files in the current directory
                    var dirFiles = Directory.EnumerateFiles(directory, "*.mp3", SearchOption.TopDirectoryOnly).ToList();
                    foreach (var file in dirFiles)
                    {
                        Console.WriteLine($"Processing file: {file}");
                        ProcessFile(file, csvBuilder, debug);
                    }
                }
            }
            else
            {
                // Process each .mp3 file. files contains all .mp3 files. file will be each individual .mp3 file
                foreach (var file in files)
                {
                    ProcessFile(file, csvBuilder, debug);
                }
            }

            // Generate CSV file name based on parent directory name and current timestamp
            string parentFolderName =
                new DirectoryInfo(dirPath).Name
                    .Replace(" ", ""); // remove spaces from folder name, example: Blind Guardian -> BlindGuardian
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss"); // generate timestamp, example: 20230627_231122
            string outputFileName = $"{parentFolderName}_{timeStamp}.csv"; // example: BandName_20230627_231122.csv
            string
                outputPath =
                    Path.Combine(dirPath,
                        outputFileName); // example: K:\Music\Music_20230627_231122.csv or K:\Music\Blind Guardian\BlindGuardian_20230627_231122.csv

            // Write CSV file content to file
            File.WriteAllText(outputPath, csvBuilder.ToString());

            // Calculate outputFile file size in bytes, KB, and MB
            FileInfo outputFile = new FileInfo(outputPath);
            long fileSizeBytes = outputFile.Length;
            double fileSizeKb = fileSizeBytes / 1024.0; // KB
            double fileSizeMb = fileSizeKb / 1024.0; // MB

            // Subtract 1 line for header
            int rowCount = csvBuilder.ToString().Split(Environment.NewLine).Length - 1; // Subtract 1 for header
            Console.WriteLine(
                $"CSV file created successfully at {outputPath} with {rowCount} rows | File size: {fileSizeBytes} bytes | {fileSizeKb:F2} KB | {fileSizeMb:F2} MB."); //

            // Stops measuring time
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        }

        // Method for processing individual file
        // Method for processing individual file
        private static void ProcessFile(string file, StringBuilder csvBuilder, bool debug)
        {
            // Debug message if user enabled --debug switch
            if (debug)
            {
                Console.WriteLine($"Processing file: {file}");
            }

            try
            {
                using (var mp3 = TagLib.File.Create(file))
                {
                    // Obtain file size, convert to megabytes
                    var mp3FileSizeMb = new FileInfo(file).Length / (1024.0 * 1024.0);
                    csvBuilder.AppendLine(
                        $"\"{mp3.Tag.FirstPerformer ?? ""}\",\"{mp3.Tag.Year}\",\"{mp3.Tag.Album ?? ""}\",\"{mp3.Tag.Disc}\",\"{mp3.Tag.Title ?? ""}\",\"{mp3.Properties?.Duration}\",\"{mp3.Tag.Comment ?? ""}\",\"{mp3.Tag.FirstGenre ?? ""}\",\"{mp3FileSizeMb:F2}\",\"{mp3.Properties?.AudioBitrate}\",\"{file}\"");
                }
            }
            catch (Exception e)
            {
                // Output error message if failed to process .mp3 file
                Console.WriteLine($"Error processing file: {file}. Exception: {e}");
            }
        }
    }
}