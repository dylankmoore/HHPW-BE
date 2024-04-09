namespace HHPW_BE.DTOs
{
    public class UpdateOrderDTO
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
        public bool IsPhone { get; set; }
        public int? Tip { get; set; }

    }
}

