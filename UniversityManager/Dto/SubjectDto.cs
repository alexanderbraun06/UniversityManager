namespace UniversityManager.Dto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int TeacherCount { get; set; }
    }
}
