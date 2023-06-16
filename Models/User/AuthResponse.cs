namespace UserLogging.Models.User
{
    public class AuthResponse
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public string? JwtToken { get; set; }
        
    }
}
