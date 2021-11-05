using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
