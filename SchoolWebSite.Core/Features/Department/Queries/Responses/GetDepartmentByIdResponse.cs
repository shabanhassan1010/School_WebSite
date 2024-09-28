namespace SchoolWebSite.Core.Features.Department.Queries.Responses
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public List<StudentResponse>? ListOfStudentResponse { get; set; }
        public List<SubjectResponse>? ListOfSubjectResponse { get; set; }
        public List<InstructorResponse>? ListOfSInstructorResponse { get; set; }
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
