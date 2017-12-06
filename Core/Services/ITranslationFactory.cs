using Core.Domains;

namespace Core.Services
{
    public interface ITranslationFactory
    {
        Translation CreateTranslation(string dataRow);
    }
}