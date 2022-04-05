using WordService.DBContexts;
using WordService.Model;

namespace WordService.Repository
{
    public class SingleWordRepository : ISingleWordRepository
    {
        private readonly WordContext _dbContext;
        public SingleWordRepository(WordContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void AddWord(string word)
        {
            if (!_dbContext.SingleWords.Any(x => x.Word == word.ToLower()))
            {
                _dbContext.SingleWords.Add(new SingleWord { Word = word.ToLower(), Count = 0 });
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<SingleWord> GetTop5()
        {
            return _dbContext.SingleWords.OrderByDescending(x => x.Count).Take(5);
        }

        public bool SearchWord(string word)
        {
            var singleWord = _dbContext.SingleWords.SingleOrDefault(x => x.Word == word.ToLower());
            if (singleWord != null)
            {
                singleWord.Count++;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
