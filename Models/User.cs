using MotivWebApp.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Models
{
    public class User: IUser<Name>
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must provide an email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$", ErrorMessage = "Not a valid phone number")]
        
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "You must provide an annual income")]
        [Display(Name = "Annual Income")]
        public decimal AnnualIncome { get; set; }
        public Loan Loan { get; set; }

    }
}
