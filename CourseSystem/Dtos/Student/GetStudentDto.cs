using CourseSystem.Dtos.Group;

namespace CourseSystem.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Surname { get; set; }
        public int? GroupId { get; set; }
        public GetGroupDto? Group { get; set; }

    }
}
