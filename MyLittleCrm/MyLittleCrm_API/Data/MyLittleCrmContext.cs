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
            modelBuilder.Entity<Quote>().ToTable("Quote");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<QuoteLine>().ToTable("QuoteLine");
        }
    }
}
