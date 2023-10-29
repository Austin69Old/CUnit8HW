using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }


        public Student(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\craas\OneDrive\Рабочий стол\TestFolder\Students.dat";
           
            ReadFile(path);
        }

        static void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        var Students = (Student[])bf.Deserialize(fs);
                        foreach (var Student in Students)
                        {
                            Console.WriteLine($"Имя: {Student.Name}");
                            Console.WriteLine($"Группа: {Student.Group}");
                            Console.WriteLine($"Дата рождения: {Student.DateOfBirth}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
        }
    }
}