
namespace FinalPackagroup.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; }
    }
}
