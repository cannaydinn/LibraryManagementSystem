using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class BookController : Controller
{
    // equivalent in database table
    static List<BookEntity> _book = new List<BookEntity>
    {
        new BookEntity{ Id = 1, Title = "Les Miserables", AuthorId = 1, Genre="Novel, Tragedy", PublishDate = new DateTime(1862,01,01), Isbn = "9788423334193", CopiesAvailable=1000},
        new BookEntity{ Id = 2, Title = "Notes From the Underground", AuthorId = 2, Genre="Novel", PublishDate = new DateTime(1864,01,01), Isbn = "9788420637464", CopiesAvailable=2000}
    };

    static List<OwnerEntity> _owner = new List<OwnerEntity>()
    {
        new OwnerEntity{ Id = 1, FullName= "Victor Hugo"},
        new OwnerEntity{ Id = 2, FullName= "Fyodor"},
    };

    public IActionResult List()
    {
        var viewModel = _book.Where(x => x.IsDeleted == false).Select(x => new BookListViewModel
        {
            Id = x.Id,
            Title = x.Title,
            AuthorId = x.AuthorId,
            Genre = x.Genre,
        }).ToList();

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Owners = _owner;

        return View();
    }

  

    [HttpPost]
    public IActionResult Create(BookCreateViewModel formData)
    {
        if (!ModelState.IsValid)
        {
           
           return View(formData);
        }

        int maxId = _book.Max(x => x.Id);
        var newBook = new BookEntity()
        {
            Id = maxId+ 1,
            Title = formData.Title,
            AuthorId = formData.AuthorId,
            Genre = formData.Genre,
            PublishDate = formData.PublishDate,
            Isbn = formData.Isbn,
            CopiesAvailable = formData.CopiesAvailable
        };

        _book.Add(newBook);

        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var book = _book.Find(x => x.Id == id);

        var viewModel = new BookEditViewModel()
        { 
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            Isbn = book.Isbn,
            CopiesAvailable= book.CopiesAvailable,
        };
        ViewBag.Owners = _owner;
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(BookEditViewModel formdata)
    {
        if (!ModelState.IsValid)
        {
            return View(formdata);
        }

        var book = _book.Find(x => x.Id == formdata.Id);
        book.Title = formdata.Title;
        book.AuthorId = formdata.AuthorId;
        book.PublishDate = formdata.PublishDate;
        book.Isbn = formdata.Isbn;
        book.CopiesAvailable = formdata.CopiesAvailable;

        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var book = _book.FirstOrDefault(x => x.Id == id);

        var viewModel = new BookDetailsViewModel
        {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Genre = book.Genre,
            PublishDate = book.PublishDate,
            Isbn = book.Isbn,
            CopiesAvailable = book.CopiesAvailable
        };

        return View(viewModel);
    }

    public IActionResult Delete(int id)
    {

        var book = _book.Find(x => x.Id == id);

        // _author.Remove(author) // HARD DELETE -> The data is gone, never to be accessed again.

        book.IsDeleted = true; // SOFT DELETE -> The data is still there, but when listing, only those with isdeleted false will be listed.
        return RedirectToAction("List");
    }
}