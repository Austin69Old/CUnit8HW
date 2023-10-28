using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;



class Program
{
    public static void Main()
    {

        string dirFolder = @"C:\Users\craas\OneDrive\Рабочий стол\TestFolder";

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

                Console.WriteLine($"Размер папки: {totalFolderSize}");


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


}






