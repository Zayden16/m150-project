using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [MaxLength(50)]
        public string Password { get; set; }

        public int GroupId { get; set; }
    }
}
