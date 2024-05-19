using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelChainDbManager.Data;

public partial class HotelChainDbContext : DbContext
{
    public HotelChainDbContext()
    {
    }

    public HotelChainDbContext(DbContextOptions<HotelChainDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CompanyPosition> CompanyPositions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<Resident> Residents { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CompanyPosition>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdCardNumber);

            entity.Property(e => e.IdCardNumber).ValueGeneratedNever();
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronimic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.CompanyPositionNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CompanyPosition)
                .HasConstraintName("FK_Employees_CompanyPositions");

            entity.HasOne(d => d.HotelNumberNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.HotelNumber)
                .HasConstraintName("FK_Employees_Hotels");

            /*entity.HasMany(d => d.Rooms).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Service",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomNumber", "HotelNumber")
                        .HasConstraintName("FK_Services_Rooms"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Employee")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Employees"),
                    j =>
                    {
                        j.HasKey("Employee", "RoomNumber", "HotelNumber");
                        j.ToTable("Services");
                    });*/
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Number);

            entity.Property(e => e.Adress).HasMaxLength(50);
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => new { e.Resident, e.RoomNumber, e.HotelNumber });

            entity.HasOne(d => d.ResidentNavigation).WithMany(p => p.Rents)
                .HasForeignKey(d => d.Resident)
                .HasConstraintName("FK_Rents_Residents");

            entity.HasOne(d => d.Room).WithMany(p => p.Rents)
                .HasForeignKey(d => new { d.RoomNumber, d.HotelNumber })
                .HasConstraintName("FK_Rents_Rooms");
        });

        modelBuilder.Entity<Resident>(entity =>
        {
            entity.HasKey(e => e.IdCardNumber);

            entity.Property(e => e.IdCardNumber).ValueGeneratedNever();
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronimic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => new { e.Number, e.HotelNumber }).HasName("PK_Rooms_1");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Class)
                .HasConstraintName("FK_Rooms_Classes");

            entity.HasOne(d => d.HotelNumberNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelNumber)
                .HasConstraintName("FK_Rooms_Hotels");
        });

        modelBuilder.Entity<Service>(entity => 
        {
            entity.HasKey(e => new { e.RoomNumber, e.HotelNumber, e.EmployeeId }).HasName("PK_Services_1");

            entity.HasOne(d => d.Employee).WithMany(p => p.Services)
            .HasForeignKey(d => d.EmployeeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Services_Employees");

            entity.HasOne(d => d.Room).WithMany(p => p.Services)
            .HasForeignKey("RoomNumber", "HotelNumber")
            .HasConstraintName("FK_Services_Rooms");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
