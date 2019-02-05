using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLoginPortal.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if(customer.DateofBirth == null)
            {
                return new ValidationResult("Date of Birth is Required!");
            }
            var age = DateTime.Today.Year - customer.DateofBirth.Value.Year;
            if(age < 18)
            {
                return new ValidationResult("Come back after 18!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}