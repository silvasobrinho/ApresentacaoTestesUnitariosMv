namespace Domain.Commom
{
    public class Response<T>
    {
        public int NumeroDaSorte { get; set; }
        public T Data { get; set; }
    }
}
