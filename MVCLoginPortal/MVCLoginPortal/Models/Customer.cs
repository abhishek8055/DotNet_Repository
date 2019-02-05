using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCLoginPortal.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Min18Years]
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "please select a membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}