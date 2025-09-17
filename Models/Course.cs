using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p01_StudentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        // Navigation
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}