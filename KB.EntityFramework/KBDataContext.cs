
using KB.Domain.Entities;
using KB.Infrastructure.Ioc;
using KB.Infrastructure.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace KB.EntityFramework
{

    public class KBDataContext : DbContext
    {
        private IConfiguration _configuration;
        [Mandatory]
        public ISession Session { get; set; }


        public KBDataContext()
        {
        }
        //public KBDataContext(IConfiguration configuration)
        //{
        //    _configuration=configuration;
        //}

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// 自动更新SiteId
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is IMustHaveSiteId)
                    {
                        ((IMustHaveSiteId)entry.Entity).SiteId = Session.GetSiteId();
                    }
                }

            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=KBTest1;User=sa;Password=Aa000000;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .HasQueryFilter(a => a.SiteId == Session.GetSiteId())
                .ToTable("t_KB_Article")
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tag>(
                  entity =>
                  {
                      entity.ToTable("t_KB_Tag")
                            .HasQueryFilter(a => a.SiteId == Session.GetSiteId())
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
            modelBuilder.Entity<Category>(
            entity =>
            {
                entity.ToTable("t_KB_Category")
                      .HasKey(t => t.Id);

            }
          );
        }
    }
}
