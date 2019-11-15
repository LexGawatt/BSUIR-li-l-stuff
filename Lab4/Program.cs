using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var root = "D:\\univer\\oop\\OOP\\Lab4\\test";
//            Task1(root);
//            Task2(root);

            var task3Root = "D:\\univer\\oop\\OOP\\Lab4\\task3.test";
//            GenerateFiles(task3Root);
            Task3(task3Root);
        }

        // find files by mask and start and end date, then write them to result file
        private static void Task1(string root)
        {
            var customFile = new CustomFile(root);
            var filePattern = "*.txt";
            var startDate = DateTime.Parse("2017-12-2");
            var endDate = DateTime.Parse("2018-12-2");

            var files = customFile
                .FindFilesByMaskAndDateModified(filePattern, startDate, endDate)
                .ToList();

            var resultFilename = "D:\\univer\\oop\\OOP\\Lab4\\result.txt";
            File.WriteAllText(resultFilename, $"File search results for pattern: {filePattern}, " +
                                              $"start: {startDate}, " +
                                              $"end: {endDate}\n");

            if (!files.Any())
            {
                File.AppendAllText(resultFilename, "No files found.\n");
            }
            else
            {
                File.AppendAllLines(resultFilename,
                    files.Select(fileInfo => fileInfo.FullName + " : " + fileInfo.LastWriteTime));
            }
        }

        //find files with mask and replace content in them
        private static void Task2(string root)
        {
            var customFile = new CustomFile(root);
            var filePattern = "*.txt";
            var searchString = "Hello World";
            var replaceString = "placeholder";

            Console.WriteLine($"Replacing `{searchString}` with `{replaceString}` in files: {filePattern}");
            customFile.ReplaceTextInFilesWith(filePattern, searchString, replaceString);
        }

        //find files with mask and ask for user input to delete them
        private static void Task3(string root)
        {
            var customFile = new CustomFile(root);
            var filePattern = "*.*";
            var i = 1;
            var files = customFile.FindFilesByMask(filePattern)
                .ToDictionary(file => i++, file => file);
            Console.WriteLine($"Found files with pattern: `{filePattern}`:");
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Key}: {file.Value.FullName}");
            }

            List<int> range;
            while (true)
            {
                Console.Write("Select which files to delete(e.g. 1, 1-3, *): ");

                var readLine = Console.ReadLine();
                range = ParseInput(readLine, i).ToList();
                if (range.Count > 0)
                    break;

                Console.WriteLine("Invalid input ");
            }

            foreach (var key in range)
            {
                var parent = new FileInfo(files[key].FullName).Directory;
                var oldParentName = "";
                if (parent != null && !parent.FullName.Equals(root))
                {
                    oldParentName = parent.FullName.Replace(root, "");
                    Directory.CreateDirectory(@"D:\\univer\\oop\\OOP\\Lab4\\recycle.bin\\" + oldParentName);
                }

                if (new FileInfo(files[key].FullName).Exists)
                {
                    File.Move(files[key].FullName,
                        $"D:\\univer\\oop\\OOP\\Lab4\\recycle.bin\\{oldParentName}\\{files[key].Name}");
                }
                else if(new DirectoryInfo(files[key].FullName).Exists)
                {
                    Directory.Move(files[key].FullName,
                        $"D:\\univer\\oop\\OOP\\Lab4\\recycle.bin\\{oldParentName}\\{files[key].Name}");
                }
            }

            var resultString = string.Join(",", range);
            Console.WriteLine($"Files {resultString} are removed");
        }

        private static IEnumerable<int> ParseInput(string input, int max)
        {
            if (input.Trim().Equals("*"))
            {
                return Enumerable.Range(1, max - 1);
            }

            if (input.Contains("-"))
            {
                var spl = input.Split('-');
                if (spl.Length > 2)
                    return Enumerable.Empty<int>();

                try
                {
                    var num1 = int.Parse(spl[0].Trim());
                    var num2 = int.Parse(spl[1].Trim());
                    if (num1 < num2 && num2 < max)
                        return Enumerable.Range(num1, num2 - num1 + 1);

                    return Enumerable.Empty<int>();
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            try
            {
                var num = int.Parse(input.Trim());
                if (num < max)
                    return Enumerable.Range(num, 1);

                return Enumerable.Empty<int>();
            }
            catch (Exception)
            {
                // ignored
            }

            return Enumerable.Empty<int>();
        }
    }
}