﻿using HHPW.Models;

namespace HHPW.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}
