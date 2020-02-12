namespace Poc.Ocelot.Accounts.Constants
{
    public class AppSettings
    {
        public Tokens Tokens { get; set; }
    }

    public class Tokens
    {
        public string Key { get; set; }

        public int Lifetime { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
