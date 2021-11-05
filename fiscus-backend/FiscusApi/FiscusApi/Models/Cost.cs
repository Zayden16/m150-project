using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiscusApi.Models
{
    public class Cost
    {
        public int CostId { get; set; }

        public float Price { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
