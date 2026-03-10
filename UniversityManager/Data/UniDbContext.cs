using Microsoft.EntityFrameworkCore;

namespace UniversityManager.Data
{
    public class UniDbContext : DbContext
    {
        public UniDbContext() : base() { }
        public UniDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
                .HasMany((Teacher t) => t.Subjects)
                .WithMany((Subject s) => s.Teachers)
                .UsingEntity(e => e.ToTable("Competences"));

            modelBuilder.Entity<Module>()
                .HasMany((Module m) => m.Teachers)
                .WithMany((Teacher t) => t.Modules)
                .UsingEntity(e => e.ToTable("Assignments"));
        }
        }
   }