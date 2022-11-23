using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstDemo.Models;

public partial class HarryPotterDbContext : DbContext
{
    public HarryPotterDbContext()
    {
    }

    public HarryPotterDbContext(DbContextOptions<HarryPotterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Familiar> Familiars { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarryPotterDb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Familiar>(entity =>
        {
            entity.HasKey(e => e.FamiliarId).HasName("PK__Familiar__267867936608C7FA");

            entity.Property(e => e.AnimalType).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(15);

            entity.HasOne(d => d.Student).WithMany(p => p.Familiars)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Familiars_Students");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.HouseId).HasName("PK__Houses__085D128F8481E861");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9903383668");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.House).WithMany(p => p.Students)
                .HasForeignKey(d => d.HouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Houses");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
