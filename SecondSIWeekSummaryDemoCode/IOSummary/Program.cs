using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace IOSummary
{
    class Program
    {
        private static int watchNumber = 0;
        static void Main(string[] args)
        {
            //Demo1GetDriveInfo();

            //Demo2WatchTheSystem();

            //Demo3WriteFileStream();
            //Demo3ReadFileStream();

            //Demo4StreamReading();
            //Demo4StreamWriting();

            //Demo5WriteIsolatedStorage();
            //Demo5ReadFromIsolatedStorage();
            //Demo5CreateFolderIsolatedStorage();

            Console.ReadLine();
        }


        static void Demo1GetDriveInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("{0} Content of the Drive:", drive.Name);

                try
                {
                    DirectoryInfo[] dirs = drive.RootDirectory.GetDirectories();

                    foreach (DirectoryInfo dir in dirs)
                        Console.WriteLine("  {0} Directory", dir.Name);

                    FileInfo[] files = drive.RootDirectory.GetFiles();
                    foreach (FileInfo file in files)
                        Console.WriteLine("  {0} File", file.Name);

                    Console.WriteLine();
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Some problem has occured while reading the drive data.");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        #region Watch the system
        static void Demo2WatchTheSystem()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"c:\");

            watcher.Created += new FileSystemEventHandler(IndicateFileChange);
            watcher.Changed += new FileSystemEventHandler(IndicateFileChange);
            //watcher.Renamed += new FileSystemEventHandler(IndicateFileChange);
            watcher.Renamed += new RenamedEventHandler(IndicateFileChange);
            watcher.Deleted += new FileSystemEventHandler(IndicateFileChange);
            watcher.EnableRaisingEvents = true;
        }

        static void IndicateFileChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("The content of the folder has been changed.");
            Console.WriteLine("{0} is {1}", e.FullPath, e.ChangeType);
            watchNumber++;
            if (watchNumber >= 5)
            {
                ((FileSystemWatcher)sender).EnableRaisingEvents = false;
            }
        }
        #endregion

        private static void Demo3ReadFileStream()
        {
            FileStream aFile = File.Open("file.dat", FileMode.Open, FileAccess.Read);

            int b = aFile.ReadByte();
            while (b != -1)
            {
                Console.Write((char)b);
                b = aFile.ReadByte();
            }

            aFile.Close();
        }

        private static void Demo3WriteFileStream()
        {
            FileStream aFile = File.Create("file.dat");

            aFile.WriteByte(72);
            aFile.WriteByte(69);
            aFile.WriteByte(76);
            aFile.WriteByte(76);
            aFile.WriteByte(79);

            aFile.Close();
            Console.WriteLine("file.dat is created and filled with data");
        }

        #region Stream reading and writing
        private static void Demo4StreamWriting()
        {
            FileStream theFile = File.Create("C:\\hello.txt");
            StreamWriter writer = new StreamWriter(theFile);

            writer.WriteLine("Hello");

            writer.Close();
            theFile.Close();
        }

        private static void Demo4StreamReading()
        {
            FileStream theFile = File.Open(@"resources\pickuplines.txt",
                                            FileMode.Open,
                                            FileAccess.Read);

            using (var reader2 = new StreamReader(theFile))
            {
                Console.Write(reader2.ReadToEnd());
            }

            theFile.Close();
        }
        #endregion

        #region IsolatedStorage
        private static void Demo5WriteIsolatedStorage()
        {
            using (var usrStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (var usrFile = new IsolatedStorageFileStream("hello.txt",
                                                                    FileMode.Create,
                                                                    usrStorage))
                {
                    using (var usrWriter = new StreamWriter(usrFile))
                    {
                        usrWriter.WriteLine("Hello Codecool");
                    }
                }
            }
        }

        private static void Demo5ReadFromIsolatedStorage()
        {
            using (var usrStorage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (var usrFile = new IsolatedStorageFileStream("hello.txt",
                                                                    FileMode.Open,
                                                                    usrStorage))
                {
                    using (var usrReader = new StreamReader(usrFile))
                    {
                        Console.Write(usrReader.ReadToEnd());
                    }
                }
            }
        }

        private static void Demo5CreateFolderIsolatedStorage()
        {
            IsolatedStorageFile usrStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            usrStorage.CreateDirectory("MyDir");
            IsolatedStorageFileStream usrFile = new IsolatedStorageFileStream(@"MyDir\myFile.dat",
                                                                        FileMode.Create,
                                                                        usrStorage);

            //TODO: check this error
            //usrFile.Write(12);

            usrFile.Close();
            usrStorage.Close();
        }
        #endregion
    }
}
