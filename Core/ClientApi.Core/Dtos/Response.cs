namespace ClientApi.Core.Dtos
{
    public class Response<T>
    {
        public int StatusCode { get; set; } = 200;
        public string ErrorMessage { get; set; } = null;
        public T Data { get; set; }
        public bool AnErrorOcurred { get; set; } = false;
    }
}
