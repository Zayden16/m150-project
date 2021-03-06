using System;
using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class Cost
    {
        public int CostId { get; set; }

        public float Price { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        public int GroupId { get; set; }
    }
}
