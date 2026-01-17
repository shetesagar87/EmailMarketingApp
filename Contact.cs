using System;
using System.ComponentModel.DataAnnotations;

namespace EmailMarketingApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}