using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcWebApp.Models;

namespace MvcWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

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
