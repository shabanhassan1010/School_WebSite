using System.Net;


namespace SchoolWebSite.Core.Bases
{
    public class ResponseHandler
    {
        #region Constructor
        public ResponseHandler()
        {

        }
        #endregion

        #region Handle Functions
        // The method returns a new instance of Response<T>
        // Generic Method
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK, // indicating that the deletion operation was successful and the server is responding with a 200 OK status.
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }

        // T entity: The entity that has been successfully added or processed.
        // object Meta = null: An optional parameter for any additional metadata.This allows you to pass extra information related to the operation.

        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>() // returns a new instance of Response<T>, which seems to be a class
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Added Successfully",
                Meta = Meta
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }

        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> UnprocessableEntity<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? "Unprocessable Entity" : Message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }
        #endregion    
    }
}
