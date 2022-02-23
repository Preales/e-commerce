namespace Ecommerce.Common.Helpers
{
    public sealed class ApiResponse<T> where T : class
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(string response, string message, T data)
        {
            Response = response;
            Message = message;
            Data = data;
        }

        public override string ToString()
            => $"Response : {Response}, Message : {Message}, Data : {Data}";
    }
}