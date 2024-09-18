namespace SchoolWebSite.Core.Features.Students.Queries.Responses
{
    public class GetStudentListPaginatedResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public GetStudentListPaginatedResponse(int studId, string name, string address, string departmentName, string phone)
        {
            StudID = studId;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
            Phone = phone;
        }
    }
}
