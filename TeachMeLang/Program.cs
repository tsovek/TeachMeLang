using Core.Services;
using System;
using System.Linq;

namespace TeachMeLang
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Tomasz\Desktop\eng.txt"; // move to arg
            var trans = new DatabaseLoader(new TranslationFactory(), new FileLoader()).Load(filePath).ToList();

            Console.ReadKey();
        }
    }
}
