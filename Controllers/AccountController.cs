using Microsoft.AspNetCore.Mvc;
using WebApplication121024.Data;
using WebApplication121024.Models;

namespace WebApplication121024.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsUsernameAvailable(string username)
        {
            // Проверяем, существует ли уже имя пользователя в базе данных
            bool isAvailable = !_context.Users.Any(u => u.Username == username);
            return Json(isAvailable ? "true" : $"Username {username} is already taken.");
        }
    }
}
