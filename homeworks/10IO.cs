using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
namespace _10IO
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory("Folder_" + i);
            }
            Console.WriteLine("Было создано 100 каталогов:");
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (var el in dir.GetDirectories())
            {
                Console.WriteLine(el.Name);
            }
            for (int i = 0; i < 100; i++)
            {
                Directory.Delete("Folder_" + i);
            }
           Console.WriteLine("А теперь удалено");
           Console.WriteLine();
           
           File.WriteAllText("file.txt", "someinfo\nline # 2\nhaha");
           Console.WriteLine(File.ReadAllText("file.txt"));

           string name = "file.txt";
           
           dir = new DirectoryInfo("C:/Users/Паша/Desktop/10IO/10IO/bin/Debug");
           foreach (var el in dir.GetFiles())
           {
               if (el.Name == name) 
               {
                   Console.WriteLine("Файл найден:");
                   using (FileStream fstream = File.OpenRead(name))
                   {
                       byte[] arr = new byte[fstream.Length];
                       fstream.Read(arr, 0, arr.Length);
                       string textFromFile = System.Text.Encoding.Default.GetString(arr);
                       Console.WriteLine(textFromFile);

                       using (FileStream compressedFileStream = File.Create("newarchive.gz"))
                       {
                           using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                           {
                               fstream.CopyTo(compressionStream);
                           }
                           Console.WriteLine("Создан архив");
                       }
                   }
                   break;
               }
           }
         
           Console.Read();
        }
    }
}
