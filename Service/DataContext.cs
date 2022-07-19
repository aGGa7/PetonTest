using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;

namespace Service.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectObject> Objects { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        private void ConfigureProjects(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Project>()
                                     .ToTable("ProjectsAndObjects");
            entity.HasDiscriminator<string>("Discriminator")
                  .HasValue<Project>("project");
            entity.HasKey(p => p.Cipher);
            entity.Property(p => p.Cipher).HasColumnName("cipher");
            entity.Property(p => p.Executor).HasColumnName("executor");
            entity.Property(p => p.Name).HasColumnName("name");
            entity.HasMany(p => p.Objects).WithOne().HasForeignKey(o => o.ParentKey);
        }
        private void ConfigureObjects(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProjectObject>()
                                     .ToTable("ProjectsAndObjects");
            entity.HasDiscriminator<string>("Discriminator")
                  .HasValue<ProjectObject>("object");
            entity.Property(o => o.Cipher).HasColumnName("cipher");
            entity.Property(o => o.Executor).HasColumnName("executor");
            entity.Property(o => o.Name).HasColumnName("name");
            entity.Property(o => o.ParentKey).HasColumnName("parentcipher");
            entity.HasMany(o => o.Objects).WithOne().HasForeignKey(o => o.ParentKey);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProjects(modelBuilder);
            ConfigureObjects(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            if(!optionsBuilder.IsConfigured)
            {
                Console.WriteLine("Warning! ProjectDataContext is not configure!");
            }
        }
    }
}
