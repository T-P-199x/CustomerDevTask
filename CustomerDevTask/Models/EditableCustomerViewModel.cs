using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerDevTask.Web.Models
{
    public class EditableCustomerViewModel
    {
        public int Id { get; set; }

        [Display(Name="First Name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Surname"), Required]
        public string Surname { get; set; }

        [Display(Name = "Date of Birth"), Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Telephone Number"), Required]
        public string TelephoneNumber { get; set; }

        public bool? IsSaved { get; set; }

        public bool Success { get; set; }
    }
}
