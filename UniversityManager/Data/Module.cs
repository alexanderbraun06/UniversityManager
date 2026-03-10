namespace UniversityManager.Data
{
    public class Module
    {
        public int ModuleId { get; set; }
        public required string Title { get; set; }
        
        public int CourseId { get; set; }
        public int SubjectId {  get; set; }
        public Course? Course { get; set; }
        public Subject? Subject { get; set; }
        public List<Teacher> Teachers { get; set; } = [];
    }
}
