using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerDevTask.Models.Customer
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string DisplayName => string.Concat(FirstName, " ", Surname);

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string TelephoneNumber { get; set; }

        public int Age => CalculateAge(DateOfBirth);

        private int CalculateAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age -= 1;
            }

            return age;
        }
    }
}
