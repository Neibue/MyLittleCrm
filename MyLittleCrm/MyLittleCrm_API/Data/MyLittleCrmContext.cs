using Microsoft.EntityFrameworkCore;
using MyLittleCramApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleCrm_API.Data
{
    public class MyLittleCrmContext : DbContext
    {
        public MyLittleCrmContext(DbContextOptions<MyLittleCrmContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<QuoteLine> QuoteLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Quote>()
                .HasMany(q => q.Products)
                .WithMany(q => q.Quotes)
                .UsingEntity<QuoteLine>(
                    j => j
                        .HasOne(ql => ql.Product)
                        .WithMany(p => p.QuoteLines)
                        .HasForeignKey(ql => ql.ProductID),
                    j => j
                        .HasOne(ql => ql.Quote)
                        .WithMany(p => p.QuoteLines)
                        .HasForeignKey(ql => ql.QuoteID),
                    j =>
                    {
                        j.Property(ql => ql.Quantity).HasDefaultValueSql("1");
                        j.HasKey(ql => new { ql.ProductID, ql.QuoteID });
                    }
                )
                .ToTable("Quote");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<QuoteLine>().ToTable("QuoteLine");
        }
    }
}
