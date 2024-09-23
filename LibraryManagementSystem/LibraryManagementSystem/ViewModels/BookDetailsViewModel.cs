namespace LibraryManagementSystem.ViewModels
{
    public class BookDetailsViewModel
    {
        private int id;
        private string title;
        private int authorId;
        private string genre;
        private DateTime publishDate;
        private string isbn;
        private int copiesAvailable;

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

        public DateTime PublishDate
        {
            get { return publishDate; }
            set { publishDate = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public int CopiesAvailable
        {
            get { return copiesAvailable; }
            set { copiesAvailable = value; }
        }
    }
}
