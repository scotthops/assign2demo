using System;
using System.ComponentModel.DataAnnotations;

namespace DonationLibrary
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public string? ModifiedBy { get; set; }

        // Other properties or methods...
    }
}
