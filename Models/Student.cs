using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}