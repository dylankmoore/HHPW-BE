using System.Numerics;
using Microsoft.EntityFrameworkCore;

namespace HHPW.Models
{
    public class Order
    {
        public int OrderId {  get; set; }
        public bool IsOpen { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
        public bool IsPhone { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public decimal RevTotal { get; set; }
        public int Tip {  get; set; }
        public string? PaymentType { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
