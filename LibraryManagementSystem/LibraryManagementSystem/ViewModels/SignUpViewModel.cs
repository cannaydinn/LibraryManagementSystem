using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.ViewModels
{
    public class SignUpViewModel
    {
        private string fullName;
        private string email;
        private string password;
        private string confirmPassword;
        private string phoneNumber;

        [Required(ErrorMessage = "The Full Name field is required.")]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [Required(ErrorMessage = "The Email field is required.")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "The Password field is required.")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Compare(nameof(Password))]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        [Required(ErrorMessage = "The Phone Number field is required.")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

    }
}
