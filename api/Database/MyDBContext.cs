using Api.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace api.Database
{
    public class MyDBContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>()
                .HasKey(key => new { key.ProjectId, key.UserId });

            modelBuilder.Entity<ProjectUser>()
                .HasOne(x => x.Project).WithMany(y => y.ProjectUsers).HasForeignKey(z => z.ProjectId);

            modelBuilder.Entity<ProjectUser>()
                .HasOne(x => x.User).WithMany(y => y.ProjectUsers).HasForeignKey(z => z.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
