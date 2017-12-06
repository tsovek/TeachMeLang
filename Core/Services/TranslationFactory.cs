using System;
using Core.Domains;

namespace Core.Services
{
    public class TranslationFactory : ITranslationFactory
    {
        public Translation CreateTranslation(string dataRow)
        {
            string[] splittedTranslation = dataRow.Split(';');

            // expecting: translation type ; english ; polish 
            if (splittedTranslation.Length != 3) throw new InvalidOperationException();

            if (splittedTranslation[0] == "w")
            {
                return new Word
                {
                    English = splittedTranslation[1],
                    Polish = splittedTranslation[2]
                };
            }
            else if (splittedTranslation[0] == "s")
            {
                return new Sentence
                {
                    English = splittedTranslation[1],
                    Polish = splittedTranslation[2]
                };
            }

            throw new NotSupportedException();
        }
    }
}
