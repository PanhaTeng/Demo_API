namespace Demo_API.Data
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int? StatusCode { get; set; } 
        public string Message { get; set; }=string.Empty;

    }
}
