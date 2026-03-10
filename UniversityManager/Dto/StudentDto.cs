namespace UniversityManager.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Surname  { get; set; }
        public required DateOnly BirthDate { get; set; }
        public List<CourseEnrollmentDto>? Enrollments { get; set; }
    }
}
