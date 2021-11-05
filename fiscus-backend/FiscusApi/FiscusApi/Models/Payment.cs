using System;
using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int UserId { get; set; }

        public bool IsPayee { get; set; }

        public int CostId { get; set; }
    }
}
