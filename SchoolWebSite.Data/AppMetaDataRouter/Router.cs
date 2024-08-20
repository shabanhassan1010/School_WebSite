namespace SchoolWebSite.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api"; // sabat 3la all levels
        public const string version = "V1/"; // 
        public const string rule = root + "/" + version; // Api/V1
        public const string singleRoute = "/{id}";
        public static class StudentRouting
        {
            public const string prefix = rule + "Student";       //  Api/V1/Student
            public const string List = prefix + "/GetStudentList";         //  Api/V1/Student/List
            public const string GetById = prefix + singleRoute;  //  Api/V1/Student/{id}
            public const string AddStudent = prefix + "/AddStudent"; //  Api/V1/Student/AddStudent
            public const string EditStudent = prefix + "/EditStudent";
            public const string Delete = prefix + singleRoute;
        }

    }
}
