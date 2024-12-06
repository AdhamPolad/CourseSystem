using System.Net;

namespace CourseSystem.Dtos.CustomDtos
{
    public class CustomErrorDto
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

    }
}
