using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;

namespace Service.Context
{
    public class ProjectDataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectObject> Objects { get; set; }
        public ProjectDataContext(DbContextOptions<ProjectDataContext> options) : base(options) { }

        private void ConfigureProjects(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Project>().ToTable("Projects");
            entity.HasKey(p => p.Sipher);
            entity.Property(p => p.Sipher).HasColumnName("sipher");
            entity.Property(p => p.Executor).HasColumnName("executor");
            entity.Property(p => p.Name).HasColumnName("name");
            entity.HasMany(p => p.Objects).WithOne(o => o.Project).HasForeignKey(o => o.ProjectSipher);
        }
        private void ConfigureObjects(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProjectObject>().ToTable("Objects");
            entity.HasKey(o => o.Code);
            entity.Property(o => o.Code).HasColumnName("code");
            entity.Property(o => o.Executor).HasColumnName("executor");
            entity.Property(o => o.Name).HasColumnName("name");
            entity.Property(o => o.ParentCode).HasColumnName("parent_code");
            //entity.HasOne(o => o.Project).WithMany(p => p.Objects).HasForeignKey(o => o.ProjectSipher);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProjects(modelBuilder);
            ConfigureObjects(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.LogTo(Console.WriteLine);
    }
}
