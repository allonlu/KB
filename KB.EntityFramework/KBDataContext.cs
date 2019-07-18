
using KB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KB.EntityFramework
{


    public class KBDataContext : DbContext
    {
        public KBDataContext() 
        {

        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=KBTest;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .ToTable("t_KB_Article")
                .HasKey(t=>t.Id);

            modelBuilder.Entity<Tag>(
                  entity =>
                  {
                      entity.ToTable("t_KB_Tag")
                            .HasKey(t => t.Id);

                      entity.HasIndex(t => t.Name).IsUnique();
                  }
                );

                
                


            modelBuilder.Entity<ArticleTag>(
                  entity =>
                  {
                      entity.ToTable("t_KB_ArticlesTagsRelation")
                            .HasKey(t => t.Id);
                      entity.HasIndex(t => new { t.ArticleId, t.TagId }).IsUnique();

                  }
                );
        }
    }
}
