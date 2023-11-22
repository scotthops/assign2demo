using System;
using System.ComponentModel.DataAnnotations;

namespace DonationLibrary
{
    public class Account
    {
        [Key]
        public int AccountNo { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? PostalCode { get; set; }

        [Required]
        public string? Country { get; set; }

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
