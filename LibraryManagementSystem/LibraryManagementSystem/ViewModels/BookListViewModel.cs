namespace LibraryManagementSystem.ViewModels
{
    public class BookListViewModel
    {
        private int id;
        private string title;
        private int authorId;
        private string genre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

    }
}
