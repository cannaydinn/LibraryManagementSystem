namespace LibraryManagementSystem.ViewModels
{
    public class UserViewModel
    {
        private string fullName;
        private string email;
        private string phoneNumber;
        private DateTime joinDate;

        public UserViewModel()
        {
            joinDate = DateTime.Now;
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public DateTime JoinDate
        {
            get { return joinDate; }
            set { joinDate = value; }
        }
    }
}
