namespace ModelsLibrary.Models.ResponseModel
{
    public class Response<T>
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
    }
}
