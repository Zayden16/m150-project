using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FiscusApi.Models
{
    public class ShoppingList
    {
        public int ShoppingListId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime ShoppingDate { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }
    }
}
