﻿using System;
using System.Collections.Generic;

using Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


namespace Reposetories;

public partial class MyShop328120357Context : DbContext
{
    public MyShop328120357Context()
    {
    }

    public MyShop328120357Context(DbContextOptions<MyShop328120357Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Rating> Rating { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SRV2\\PUPILS;Database=MyShop_328120357;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Orders");

            entity.ToTable("Order");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Users");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Descraption).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
        });
        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("RATING");

            entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

            entity.Property(e => e.Host)
                .HasColumnName("HOST")
                .HasMaxLength(50);

            entity.Property(e => e.Method)
                .HasColumnName("METHOD")
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.Path)
                .HasColumnName("PATH")
                .HasMaxLength(50);

            entity.Property(e => e.RecordDate)
             .HasColumnName("Record_Date")
             .HasColumnType("datetime");

            entity.Property(e => e.Referer)
                .HasColumnName("REFERER")
                .HasMaxLength(100);

            entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
