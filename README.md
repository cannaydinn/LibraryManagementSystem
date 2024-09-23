# Library Management System - ASP.NET Core MVC

This project is a **Library Management System** built using **ASP.NET Core MVC**. The system manages books, authors, and users for a library. It allows CRUD operations on books and authors, and provides user registration and login functionality. The project follows MVC architecture, Object-Oriented Programming (OOP) principles, and basic data management techniques.

## Project Structure

### Models

- **Book**: Represents a book in the library.
  - `Id`: Unique identifier for the book (int).
  - `Title`: The title of the book (string).
  - `AuthorId`: Reference to the author's ID (int).
  - `Genre`: The genre of the book (string).
  - `PublishDate`: The publication date of the book (DateTime).
  - `Isbn`: The ISBN number of the book (string).
  - `CopiesAvailable`: The number of copies available in the library (int).

- **Author**: Represents an author.
  - `Id`: Unique identifier for the author (int).
  - `FirstName`: Author's first name (string).
  - `LastName`: Author's last name (string).
  - `DateOfBirth`: Author's date of birth (DateTime).

- **User**: Represents a user of the system.
  - `Id`: Unique identifier for the user (int).
  - `FullName`: User's full name (string).
  - `Email`: User's email address (string).
  - `Password`: User's login password (string).
  - `PhoneNumber`: User's phone number (string).
  - `JoinDate`: Date the user joined (DateTime).

### ViewModels

- **BookListViewModel**: Used to display a list of books.
- **BookCreateViewModel**: Used to create a new book.
- **AuthorListViewModel**: Used to display a list of authors.
- **SignUpViewModel**: Used for the registration form.
- **LoginViewModel**: Used for the login form.

### Controllers

- **BookController**: Manages book-related actions.
  - `List()`: Displays a list of all books.
  - `Details(int id)`: Displays details of a specific book.
  - `Create()`: Displays the form to create a new book.
  - `Create(BookCreateViewModel)`: Handles the submission of the new book.
  - `Edit(int id)`: Displays the form to edit an existing book.
  - `Delete(int id)`: Deletes a book.

- **AuthorController**: Manages author-related actions.
  - `List()`: Displays a list of all authors.
  - `Details(int id)`: Displays details of a specific author.
  - `Create()`: Displays the form to create a new author.
  - `Create(AuthorCreateViewModel)`: Handles the submission of the new author.
  - `Edit(int id)`: Displays the form to edit an existing author.
  - `Delete(int id)`: Deletes an author.

- **AuthController**: Manages user authentication.
  - `SignUp()`: Displays the registration form.
  - `SignUp(SignUpViewModel)`: Handles user registration.
  - `Login()`: Displays the login form.
  - `Login(LoginViewModel)`: Handles user login.

### Views

Each model has corresponding views for its actions:

- **Book Views**:
  - `List`: Displays a list of all books.
  - `Details`: Shows the details of a book.
  - `Create`: Form to add a new book.
  - `Edit`: Form to edit a book.

- **Author Views**:
  - `List`: Displays a list of all authors.
  - `Details`: Shows the details of an author.
  - `Create`: Form to add a new author.
  - `Edit`: Form to edit an author.

- **User Views**:
  - `Sign Up`: User registration form with password confirmation.
  - `Login`: User login form.

Testing the Project

To test the functionality of the system, follow these steps:

	1.	Adding a Book:
	•	Use the BookController’s Create action to add a new book. Once added, the book should appear in the book list.
	2.	Editing and Deleting a Book:
	•	You can edit an existing book via the Edit page or delete it using the Delete action.
	3.	Adding an Author:
	•	Use the AuthorController’s Create action to add a new author. Authors can be associated with books.
	4.	User Registration and Login:
	•	Test user registration and login functionality via the AuthController. The registration form includes password confirmation validation, and users can log in once registered.

 Technologies Used

	•	ASP.NET Core MVC: The framework for building the application.
	•	C#: The programming language used.
	•	Entity Framework Core (Optional): Can be used for data access.
	•	HTML/CSS: For front-end UI.
	•	Bootstrap: For responsive design.
