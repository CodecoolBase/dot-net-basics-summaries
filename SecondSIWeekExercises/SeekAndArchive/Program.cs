using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SeekAndArchive
{
    class Program
    {
        private static List<FileInfo> _foundFiles;
        private static List<FileSystemWatcher> _watchers;
        private static List<DirectoryInfo> _archiveDirs;

        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            _foundFiles = new List<FileInfo>();
            _watchers = new List<FileSystemWatcher>();

            //examine if the given directory exists at all 
            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                Console.ReadKey();
                return;
            }

            // search recursively for the matching files
            RecursiveSearch(_foundFiles, fileName, rootDir);

            //list the found files 
            Console.WriteLine($"Found {_foundFiles.Count} files.");

            if (_foundFiles.Count > 0)
            {
                BindWatchers();
                ArchiveFoundFiles(); 
            }

            Console.WriteLine("Press Enter to quit.");
            Console.Read();
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                if (file.Name == fileName)
                    foundFiles.Add(file);
            }

            //continue the search recursively 
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }

        private static void BindWatchers()
        {
            foreach (FileInfo file in _foundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);

                newWatcher.EnableRaisingEvents = true;
                _watchers.Add(newWatcher);

                Console.WriteLine($"{file.FullName} file is watched.");
            }
        }

        private static void ArchiveFoundFiles()
        {
            _archiveDirs = new List<DirectoryInfo>();

            //create archive directories 
            for (int i = 0; i < _foundFiles.Count; i++)
            {
                _archiveDirs.Add(Directory.CreateDirectory($"archive {i}"));
            }
        }

        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} has been changed!");

            //find the the index of the changed file 
            FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
            int index = _watchers.IndexOf(senderWatcher, 0);

            //now that we have the index, we can archive the file 
            ArchiveFile(_archiveDirs[index], _foundFiles[index]);
        }

        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            FileStream input = fileToArchive.OpenRead();
            FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");

            GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);

            int currentByte = input.ReadByte();

            while (currentByte != -1)
            {
                Compressor.WriteByte((byte)currentByte);
                currentByte = input.ReadByte();
            }

            Compressor.Close();
            input.Close();
            output.Close();
        }
    }
}
