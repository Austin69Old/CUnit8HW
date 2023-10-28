using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main()
    {

        string dirFolder = @"C:\Users\craas\OneDrive\Рабочий стол\TestFolder";

        DateTime lastEdit = System.IO.File.GetLastWriteTime(dirFolder);

        DateTime now = DateTime.Now;

        TimeSpan interval = now - lastEdit;


        if (interval.Minutes > 30)
        {
            if (Directory.Exists(dirFolder))
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dirFolder);

                    long totalFolderSize = folderSize(dirInfo);

                    static long folderSize(DirectoryInfo dirInfo)
                    {
                        long size = 0;

                        FileInfo[] allFiles = dirInfo.GetFiles();

                        foreach (FileInfo file in allFiles)
                        {
                            size += file.Length;
                        }

                        DirectoryInfo[] allDirectories = dirInfo.GetDirectories();

                        foreach (DirectoryInfo directory in allDirectories)
                        {
                            size += folderSize(directory);
                        }

                        return size;
                    }

                    Console.WriteLine($"Текущий размер папки: {totalFolderSize}");


                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                 
                    Console.WriteLine($"Освобождено: {totalFolderSize}");

                    long newTotalFolderSize = folderSize(dirInfo);
                    Console.WriteLine($"Текущий размер папки: {newTotalFolderSize}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Пути не существует");
            }
    }
        else
        {
            Console.WriteLine("В последнее использование папки менее 30 мин.назад");
        }

    }
}
