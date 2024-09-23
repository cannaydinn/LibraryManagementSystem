using LibraryManagementSystem.Entities;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        //equivalent in database table
        static List<AuthorEntity> _author = new List<AuthorEntity>
        {
            new AuthorEntity{ Id=1, FirstName = "Victor", LastName="Hugo", DateOfBirth = new DateTime(1802,02,18)},
            new AuthorEntity{ Id=2, FirstName = "Fyodor", LastName="Dostoevsky", DateOfBirth = new DateTime(1821,11,11)},
        };

        public IActionResult List()
        {
            var viewModel = _author.Where(x => x.IsDeleted == false).Select(x => new AuthorListViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
            }).ToList();
            return View(viewModel);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel formdata)
        {
            if (!ModelState.IsValid) 
            {
                return View(formdata);
            }

            int maxId = _author.Max(x => x.Id);
            var newAuthor = new AuthorEntity()
            {
                Id = maxId + 1,
                FirstName = formdata.FirstName,
                LastName = formdata.LastName,
                DateOfBirth = formdata.DateOfBirth,
            };

            _author.Add(newAuthor);
            return RedirectToAction("List");
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            var author = _author.FirstOrDefault(x => x.Id == id);

            var viewModel = new AuthorDetailsViewModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _author.Find(x => x.Id == id);

            var viewModel = new AuthorEditViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel formdata)
        {
            if (!ModelState.IsValid) 
            {
                return View(formdata);
            }

            var author = _author.Find(x => x.Id == formdata.Id);
            author.FirstName = formdata.FirstName;
            author.LastName = formdata.LastName;
            author.DateOfBirth = formdata.DateOfBirth;

            return RedirectToAction("List");
        }



        public IActionResult Delete(int id)
        {

            var author = _author.Find(x => x.Id == id);

            // _author.Remove(author) // HARD DELETE -> The data is gone, never to be accessed again.

            author.IsDeleted = true; // SOFT DELETE -> The data is still there, but when listing, only those with isdeleted false will be listed.
            return RedirectToAction("List");
        }
    }
}
