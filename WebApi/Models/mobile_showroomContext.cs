using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi1.Models
{
    public partial class mobile_showroomContext : DbContext
    {
        public mobile_showroomContext()
        {
        }

        public mobile_showroomContext(DbContextOptions<mobile_showroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PrdImage> PrdImages { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrdImage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Prd_Images");

                entity.Property(e => e.Image1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image4");

                entity.Property(e => e.PrdId).HasColumnName("prd_Id");

                entity.HasOne(d => d.Prd)
                    .WithMany()
                    .HasForeignKey(d => d.PrdId)
                    .HasConstraintName("FK__Prd_Image__prd_I__37A5467C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY");

                entity.Property(e => e.DescriptionPrd)
                    .HasColumnType("text")
                    .HasColumnName("DESCRIPTION_PRD");

                entity.Property(e => e.DiscountPercentage).HasColumnName("DISCOUNT_PERCENTAGE");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Rating).HasColumnName("RATING");

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.Property(e => e.Thumbnail)
                    .HasColumnType("text")
                    .HasColumnName("THUMBNAIL");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                    
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
