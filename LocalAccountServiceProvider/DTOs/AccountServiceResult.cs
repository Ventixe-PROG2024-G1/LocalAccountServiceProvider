namespace LocalAccountServiceProvider.DTOs
{
    public class AccountServiceResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
    }

    public class AccountServiceResult<T> : AccountServiceResult
    {
        public T? Result { get; set; }
    }
}