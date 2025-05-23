namespace LocalAccountServiceProvider.Data.Models
{
    public class AllAccountsResponseRest
    {
        public List<AccountResponseRest>? Accounts { get; set; } = new List<AccountResponseRest>();
    }
}