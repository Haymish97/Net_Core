using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Net_Core.Models.Entities;

public partial class ShopFoodContext : DbContext
{
    public ShopFoodContext()
    {
    }

    public ShopFoodContext(DbContextOptions<ShopFoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAgent> TblAgents { get; set; }

    public virtual DbSet<TblBanner> TblBanners { get; set; }

    public virtual DbSet<TblBill> TblBills { get; set; }

    public virtual DbSet<TblBillDetail> TblBillDetails { get; set; }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblFactory> TblFactories { get; set; }

    public virtual DbSet<TblLegal> TblLegals { get; set; }

    public virtual DbSet<TblPosition> TblPositions { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductBrand> TblProductBrands { get; set; }

    public virtual DbSet<TblProductUnit> TblProductUnits { get; set; }

    public virtual DbSet<TblType> TblTypes { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=shop_food;Integrated Security=True;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAgent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_agent");

            entity.ToTable("tbl_agent");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_address");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("_area");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("_city");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("_district");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_email");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_phone");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("('')")
                .HasColumnName("_status");
        });

        modelBuilder.Entity<TblBanner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_banner");

            entity.ToTable("tbl_banner");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("no_image.jpg")
                .HasColumnName("_file_name");
            entity.Property(e => e.IdType)
                .HasDefaultValue(0)
                .HasColumnName("_id_type");
            entity.Property(e => e.LinkTag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_link_tag");
            entity.Property(e => e.No)
                .HasDefaultValue(0)
                .HasColumnName("_no");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
        });

        modelBuilder.Entity<TblBill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_bill");

            entity.ToTable("tbl_bill");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Code)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_code");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.IdType)
                .HasDefaultValue(0)
                .HasColumnName("_id_type");
            entity.Property(e => e.IdUser).HasColumnName("_id_user");
            entity.Property(e => e.Payment)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("_payment");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("_status");
            entity.Property(e => e.Total)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("_total");
            entity.Property(e => e.UpadtedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("_upadted_date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TblBills)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("fk_bill_customer");
        });

        modelBuilder.Entity<TblBillDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdBill, e.IdProduct }).HasName("pk_bill_detail");

            entity.ToTable("tbl_bill_detail");

            entity.Property(e => e.IdBill).HasColumnName("_id_bill");
            entity.Property(e => e.IdProduct).HasColumnName("_id_product");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(0)
                .HasColumnName("_quantity");
            entity.Property(e => e.Total)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("_total");

            entity.HasOne(d => d.IdBillNavigation).WithMany(p => p.TblBillDetails)
                .HasForeignKey(d => d.IdBill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bill_id");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TblBillDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bill_defail_product");
        });

        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_blog");

            entity.ToTable("tbl_blog");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Content)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("_content");
            entity.Property(e => e.IdCategory).HasColumnName("_id_category");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_image_name");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("_updated_date");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TblBlogs)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("fk_blog_category");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_cate");

            entity.ToTable("tbl_category");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.IdType)
                .HasDefaultValue(0)
                .HasColumnName("_id_type");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_image");
            entity.Property(e => e.No)
                .HasDefaultValue(0)
                .HasColumnName("_no");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_contact");

            entity.ToTable("tbl_contact");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Address)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("_address");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_email");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblFactory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_factory");

            entity.ToTable("tbl_factory");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_address");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_image_name");
            entity.Property(e => e.Info)
                .HasDefaultValue("")
                .HasColumnType("ntext")
                .HasColumnName("_info");
            entity.Property(e => e.Intro)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_intro");
            entity.Property(e => e.Name)
                .HasDefaultValue("")
                .HasColumnName("_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
        });

        modelBuilder.Entity<TblLegal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_legal");

            entity.ToTable("tbl_legal");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("_created_date");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_file_name");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("('')")
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pos");

            entity.ToTable("tbl_position");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_product");

            entity.ToTable("tbl_product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValue("")
                .HasColumnName("_description");
            entity.Property(e => e.IdBrand).HasColumnName("_id_brand");
            entity.Property(e => e.IdCategory).HasColumnName("_id_category");
            entity.Property(e => e.IdUnit).HasColumnName("_id_unit");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_image_name");
            entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("_price");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.IdBrand)
                .HasConstraintName("fk_product_brand");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("fk_product_category");

            entity.HasOne(d => d.IdUnitNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.IdUnit)
                .HasConstraintName("fk_product_unit");
        });

        modelBuilder.Entity<TblProductBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_product_brand");

            entity.ToTable("tbl_product_brand");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblProductUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_product_unit");

            entity.ToTable("tbl_product_unit");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_type");

            entity.ToTable("tbl_type");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_title");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_user");

            entity.ToTable("tbl_user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("_address");
            entity.Property(e => e.Cart)
                .HasMaxLength(2000)
                .HasDefaultValue("")
                .HasColumnName("_cart");
            entity.Property(e => e.Email)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_email");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .HasDefaultValue("")
                .HasColumnName("_name");
            entity.Property(e => e.Password)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("_status");
            entity.Property(e => e.UserType).HasColumnName("_user_type");
            entity.Property(e => e.Username)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("_username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
