using System;
using System.IO;

namespace Core.Services
{
    public class FileLoader : IFileLoader
    {
        public string GetContent(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
