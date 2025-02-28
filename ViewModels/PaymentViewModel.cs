namespace FoodDeliveryApp.ViewModels
{
    public class PaymentViewModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; } // Total amount to pay
        public decimal AmountPaid { get; set; } // Actual amount paid

        public string PaymentOption { get; set; }
        public string PaymentStatus { get; set; }
    }
}
