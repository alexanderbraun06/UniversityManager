using UniversityManager.Data;
namespace UniversityManager.Dto
{
    public class Mapper
    {
        public StudentDto MapBaseEntityToDto(Student entity)
        {
            StudentDto dto = new StudentDto()
            {
                Id = entity.StudentId,
                BirthDate = entity.BirthDate,
                Name = entity.Name,
                Surname = entity.Surname,
            };
            return dto;
        }
        public StudentDto MapEntityToDto(Student entity)
        {
            StudentDto dto = MapBaseEntityToDto(entity);
            dto.Enrollments = entity.Enrollments.ConvertAll(MapEntityToDto);
            return dto;
        }

        public CourseEnrollmentDto MapEntityToDto(Enrollment entity)
        {

            CourseEnrollmentDto dto = new CourseEnrollmentDto()
            {
                CourseId = entity.CourseId,
                EnrollmentDate = entity.EnrollmentDate,
                Title = entity.Course?.Title ?? "Not Found"
            };
            return dto;
        }
        public Student MapDtoToEntity(StudentDto dto)
        {
            Student entity = new Student()
            {
                BirthDate = dto.BirthDate,
                Name = dto.Name,
                Surname = dto.Surname,
                StudentId = dto.Id
            };
            return entity;
        }

        public SubjectDto MapBaseEntityToDto(Subject entity)
        {
            SubjectDto dto = new SubjectDto()
            {
                Title = entity.Title,
                Id = entity.SubjectId
            };
            return dto;
        }
        public SubjectDto MapEntityToDto(Subject entity)
        {
            SubjectDto dto = MapBaseEntityToDto(entity);
            dto.TeacherCount = entity.Teachers?.Count ?? 0;
            return dto;
        }

        internal Subject MapDtoToEntity(SubjectDto? subject)
        {
            throw new NotImplementedException();
        }
    }
}
