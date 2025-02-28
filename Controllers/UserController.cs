using Microsoft.AspNetCore.Mvc;
using HomeChefHub.Models;
using HomeChefHub.Data;

namespace HomeChefHub.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDatabaseContext _context;

        public UserController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (existingUser != null && BCrypt.Net.BCrypt.Verify(password, existingUser.Password))
            {
                HttpContext.Session.SetString("UserEmail", email);
                return RedirectToAction("UserIndex");
            }
            ViewBag.ErrorMessage = "Invalid login credentials!";
            return View();
        }

        // GET: User/UserIndex
        public IActionResult UserIndex()
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login");

            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: User/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: User/Signup
        [HttpPost]
        public IActionResult Signup(User user)
        {
            // Check if the email already exists in the database
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Email already exists!";
                return View();
            }

            // If the model is valid, add the new user to the database
            if (ModelState.IsValid)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); // Secure Password
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }
    }
}
