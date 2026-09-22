using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        Console.WriteLine("================================");
        Console.WriteLine("      File Integrity Checker");
        Console.WriteLine("================================");

        Console.Write("\nEnter the path of the file to check: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nError: File not found.");
            return;
        }

        string currentHash = CalculateHash(filePath);

        Console.WriteLine("\nFile: " + Path.GetFileName(filePath));
        Console.WriteLine("\nCurrent SHA-256 Hash:");
        Console.WriteLine(currentHash);

        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Save this hash as the original");
        Console.WriteLine("2. Compare with a saved hash");

        Console.Write("\nChoose an option: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            SaveHash(filePath, currentHash);
            Console.WriteLine("\nOriginal hash saved successfully.");
        }
        else if (choice == "2")
        {
            string savedHash = LoadHash(filePath);

            if (savedHash == null)
            {
                Console.WriteLine("\nNo original hash was found for this file.");
                Console.WriteLine("Save an original hash first.");
                return;
            }

            Console.WriteLine("\nOriginal SHA-256 Hash:");
            Console.WriteLine(savedHash);

            Console.WriteLine("\nChecking file integrity...");

            if (currentHash == savedHash)
            {
                Console.WriteLine("\nSTATUS: FILE UNCHANGED ✓");
            }
            else
            {
                Console.WriteLine("\nSTATUS: WARNING!");
                Console.WriteLine("The file has been modified!");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid option.");
        }
    }

    static string CalculateHash(string filePath)
    {
        using (SHA256 sha256 = SHA256.Create())
        using (FileStream stream = File.OpenRead(filePath))
        {
            byte[] hash = sha256.ComputeHash(stream);

            return Convert.ToHexString(hash);
        }
    }

    static void SaveHash(string filePath, string hash)
    {
        string hashFile = filePath + ".hash";
        File.WriteAllText(hashFile, hash);
    }

    static string LoadHash(string filePath)
    {
        string hashFile = filePath + ".hash";

        if (File.Exists(hashFile))
        {
            return File.ReadAllText(hashFile);
        }

        return null;
    }
}
