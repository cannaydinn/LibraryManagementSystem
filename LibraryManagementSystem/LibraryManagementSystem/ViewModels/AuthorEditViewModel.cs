namespace LibraryManagementSystem.ViewModels
{
    public class AuthorEditViewModel
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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
