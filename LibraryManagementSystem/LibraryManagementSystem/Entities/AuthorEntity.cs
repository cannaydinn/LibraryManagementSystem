namespace LibraryManagementSystem.Entities
{
    public class AuthorEntity
    {
        // fields of the class
        private int id;
        private string firstName;
        private string lastName;
        private DateTime dateofBirth;
        private bool isDeleted;

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
            get { return dateofBirth; }
            set { dateofBirth = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

    }
}
