using System.Net;

namespace Ecommerce.Common.Dtos
{
    public class ResponseService<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseService()
        {
            Status = false;
            Message = string.Empty;
        }
    }
}