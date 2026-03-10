namespace UniversityManager.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateOnly BirthDate { get; set; }
        public List<Enrollment> Enrollments { get; set; } = [];
    }
}
