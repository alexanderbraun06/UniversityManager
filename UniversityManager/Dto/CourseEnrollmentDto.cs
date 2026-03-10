namespace UniversityManager.Dto
{
    public class CourseEnrollmentDto
    {
        public int CourseId { get; set; }
        public required  string Title { get; set; }
        public required DateTime EnrollmentDate { get; set; }
    }
}
