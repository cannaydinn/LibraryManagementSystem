namespace LibraryManagementSystem.ViewModels
{
    public class AuthorDetailsViewModel
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }


        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }


        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
    }
}
