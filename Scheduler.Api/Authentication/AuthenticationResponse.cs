namespace Scheduler.Api.Authentication
{
    public class AuthenticationResponse
    {
        public string? Token { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
