namespace LocalAccountServiceProvider.Data.DTOs
{
    public class CreateAccountRequestRest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}