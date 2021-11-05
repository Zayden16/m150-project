using System.ComponentModel.DataAnnotations;

namespace FiscusApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool IsPurchased { get; set; }

        public int ShoppingListId { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }
    }
}
