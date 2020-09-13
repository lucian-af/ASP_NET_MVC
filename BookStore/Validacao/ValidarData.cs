using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Validacao
{
    public class ValidarData : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dataValida = DateTime.Now;            

            if (!DateTime.TryParse(value.ToString(), out dataValida))
                return new ValidationResult("Data inválida");

            return ValidationResult.Success;
        }
    }
}