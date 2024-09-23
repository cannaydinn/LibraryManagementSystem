namespace LibraryManagementSystem.Entities
{
    public class UserEntity
    {
        //fields of the class
        private int id;
        private string fullName;
        private string email;
        private string password;
        private string phoneNumber;
        private DateTime joinDate;

        public UserEntity()
        {
            joinDate = DateTime.Now;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public string Password
        {
            get { return password; }
            set { password = value; }
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
