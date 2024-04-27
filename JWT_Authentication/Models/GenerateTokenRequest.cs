namespace JWT_Authentication.Models
{
    public class GenerateTokenRequest
    {
        public string Username { get; set; }
    }
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate{ get; set; }

    }
}
