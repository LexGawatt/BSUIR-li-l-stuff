using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab4
{
    public class CustomFile
    {
        private string root;

        public CustomFile(string root)
        {
            if (!(new FileInfo(root).Exists || new DirectoryInfo(root).Exists))
                throw new ArgumentException($"File {root} does not exists!");

            if ((File.GetAttributes(root) & FileAttributes.Directory) != FileAttributes.Directory)
                throw new ArgumentException("Given root is not a dir");
            
            this.root = root;
        }
        
        public IEnumerable<FileSystemInfo> FindFilesByMaskAndDateModified(string filePattern, DateTime start, DateTime end)
        {
            return Directory.EnumerateFiles(root, filePattern, SearchOption.AllDirectories)
                .Select(filename => new FileInfo(filename))
                .Where(file => file.LastWriteTime >= start && file.LastWriteTime <= end)
                .ToList();
        }

        public void ReplaceTextInFilesWith(string filePattern, string textToSearch, string replacementText)
        {
            var files = Directory.EnumerateFiles(root, filePattern, SearchOption.AllDirectories);
            foreach (var filename in files)
            {
                var modified = false;
                var lines = File.ReadLines(filename).Select(line =>
                {
                    var replace = line.Replace(textToSearch, replacementText);
                    if (!replace.Equals(line))
                        modified = true;

                    return replace;
                }).ToList();

                if (modified)
                {
                    File.WriteAllLines(filename, lines);
                }
            }
        }
        
        public IEnumerable<FileSystemInfo> FindFilesByMask(string filePattern)
        {
            return Directory.EnumerateFileSystemEntries(root, filePattern, SearchOption.AllDirectories)
                .Select(filename => new FileInfo(filename))
                .ToList();
        }
    }
}