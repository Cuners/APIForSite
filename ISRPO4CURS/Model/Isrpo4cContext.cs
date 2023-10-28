using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ISRPO4CURS.Model;

public partial class Isrpo4cContext : DbContext
{
    public Isrpo4cContext()
    {
    }

    public Isrpo4cContext(DbContextOptions<Isrpo4cContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bludum> Bluda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-B2RGVBG\\SQLEXPRESS; Database=ISRPO4C; Trusted_Connection=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bludum>(entity =>
        {
            entity.HasKey(e => e.IdBludo);

            entity.Property(e => e.IdBludo).ValueGeneratedNever();
            entity.Property(e => e.Bludo).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
