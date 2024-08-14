using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebSite.Core.Bases
{
    public class Response<T>
    {
        #region Fields
        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; }
        //public Dictionary<string, List<string>> ErrorsBag { get; set; }
        public T Data { get; set; }

        #endregion

        #region Constructor
        public Response()
        {

        }
        public Response(string message)
        {
            //Succeeded = false;
            Message = message;
        }
        public Response(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        #endregion
    }
}
