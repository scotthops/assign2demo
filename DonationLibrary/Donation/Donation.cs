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

        // [ForeignKey("AccountNo")]
        // public Account? Account { get; set; }

        [Required]
        public int? TransactionTypeId { get; set; }

        // [ForeignKey("TransactionTypeId")]
        // public TransactionType? TransactionType { get; set; }

        [Required]
        public float? Amount { get; set; }

        [Required]
        public int? PaymentMethodId { get; set; }

        // [ForeignKey("PaymentMethodId")]
        // public PaymentMethod? PaymentMethod { get; set; }

        public string? Notes { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        [Required]
        public DateTime? Modified { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public string? ModifiedBy { get; set; }

    }
}
