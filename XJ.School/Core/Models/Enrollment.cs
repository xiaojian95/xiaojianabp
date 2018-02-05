using System.ComponentModel.DataAnnotations;
using XJ.School.Application.enumType;

namespace ContosoUniversity.Models
{

    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public CourseGrade Grade { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}