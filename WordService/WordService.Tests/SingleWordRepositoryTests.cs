using Moq;
using WordService.DBContexts;
using Xunit;
using Microsoft.EntityFrameworkCore;
using WordService.Model;
using System.Linq;
using WordService.Repository;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace WordService.Tests
{
    public class SingleWordRepositoryTests
    {
        [Fact]
        public void SearchWord_ReturnsTrue_WhenFindsTheWordAndUpdatesTheWordCounter()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;

            using (var context = new WordContext(options))
            {
                context.SingleWords.Add(new SingleWord { Word = "okay", Count = 0 });
                context.SaveChanges();
            }

            using (var context = new WordContext(options))
            {
                var singleWordRepository = new SingleWordRepository(context);
                var result = singleWordRepository.SearchWord("okay");
                var updatedData = context.SingleWords.Single(s => s.Word == "okay");

                
                Assert.True(result);
                Assert.Equal(1, updatedData.Count);
            }
        }

        [Fact]
        public void SearchWord_ReturnsFalse_WhenDoesNotFindTheWord()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;

            using (var context = new WordContext(options))
            {
                var singleWordRepository = new SingleWordRepository(context);
                var result = singleWordRepository.SearchWord("test");

                Assert.False(result);
            }
        }

        [Fact]
        public void AddWord_InsertsNewWord_WhenWordIsNotInTheTable()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;
            
            using (var context = new WordContext(options))
            {
                var singleWordRepository = new SingleWordRepository(context);
                var resultBefore = context.SingleWords.Any(s => s.Word == "newword");
                singleWordRepository.AddWord("newword");
                var resultAfter = context.SingleWords.Any(s => s.Word == "newword");

                Assert.False(resultBefore);
                Assert.True(resultAfter);
            }
        }

        [Fact]
        public void AddWord_DoesNothing_WhenWordIsAlreadyInTheTable()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;

            using (var context = new WordContext(options))
            {
                context.SingleWords.Add(new SingleWord { Word = "iwashere", Count = 0 });
                context.SaveChanges();
            }

            using (var context = new WordContext(options))
            {
                var singleWordRepository = new SingleWordRepository(context);
                var qtyBefore = context.SingleWords.Count();
                singleWordRepository.AddWord("iwashere");
                var qtyAfter = context.SingleWords.Count();

                Assert.Equal(qtyBefore, qtyAfter);
            }
        }

        [Fact]
        public void GetTop5_ReturnsListWith5MostSearchedWords_WhenCalled()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;

            using (var context = new WordContext(options))
            {
                context.SingleWords.Add(new SingleWord { Word = "foreveralone", Count = 0 });
                context.SingleWords.Add(new SingleWord { Word = "top1", Count = 1000 });
                context.SingleWords.Add(new SingleWord { Word = "top2", Count = 900 });
                context.SingleWords.Add(new SingleWord { Word = "top3", Count = 800 });
                context.SingleWords.Add(new SingleWord { Word = "top4", Count = 700 });
                context.SingleWords.Add(new SingleWord { Word = "top5", Count = 600 });
                context.SaveChanges();
            }

            using (var context = new WordContext(options))
            {
                var singleWordRepository = new SingleWordRepository(context);
                var result = singleWordRepository.GetTop5();

                Assert.Contains(result, r => r.Word == "top1");
                Assert.Contains(result, r => r.Word == "top5");
                Assert.DoesNotContain(result, r => r.Word == "foreveralone");
            }
        }
    }
}