using Newtonsoft.Json;
using System;
using System.Linq;

namespace DirectoryFilesStreams
{
    internal class Program
    {
        private static string filePath = @"D:\DirectoryFilesStreams\DirectoryFilesStreams\Files\names.json";
        static void Main(string[] args)
        {
            Add("Xeyal");
            Add("Yusif");
            Add("Kenan");
            Add("Mahir");

            Console.WriteLine(Search("Kenan", x => x == "Kenan"));
            Delete("Yusif");
        }
        public static void Add(string name)
        {
            List<string> names = DeserializeData();
            names.Add(name);
            SerializeData(names);
        }
        public static bool Search(string name, Predicate<string> condition)
        {
            List<string> names = DeserializeData();
            return names.Any(condition);
        }
        public static void Delete(string name)
        {
            List<string> names = DeserializeData();
            names.Remove(name);
            SerializeData(names);
        }
        private static List<string> DeserializeData()
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<string>>(jsonData);
            }
            else
            {
                return new List<string>();
            }
        }
        private static void SerializeData(List<string> names)
        {
            string jsonData = JsonConvert.SerializeObject(names);
            File.WriteAllText(filePath, jsonData);
        }
    }
}