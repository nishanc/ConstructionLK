using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public string UserId { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int Status { get; set; }
    }
}