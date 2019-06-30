using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Reminder.Storage.SqlServer.EF.Data;

namespace Reminder.Storage.SqlServer.EF
{
    public partial class ReminderItemStorageContext : DbContext
    {
        private readonly string _connectionString;

        public ReminderItemStorageContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        public ReminderItemStorageContext(DbContextOptions<ReminderItemStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReminderItem> ReminderItem { get; set; }
        public virtual DbSet<ReminderItemStatus> ReminderItemStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ReminderItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ReminderItem)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReminderItem_StatusId");
            });

            modelBuilder.Entity<ReminderItemStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReminderItemStatus>().HasData(new Data.ReminderItemStatus() { Id = 0, Name = "Awaiting" });
            modelBuilder.Entity<ReminderItemStatus>().HasData(new Data.ReminderItemStatus() { Id = 1, Name = "Ready" });
            modelBuilder.Entity<ReminderItemStatus>().HasData(new Data.ReminderItemStatus() { Id = 2, Name = "Send" });
            modelBuilder.Entity<ReminderItemStatus>().HasData(new Data.ReminderItemStatus() { Id = 3, Name = "Failed" });
        }
    }
}
