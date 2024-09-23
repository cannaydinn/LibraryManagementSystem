using LibraryManagementSystem.Entities;
using LibraryManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        // equivalent in database table
        static List<UserEntity> _user = new List<UserEntity>()
        {
            new UserEntity{Id = 1, FullName=".", Email=".", Password=".", PhoneNumber="."}
        };


        // security process
        private readonly IDataProtector _dataProtector;
        public AuthController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("Security");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ShowNavbar = false;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowNavbar = false;
                return View(formData);
            }
            var user = _user.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());
            if(user is null)
            {
                ViewBag.ShowNavBar = false;
                ViewBag.Error = "Email or Password is incorrect";
                return View(formData);
            }

            var rawPassword = _dataProtector.Unprotect(user.Password);

            if(rawPassword == formData.Password)
            {
                // login proccess
                var claims = new List<Claim>
                {
                    new Claim("fullName", user.FullName),
                    new Claim("email", user.Email),
                    new Claim("phoneNumber", user.PhoneNumber),
                    new Claim("id", user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // The identity object above was defined because a session will be opened with the data in the claims.

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true, 
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48)), // Valid for 48 hours after login
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            }
            else
            {
                
                ViewBag.Error = "Email or Password is incorrect";
                return View(formData);
            }
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.ShowNavbar = false;
            
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel formData)
        {
            if (!ModelState.IsValid) 
            {
                ViewBag.ShowNavBar = false;
                return View(formData);
            }

            var user = _user.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());
            if(user is not null)
            {
                ViewBag.Error("User Available");
                return View(formData);
            }

            var newUser = new UserEntity()
            {
                Id = _user.Max(x => x.Id) + 1,
                FullName = formData.FullName,
                Email = formData.Email.ToLower(),
                Password = _dataProtector.Protect(formData.Password),
                PhoneNumber = formData.PhoneNumber,
            };

           _user.Add(newUser);

            TempData["SignUpSuccess"] = "Registration successful! Please login.";


            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }

    }
}
