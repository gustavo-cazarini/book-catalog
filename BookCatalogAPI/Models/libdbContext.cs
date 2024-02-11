using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookCatalogAPI.Models
{
    public partial class libdbContext : DbContext
    {
        public libdbContext()
        {
        }

        public libdbContext(DbContextOptions<libdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookAuthor> BookAuthors { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategories { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=libdb;uid=root;pwd=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biography)
                    .HasColumnType("text")
                    .HasColumnName("biography");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.HasIndex(e => e.FkPublisher, "fk_BookPublisher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cover)
                    .HasMaxLength(255)
                    .HasColumnName("cover");

                entity.Property(e => e.FkPublisher).HasColumnName("fk_publisher");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .HasColumnName("isbn");

                entity.Property(e => e.NumPages).HasColumnName("num_pages");

                entity.Property(e => e.PublishDate).HasColumnName("publish_date");

                entity.Property(e => e.Synopsis)
                    .HasColumnType("text")
                    .HasColumnName("synopsis");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.FkPublisherNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.FkPublisher)
                    .HasConstraintName("fk_BookPublisher");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_author");

                entity.HasIndex(e => e.FkAuthor, "fk_book_author_author");

                entity.HasIndex(e => e.FkBook, "fk_book_author_book");

                entity.Property(e => e.FkAuthor).HasColumnName("fk_author");

                entity.Property(e => e.FkBook).HasColumnName("fk_book");

                entity.HasOne(d => d.FkAuthorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkAuthor)
                    .HasConstraintName("fk_book_author_author");

                entity.HasOne(d => d.FkBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkBook)
                    .HasConstraintName("fk_book_author_book");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_category");

                entity.HasIndex(e => e.FkBook, "fk_book_category_book");

                entity.HasIndex(e => e.FkCategory, "fk_book_category_category");

                entity.Property(e => e.FkBook).HasColumnName("fk_book");

                entity.Property(e => e.FkCategory).HasColumnName("fk_category");

                entity.HasOne(d => d.FkBookNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkBook)
                    .HasConstraintName("fk_book_category_book");

                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkCategory)
                    .HasConstraintName("fk_book_category_category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publisher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
