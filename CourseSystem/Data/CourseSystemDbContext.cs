using CourseSystem.Configuration;
using CourseSystem.Entities.AppDbContextEntity;
using CourseSystem.Enum;
using Microsoft.EntityFrameworkCore;

namespace CourseSystem.Data
{
    public class CourseSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; } 

        public CourseSystemDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);


                entity.Property(x => x.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(s => s.Group)
                    .WithMany(g => g.Students)
                    .HasForeignKey(s => s.GroupId);

                entity.HasQueryFilter(s=>s.IsDeleted == false);

            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasQueryFilter(g=>g.IsDeleted == false);

            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);


                entity.HasMany(l => l.Groups)
                    .WithOne(g => g.Lesson)
                    .HasForeignKey(g => g.LessonId);

                entity.HasQueryFilter(l=>l.IsDeleted == false);

            });


            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne<User>(ur => ur.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RoleId);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(x => x.Name).IsRequired()
                            .HasMaxLength(100);

                entity.Property(x => x.Password).IsRequired()
                .HasMaxLength(100);

                entity.Property(x => x.Email).IsRequired()
                .HasMaxLength(100);

                entity.HasQueryFilter(u => u.IsDeleted == false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasQueryFilter(r=> r.IsDeleted == false);
                entity.Property(x=>x.Name).IsRequired()
                    .HasMaxLength(100); 
            });

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .HasConversion<int>();

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(ur => ur.RoleId);


            modelBuilder.ApplyConfiguration(new FileConfiguration());


        }


    }
}
