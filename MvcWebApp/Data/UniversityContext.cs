using System;
using Microsoft.EntityFrameworkCore;
using MvcWebApp.Models;
using System.Linq;

namespace MvcWebApp.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

    public static class UniversityContextExtensions
    {
        public static void EnsureSeedData(this UniversityContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { FirstName = "Alex", LastName = "Hunter", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { FirstName = "Brad", LastName = "Foster", EnrollmentDate = DateTime.Parse("2003-09-01") },
                    new Student { FirstName = "Melissa", LastName = "Punninghton", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { FirstName = "Mike", LastName = "Heskey", EnrollmentDate = DateTime.Parse("2004-09-01") },
                    new Student { FirstName = "William", LastName = "Gordon", EnrollmentDate = DateTime.Parse("2002-09-01") },
                    new Student { FirstName = "Caroline", LastName = "Woznyacky", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { FirstName = "Craig", LastName = "Foot", EnrollmentDate = DateTime.Parse("2004-09-01") },
                    new Student { FirstName = "Harry", LastName = "Kane", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { FirstName = "Rasheed", LastName = "Brahaam", EnrollmentDate = DateTime.Parse("2005-09-01") },
                    new Student { FirstName = "Clementine", LastName = "Cole", EnrollmentDate = DateTime.Parse("2002-09-01") },
                    new Student { FirstName = "Sid", LastName = "Hopkins", EnrollmentDate = DateTime.Parse("2003-09-01") }
                );

                context.SaveChanges();
            }
        }
    }
}
