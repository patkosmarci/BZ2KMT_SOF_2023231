using Microsoft.EntityFrameworkCore;
using BZ2KMT_SOF_2023231.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BZ2KMT_SOF_2023231.Data
{
    public class SchollingDbContext : IdentityDbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SiteUser> Users { get; set; }

        public SchollingDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = "Server=(localdb)\\mssqllocaldb;Database=SchoolingDB;Trusted_Connection=True;MultipleActiveResultSets=true";
                builder.UseSqlServer(conn).UseLazyLoadingProxies();
                //builder.UseInMemoryDatabase("s").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
                new { Id = "3", Name = "Teacher", NormalizedName = "TEACHER" }
                );

            modelBuilder.Entity<School>().HasData(new School[]
            {
                new School(1, "Sashegyi Arany János Gimnázium", stype.High),
                new School(2, "Katona József Szakközépiskola és Szakiskola", stype.High),
                new School(3, "Illyés Gyula Gimnázium", stype.Primary)
            });

            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher(1, "Kovács Anna", 270_000, subj.ESTeacher,3),
                new Teacher(2, "Nagy Péter", 245_330, subj.ESTeacher,3),
                new Teacher(3, "Szabó Zsófia", 400_000, subj.Physics, 1),
                new Teacher(4, "Tóth Bence", 431_000, subj.German, 1),
                new Teacher(5, "Horváth Lilla", 220_000, subj.History, 2),
                new Teacher(6, "Varga Gábor József", 298_000, subj.PE, 2)
            });

            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(1, "Farkas Ádám", 16, 1, 5),
                new Student(2, "Kiss Eszter", 17, 1, 3.24),
                new Student(3, "Balogh Dóra", 17, 2, 4.76),
                new Student(4, "Molnár Levente", 13, 3, 4.453)
            });

            modelBuilder.Entity<Student>(student => student
                .HasOne(student => student.School)   //egy diákhoz van 1 suli
                .WithMany(Schools => Schools.Students)         //egy suli több diákhoz is tartozhat
                .HasForeignKey(student => student.SchoolId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Teacher>(teacher => teacher
                .HasOne(teacher => teacher.School)
                .WithMany(Schools => Schools.Teachers)
                .HasForeignKey(teaher => teaher.SchoolId)
                .OnDelete(DeleteBehavior.Cascade));

            

            base.OnModelCreating(modelBuilder);
        }
    }
}