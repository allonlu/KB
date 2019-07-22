﻿// <auto-generated />
using KB.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KB.EntityFramework.Migrations
{
    [DbContext(typeof(KBDataContext))]
    partial class KBDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KB.Domain.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<int>("SiteId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("t_KB_Article");
                });

            modelBuilder.Entity("KB.Domain.Entities.ArticleTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<int>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId", "TagId")
                        .IsUnique();

                    b.ToTable("t_KB_ArticlesTagsRelation");
                });

            modelBuilder.Entity("KB.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("t_KB_Tag");
                });
#pragma warning restore 612, 618
        }
    }
}
