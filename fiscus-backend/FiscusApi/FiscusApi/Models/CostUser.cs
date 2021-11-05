using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class CostUser
    {
        public int CostUserId { get; set; }

        public bool IsPayee { get; set; }

        public int UserId { get; set; }

        public int CostId { get; set; }
    }
}
