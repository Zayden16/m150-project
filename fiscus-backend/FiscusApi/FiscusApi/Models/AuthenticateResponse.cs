namespace FiscusApi.Models
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}