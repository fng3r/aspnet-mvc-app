using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;

namespace MvcWebApp.Models
{
    public class Student
    {
        public Student()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
