using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        CreateFolder("new_folder");
        ShowCurrentDirectory();
        DeleteFolder("new_folder");
        CreateFile("new_file.txt");
        DeleteFile("new_file.txt");
        CreateFolder("source_folder");
        CreateFolder("destination_folder");
        CreateFile("source_folder/new_file.txt");
        MoveFile("source_folder/new_file.txt", "destination_folder/new_file.txt");
        SearchFileByName("new_file.txt");
        ShowAllFilesInDirectory(".");
    }

    static void CreateFolder(string folderName)
    {
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
            Console.WriteLine($"Folder '{folderName}' created.");
        }
        else
        {
            Console.WriteLine($"Folder '{folderName}' already exists.");
        }
    }

    static void ShowCurrentDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Current Directory: {currentDirectory}");
    }

    static void DeleteFolder(string folderName)
    {
        if (Directory.Exists(folderName))
        {
            Directory.Delete(folderName);
            Console.WriteLine($"Folder '{folderName}' deleted.");
        }
        else
        {
            Console.WriteLine($"Folder '{folderName}' does not exist.");
        }
    }

    static void CreateFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
            Console.WriteLine($"File '{fileName}' created.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' already exists.");
        }
    }

    static void DeleteFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.WriteLine($"File '{fileName}' deleted.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' does not exist.");
        }
    }

    static void MoveFile(string sourceFileName, string destFileName)
    {
        if (File.Exists(sourceFileName))
        {
            File.Move(sourceFileName, destFileName);
            Console.WriteLine($"File moved from '{sourceFileName}' to '{destFileName}'.");
        }
        else
        {
            Console.WriteLine($"Source file '{sourceFileName}' does not exist.");
        }
    }

    static void SearchFileByName(string fileName)
    {
        string[] files = Directory.GetFiles(".", fileName, SearchOption.AllDirectories);
        if (files.Length > 0)
        {
            Console.WriteLine($"File '{fileName}' found at:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
    }

    static void ShowAllFilesInDirectory(string directory)
    {
        if (Directory.Exists(directory))
        {
            string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            Console.WriteLine("Files in directory:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        else
        {
            Console.WriteLine($"Directory '{directory}' does not exist.");
        }
    }
}
