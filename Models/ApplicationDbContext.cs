using CreditControlTrackerAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditContolTrackerAPIs.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
        public virtual DbSet<AnalyticReport> AnalyticReports { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<TotalAnalysis> TotalAnalysis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>()
                .HasOne<Entity>(o => o.Entity)
                .WithMany(c => c.invoiceDetail)
                .HasForeignKey(o => o.EntityId);
        }
    }
}
