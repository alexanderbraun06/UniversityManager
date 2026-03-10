namespace UniversityManager.Data
{
    public class Course
    {
        public int CourseId { get; set; }
        public required string Title { get; set; }
        public List<Enrollment> Enrollments {  get; set; } = new List<Enrollment>();
        public List<Module> Modules { get; set; } = [];
    }
}
