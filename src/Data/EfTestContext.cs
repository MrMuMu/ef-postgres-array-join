using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Ef.Test.Data
{
    public partial class EfTestContext : DbContext
    {
        public EfTestContext()
        {
        }

        public EfTestContext(DbContextOptions<EfTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Table1> Table1s { get; set; }
        public virtual DbSet<Table2> Table2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=ef-test;Username=postgres;Password=a")
                            .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); })).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>(entity =>
            {
                entity.ToTable("table1");

                entity.HasIndex(e => e.Table2Ids, "ix_table1_table2_ids")
                    .HasMethod("gin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Table2Ids).HasColumnName("table2_ids");

                entity.HasData(
                    new() { Id = 1, Table2Ids = new long[] { 1 } },
                    new() { Id = 2, Table2Ids = new long[] { 1, 2 } },
                    new() { Id = 3, Table2Ids = null }
                );
            });

            modelBuilder.Entity<Table2>(entity =>
            {
                entity.ToTable("table2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasData(
                    new() { Id = 1 },
                    new() { Id = 2 }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
