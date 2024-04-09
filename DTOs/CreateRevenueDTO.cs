namespace HHPW_BE.DTOs
{
    public class CreateRevenueDTO
    {
        public decimal TotalAmount { get; set; }
        public DateTime ClosureDate { get; set; }
        public string PaymentType { get; set; }
        public int TipAmount { get; set; }
        public bool isPhone { get; set; }
    }
}
