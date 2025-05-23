namespace LocalAccountServiceProvider.Data.Models
{
    public class AccountResponseRest
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Error { get; set; }
    }
}