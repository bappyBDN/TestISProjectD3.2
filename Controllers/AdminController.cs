using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HomeChefHub.Models;
using HomeChefHub.Data;

namespace HomeChefHub.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDatabaseContext _context;

        public AdminController(MyDatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var existingAdmin = _context.Admins.FirstOrDefault(a => a.Email == admin.Email && a.Password == admin.Password);
            if (existingAdmin != null)
            {
                HttpContext.Session.SetString("AdminEmail", admin.Email);
                return RedirectToAction("Dashboard");
            }
            ViewBag.ErrorMessage = "Invalid login credentials!";
            return View();
        }

        // GET: Admin/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("AdminEmail") == null)
                return RedirectToAction("Login");

            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: Admin/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: Admin/Signup
        [HttpPost]
        public IActionResult Signup(Admin admin)
        {
            // Check if the email already exists in the database
            var existingAdmin = _context.Admins.FirstOrDefault(a => a.Email == admin.Email);
            if (existingAdmin != null)
            {
                // Show error message if email exists
                ViewBag.ErrorMessage = "Email already exists!";
                return View();
            }

            // If the model is valid, add the new admin to the database
            if (ModelState.IsValid)
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Login"); // Redirect to Login page after successful signup
            }

            // If the model is invalid, return the view with validation errors
            return View(admin);
        }
    }
}
