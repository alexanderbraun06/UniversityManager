using Microsoft.EntityFrameworkCore;

namespace UniversityManager.Data
{
    [PrimaryKey(nameof(CourseId), nameof(StudentId))]
    public class Enrollment
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public required DateTime EnrollmentDate { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }

    }
}
