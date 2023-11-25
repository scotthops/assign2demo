using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonationLibrary
{
    public class Donation 
    {
        [Key]
        public int? TransId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public int? AccountNo { get; set; }

        [Required]
        public int? TransactionTypeId { get; set; }

        [Required]
        public float? Amount { get; set; }

        [Required]
        public int? PaymentMethodId { get; set; }

        public string? Notes { get; set; }

        
        public DateTime? Created { get; set; }

   
        public DateTime? Modified { get; set; }

      
        public string? CreatedBy { get; set; }

     
        public string? ModifiedBy { get; set; }

        // // Navigation properties
        // [ForeignKey("TransactionTypeId")]
        // public TransactionType? TransactionType { get; set; }

        // [ForeignKey("PaymentMethodId")]
        // public PaymentMethod? PaymentMethod { get; set; }

    }
}
