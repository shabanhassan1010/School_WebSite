using SchoolWebSite.Core.Wrappers;

namespace SchoolWebSite.Core.Features.Department.Queries.Responses
{
    public class GetDepartmentPaginatedByIdRespones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public PaginatedResult<StudentResponsePaginated>? ListOfStudentResponsePaginated { get; set; }
        public List<StudentResponsePaginated>? ListOfSubjectResponsePaginated { get; set; }
        public List<SubjectResponsePaginated>? ListOfSInstructorResponsePaginated { get; set; }
    }
    public class StudentResponsePaginated
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponsePaginated(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
    public class SubjectResponsePaginated
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponsePaginated
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}