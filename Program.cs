using System;
using System.IO;
using System.Linq;
using System.Text;
using TagLib;

namespace MP3TagExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recurse = false;
            string dirPath = "";

            // Parse command line arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-r")
                {
                    recurse = true;
                }
                else if (args[i] == "-d" && i + 1 < args.Length)
                {
                    dirPath = args[i + 1];
                    i++;
                }
            }

            if (string.IsNullOrEmpty(dirPath) || !Directory.Exists(dirPath))
            {
                Console.WriteLine("Please provide a valid directory path.");
                return;
            }

            SearchOption searchOption = recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            // Count folders and files
            int dirCount = Directory.GetDirectories(dirPath, "*", searchOption).Length;
            var files = System.IO.Directory.EnumerateFiles(dirPath, "*.mp3", searchOption).ToList();
            int fileCount = files.Count;

            Console.WriteLine($"Located {dirCount} folders and {fileCount} .mp3 files in the specified path.");

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Artist,Year,Album,Disc,Title,Duration,Comment,Genre");

            foreach (var file in files)
            {
                try
                {
                    using (var mp3 = TagLib.File.Create(file))
                    {
                        csvBuilder.AppendLine($"\"{mp3.Tag.FirstPerformer}\",\"{mp3.Tag.Year}\",\"{mp3.Tag.Album}\",\"{mp3.Tag.Disc}\",\"{mp3.Tag.Title}\",\"{mp3.Properties.Duration}\",\"{mp3.Tag.Comment}\",\"{mp3.Tag.FirstGenre}\"");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error processing file: {file}. Exception: {e}");
                }
            }

            // Create output file name
            string parentFolderName = new DirectoryInfo(dirPath).Name.Replace(" ", "");
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFileName = $"{parentFolderName}_{timeStamp}.csv";
            string outputPath = Path.Combine(dirPath, outputFileName);

            // Write output to csv file
            System.IO.File.WriteAllText(outputPath, csvBuilder.ToString());

            // Output file details
            long fileSize = new FileInfo(outputPath).Length;
            int rowCount = csvBuilder.ToString().Split(Environment.NewLine).Length - 1; // Subtract 1 for header
            Console.WriteLine($"CSV file created successfully at {outputPath} with {rowCount} rows. File size: {fileSize} bytes.");
        }
    }
}
