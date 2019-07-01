﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reminder.Storage.SqlServer.EF.Context;

namespace Reminder.Storage.SqlServer.EF.DbInit.Migrations
{
    [DbContext(typeof(ReminderStorageContext))]
    partial class ReminderStorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reminder.Storage.SqlServer.EF.Context.ReminderItemDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<int>("Status")
                        .HasColumnName("StatusId");

                    b.Property<DateTimeOffset>("TargetDate")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<DateTimeOffset>("UpdateDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("ReminderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
