using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository.Entities;

public partial class shaguarContext : DbContext
{
    public shaguarContext()
    {
    }

    public shaguarContext(DbContextOptions<shaguarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tbl_goods> tbl_goods { get; set; }

    public virtual DbSet<tbl_goodsbatches> tbl_goodsbatches { get; set; }

    public virtual DbSet<tbl_goodsbatchstates> tbl_goodsbatchstates { get; set; }

    public virtual DbSet<tbl_logs> tbl_logs { get; set; }

    public virtual DbSet<tbl_measureunits> tbl_measureunits { get; set; }

    public virtual DbSet<tbl_storeplaces> tbl_storeplaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tbl_goods>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_tbl_goods_id");

            entity.HasIndex(e => e.code, "key_tbl_goods_unique_code").IsUnique();

            entity.HasIndex(e => e.name, "key_tbl_goods_unique_name").IsUnique();

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(555);
        });

        modelBuilder.Entity<tbl_goodsbatches>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_tbl_goodsbatches_id");

            entity.Property(e => e.manufacture_date)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.goods).WithMany(p => p.tbl_goodsbatches)
                .HasForeignKey(d => d.goods_id)
                .HasConstraintName("fk_tbl_goods_tbl_goodsbatches");

            entity.HasOne(d => d.measureunit).WithMany(p => p.tbl_goodsbatches)
                .HasForeignKey(d => d.measureunit_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_measureunits_tbl_goodsbatches");

            entity.HasOne(d => d.state).WithMany(p => p.tbl_goodsbatches)
                .HasForeignKey(d => d.state_id)
                .HasConstraintName("fk_tbl_goodsbatchstates_tbl_goodsbatches");

            entity.HasOne(d => d.storeplace).WithMany(p => p.tbl_goodsbatches)
                .HasForeignKey(d => d.storeplace_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_storeplaces_tbl_goodsbatches");
        });

        modelBuilder.Entity<tbl_goodsbatchstates>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_tbl_goodsbatchstates_id");

            entity.HasIndex(e => e.name, "key_tbl_goodsbatchstates_unique_name").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.name).HasMaxLength(250);
        });

        modelBuilder.Entity<tbl_logs>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<tbl_measureunits>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_tbl_measureunits_id");

            entity.HasIndex(e => e.code, "key_tbl_measureunits_unique_code").IsUnique();

            entity.HasIndex(e => e.name, "key_tbl_measureunits_unique_name").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(555);
        });

        modelBuilder.Entity<tbl_storeplaces>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_tbl_storeplaces_id");

            entity.HasIndex(e => e.code, "key_tbl_storeplaces_unique_code").IsUnique();

            entity.HasIndex(e => e.name, "key_tbl_storeplaces_unique_name").IsUnique();

            entity.Property(e => e.code).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(555);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
