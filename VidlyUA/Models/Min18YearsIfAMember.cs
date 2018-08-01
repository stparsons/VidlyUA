using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyUA.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.UnKnown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if(customer.BirthDateTime == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Today.Year - customer.BirthDateTime.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to be a member");

        }
    }
}