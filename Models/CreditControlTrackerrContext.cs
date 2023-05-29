using System;
using System.Collections.Generic;
using CreditControlTrackerAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditContolTrackerAPIs.Models;

public partial class CreditControlTrackerrContext : DbContext
{
    public CreditControlTrackerrContext()
    {
    }

    public CreditControlTrackerrContext(DbContextOptions<CreditControlTrackerrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Aging> Agings { get; set; }

    public virtual DbSet<CompanyCategory> CompanyCategories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }

    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PSL-5CD152103N;Database=CreditControlTrackerr;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CompanyCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("companyCategory");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceNo);

            entity.HasIndex(e => e.AccountTypeId, "IX_InvoiceDetails_AccountTypeId");

            entity.HasIndex(e => e.AgingId, "IX_InvoiceDetails_AgingId");

            entity.HasIndex(e => e.CompanyCategoryId, "IX_InvoiceDetails_CompanyCategoryId");

            entity.HasIndex(e => e.CustomerId, "IX_InvoiceDetails_CustomerId");

            entity.HasIndex(e => e.EntityId, "IX_InvoiceDetails_EntityId");

            entity.HasIndex(e => e.InvoiceStatusId, "IX_InvoiceDetails_InvoiceStatusId");

            entity.HasIndex(e => e.InvoiceTypeId, "IX_InvoiceDetails_InvoiceTypeId");

            entity.HasOne(d => d.AccountType).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.AccountTypeId);

            entity.HasOne(d => d.Aging).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.AgingId);

            entity.HasOne(d => d.CompanyCategory).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.CompanyCategoryId);

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.Entity).WithMany(p => p.invoiceDetail).HasForeignKey(d => d.EntityId);

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.InvoiceStatusId);

            entity.HasOne(d => d.InvoiceType).WithMany(p => p.InvoiceDetails).HasForeignKey(d => d.InvoiceTypeId);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasIndex(e => e.InvoiceNo, "IX_Receipts_InvoiceNo");

            entity.HasOne(d => d.InvoiceNoNavigation).WithMany(p => p.Receipts).HasForeignKey(d => d.InvoiceNo);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
