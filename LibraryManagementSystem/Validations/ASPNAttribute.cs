using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LibraryManagementSystem.Validations
{
    public class ASPNAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string text=value.ToString();
            if(value != null) 
            {
                if (isValidISBNCode(text)!=true)
                {
                    return new ValidationResult("ISBN Number is not formate");
                    
                }
                
            }
            return ValidationResult.Success;
        }
        protected static bool isValidISBNCode(string str)
        {
            string strRegex
                = @"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(str))
                return (true);
            else
                return (false);
        }
    }
}
