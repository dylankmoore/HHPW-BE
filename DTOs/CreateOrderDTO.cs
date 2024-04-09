namespace HHPW_BE.DTOs
{
    public class CreateOrderDTO
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
        public bool IsPhone { get; set; }
        public int Tip { get; set; }
        public string PaymentType { get; set; }
        public List<int> ItemIds { get; set; } = new List<int>();
    }
}
