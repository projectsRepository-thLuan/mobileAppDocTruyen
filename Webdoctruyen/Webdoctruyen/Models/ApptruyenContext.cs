using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Webdoctruyen.Models;

public partial class ApptruyenContext : DbContext
{
    public ApptruyenContext()
    {
    }

    public ApptruyenContext(DbContextOptions<ApptruyenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danhgium> Danhgia { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Truyen> Truyens { get; set; }

    public virtual DbSet<Voice> Voices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Danhgium>(entity =>
        {
            entity
                .ToTable("danhgia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTaikhoan).HasColumnName("id_taikhoan");
            entity.Property(e => e.IdTruyen).HasColumnName("id_truyen");
            entity.Property(e => e.Noidung)
                .HasMaxLength(1)
                .HasColumnName("noidung");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity
                .ToTable("taikhoan");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(16)
                .HasColumnName("matkhau");
            entity.Property(e => e.Phanquyen).HasColumnName("phanquyen");
            entity.Property(e => e.Tentaikhoan)
                .HasMaxLength(20)
                .HasColumnName("tentaikhoan");
        });

        modelBuilder.Entity<Truyen>(entity =>
        {
            entity
                .ToTable("truyen");

            entity.Property(e => e.Anh)
                .HasMaxLength(1)
                .HasColumnName("anh");
            entity.Property(e => e.IdTk).HasColumnName("id_tk");
            entity.Property(e => e.Noidung)
                .HasMaxLength(1)
                .HasColumnName("noidung");
            entity.Property(e => e.Tentruyen)
                .HasMaxLength(1)
                .HasColumnName("tentruyen");
        });

        modelBuilder.Entity<Voice>(entity =>
        {
            entity.ToTable("voice");

            entity.Property(e => e.IdTruyen).HasColumnName("id_truyen");
            entity.Property(e => e.Link)
                .HasMaxLength(1)
                .HasColumnName("link");
            entity.Property(e => e.Nhanvat).HasColumnName("nhanvat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
