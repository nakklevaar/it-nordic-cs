using ConsoleApp38.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp38.Data
{
    class СorrespondenceEFContext:DbContext
    {
        private string _connectionString;

        public DbSet<Address> Address { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Contractor> Contractor { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<PostalItem> PostalItem { get; set; }

        public DbSet<SendingStatus> SendingStatus { get; set; }

        public DbSet<Status> Status { get; set; }



        public СorrespondenceEFContext()
        {
            _connectionString = @"Data Source=localhost\SQLEXPRESS;"
                + "Initial Catalog = OnlineStoreEF;"
                + "Integrated Security=true";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region restrictions
            modelBuilder.Entity<Address>().Property(a => a.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Address>().Property(a => a.Name).HasMaxLength(250).IsUnicode(false).IsRequired();

            modelBuilder.Entity<City>().Property(c => c.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<City>().Property(c => c.Name).HasMaxLength(250).IsUnicode(false).IsRequired();

            modelBuilder.Entity<Contractor>().Property(c => c.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Contractor>().Property(c => c.Name).HasMaxLength(250).IsUnicode(false).IsRequired();

            modelBuilder.Entity<Position>().Property(p => p.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.Name).HasMaxLength(250).IsUnicode(false).IsRequired();

            modelBuilder.Entity<PostalItem>().Property(p => p.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<PostalItem>().Property(p => p.Name).HasMaxLength(250).IsUnicode(false).IsRequired();
            modelBuilder.Entity<PostalItem>().Property(p => p.NumberOfPages).IsRequired();

            modelBuilder.Entity<Status>().Property(s => s.Id).ValueGeneratedNever().IsRequired();
            modelBuilder.Entity<Status>().Property(s => s.Name).HasMaxLength(20).IsUnicode(false).IsRequired();
            #endregion

            #region foreign key
            modelBuilder.Entity<Address>().HasOne(a => a.City).WithMany(c => c.Addresses).IsRequired();
            modelBuilder.Entity<Address>().HasMany(a => a.ReceivingAddresses).WithOne(r => r.ReceivingAddress).IsRequired();
            modelBuilder.Entity<Address>().HasMany(a => a.SendingAddresses).WithOne(s => s.SendingAddress).IsRequired();

            modelBuilder.Entity<Contractor>().HasOne(c => c.Position).WithMany(p => p.Contractors).IsRequired();
            modelBuilder.Entity<Contractor>().HasMany(c => c.ReceivingContractors).WithOne(r => r.ReceivingContractor).IsRequired();
            modelBuilder.Entity<Contractor>().HasMany(c => c.SendingContractors).WithOne(s => s.SendingContractor).IsRequired();

            modelBuilder.Entity<PostalItem>().HasMany(p => p.PostalItems).WithOne(p => p.PostalItem).IsRequired();

            modelBuilder.Entity<Status>().HasMany(s => s.Statuses).WithOne(s => s.Status).IsRequired();
            #endregion

            modelBuilder.Entity<City>().HasAlternateKey(c => c.Name).HasName("UQ_City_Name");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
