using Microsoft.EntityFrameworkCore;
using WordService.Model;

namespace WordService.DBContexts
{
    public class WordContext : DbContext
    {
        public WordContext() { }

        public WordContext(DbContextOptions<WordContext> options) : base(options)
        {
        }

        public DbSet<SingleWord> SingleWords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=db;Database=master;User=sa;Password=Your_password123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SingleWord>().HasData(
            new SingleWord { 
                Count = 0,
                Word = "hello"
            },
            new SingleWord
            {
                Count = 0,
                Word = "goodbye"
            },
            new SingleWord
            {
                Count = 0,
                Word = "simple"
            },
            new SingleWord
            {
                Count = 0,
                Word = "list"
            },
            new SingleWord
            {
                Count = 0,
                Word = "search"
            },
            new SingleWord
            {
                Count = 0,
                Word = "filter"
            },
            new SingleWord
            {
                Count = 0,
                Word = "yes"
            },
            new SingleWord
            {
                Count = 0,
                Word = "no"
            }             
            );
        }
    }
}
