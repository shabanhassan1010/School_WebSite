using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSite.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1/";
        public const string rule = root + "/" + version;
        public const string singleRoute = "/{id}";
        public static class StudentRouting
        {
            public const string prefix = rule + "Student";
            public const string List = prefix + "/List";
            public const string GetById = prefix + singleRoute;
        }

    }
}
