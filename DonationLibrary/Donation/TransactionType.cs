using System;
using System.ComponentModel.DataAnnotations;

namespace DonationLibrary
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        [Required]
        public string? ModifiedBy { get; set; }

    }
}
