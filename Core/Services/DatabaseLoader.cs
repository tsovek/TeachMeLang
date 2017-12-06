using System.Collections.Generic;
using Core.Domains;

namespace Core.Services
{
    public class DatabaseLoader
    {
        const char _separator = ';';

        private readonly ITranslationFactory _translationFactory;
        private readonly IFileLoader _fileLoader;

        public DatabaseLoader(ITranslationFactory translationFactory, IFileLoader fileLoader)
        {
            _translationFactory = translationFactory;
            _fileLoader = fileLoader;
        }

        public IEnumerable<Translation> Load(string path)
        {
            string fileContent = _fileLoader.GetContent(path);

            int interator = 0;
            while (interator < fileContent.Length)
            {
                char starter = fileContent[interator];
                if (starter != _separator)
                {
                    interator++;
                    continue;
                }

                int lenght = GetIndexOfEndSeparator(fileContent, interator) - interator;
                string translationRow = fileContent.Substring(interator + 1, lenght - 1); // eliminate separators

                yield return _translationFactory.CreateTranslation(translationRow);
                interator += lenght + 1; // to next char
            }
        }

        private static int GetIndexOfEndSeparator(string fileContent, int indexOfBeginSeparator)
        {
            int iterator = indexOfBeginSeparator;
            int separatorsCounter = 0;
            while (separatorsCounter < 3 && ++iterator < fileContent.Length) // abort after third separator
            {
                if (fileContent[iterator] == _separator)
                {
                    separatorsCounter++;
                }
            }
            return iterator;
        }
    }
}
