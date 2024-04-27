namespace JWT_Authentication.Models
{
    public class UserLoginResponse
    {
        public bool IsAuthenticated { get; set; }
        public string AuthToken { get; set; }
        public DateTime TokenExpireDate { get; set; }


    }
}
