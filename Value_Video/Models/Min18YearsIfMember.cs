using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Value_Video.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0 ||customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if(!customer.BirthDate.HasValue)
                return new ValidationResult("The Birthday field is required!");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return age >= 18 ? 
                ValidationResult.Success 
                : new ValidationResult("Sorry, you must be 18y/old in order to have a membership subsciption");

        }
    }
}