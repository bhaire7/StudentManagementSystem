
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Converter to persist DateOnly as DateTime in the database
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d));

            modelBuilder.Entity<Student>(b =>
            {
                b.Property(s => s.DateOfBirth)
                 .HasConversion(dateOnlyConverter)
                 .HasColumnType("datetime2");

                b.Property(s => s.EnrollmentDate)
                 .HasConversion(dateOnlyConverter)
                 .HasColumnType("datetime2");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
