using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModels
{
    public class AuthorCreateViewModel
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        [Required (ErrorMessage = "The First Name field is required.")]
        public string FirstName 
        {
            get { return firstName; } 
            set {  firstName = value; } 
        }

        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required(ErrorMessage = "The Date of Birth field is required.")]
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

    }
}
