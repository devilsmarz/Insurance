namespace BeautyTrackSystem.BLL.Models.Responses
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public Boolean IsSuccess { get; set; }  = true;
        public String Message { get; set; } = String.Empty;

    }
}
