using WordService.Model;

namespace WordService.Repository
{
    public interface ISingleWordRepository
    {
        bool SearchWord(string word);
        void AddWord(string word);
        IEnumerable<SingleWord> GetTop5();
    }
}
