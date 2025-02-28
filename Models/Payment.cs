using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Expected price

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; } // Actual paid amount

        public string PaymentOption { get; set; }
        public string PaymentStatus { get; set; } // e.g., "Completed", "Pending", "Failed"
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
