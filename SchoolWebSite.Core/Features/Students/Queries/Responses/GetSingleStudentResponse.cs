﻿namespace SchoolWebSite.Core.Features.Students.Queries.Responses
{
    public class GetSingleStudentResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
