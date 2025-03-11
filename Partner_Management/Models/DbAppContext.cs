using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Partner_Management.Models;

public partial class DbAppContext : DbContext
{
    public DbAppContext()
    {
    }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localHost;Username=postgres;Database=demo_exam");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("material_types_pkey");

            entity.ToTable("material_types");

            entity.HasIndex(e => e.MaterialTypeName, "material_types_material_type_name_key").IsUnique();

            entity.Property(e => e.MaterialTypeId).HasColumnName("material_type_id");
            entity.Property(e => e.BrokenCoefficient)
                .HasPrecision(10, 6)
                .HasColumnName("broken_coefficient");
            entity.Property(e => e.MaterialTypeName)
                .HasMaxLength(255)
                .HasColumnName("material_type_name");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.HasIndex(e => e.Tin, "partners_tin_key").IsUnique();

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.CeoName)
                .HasMaxLength(255)
                .HasColumnName("ceo_name");
            entity.Property(e => e.Discount)
                .HasPrecision(5, 2)
                .HasColumnName("discount");
            entity.Property(e => e.PartnerAddress)
                .HasMaxLength(255)
                .HasColumnName("partner_address");
            entity.Property(e => e.PartnerEmail)
                .HasMaxLength(50)
                .HasColumnName("partner_email");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(255)
                .HasColumnName("partner_name");
            entity.Property(e => e.PartnerPhone)
                .HasMaxLength(30)
                .HasColumnName("partner_phone");
            entity.Property(e => e.PartnerType).HasColumnName("partner_type");
            entity.Property(e => e.Rating)
                .HasPrecision(2)
                .HasColumnName("rating");
            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .HasColumnName("tin");

            entity.HasOne(d => d.PartnerTypeNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partners_partner_type_fkey");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.PartnerId }).HasName("partner_products_pkey");

            entity.ToTable("partner_products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.SellDate).HasColumnName("sell_date");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_partner_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_products_product_id_fkey");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.PartnerTypeId).HasName("partner_types_pkey");

            entity.ToTable("partner_types");

            entity.HasIndex(e => e.PartnerTypeName, "partner_types_partner_type_name_key").IsUnique();

            entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");
            entity.Property(e => e.PartnerTypeName)
                .HasMaxLength(255)
                .HasColumnName("partner_type_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Articul, "products_articul_key").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Articul)
                .HasMaxLength(255)
                .HasColumnName("articul");
            entity.Property(e => e.MinCost).HasColumnName("min_cost");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_product_type_id_fkey");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("product_types_pkey");

            entity.ToTable("product_types");

            entity.HasIndex(e => e.ProductTypeName, "product_types_product_type_name_key").IsUnique();

            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");
            entity.Property(e => e.ProductTypeName)
                .HasMaxLength(255)
                .HasColumnName("product_type_name");
            entity.Property(e => e.TypeCoefficient)
                .HasPrecision(10, 2)
                .HasColumnName("type_coefficient");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
