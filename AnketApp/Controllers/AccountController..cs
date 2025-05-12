using Microsoft.AspNetCore.Mvc;
using AnketApp.Models;
using AnketApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AnketApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly JsonStore _store;
        public AccountController(JsonStore store)
        {
            _store = store;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var users = _store.LoadUsers();
            if (users.Any(u => u.Username == username))
            {
                ViewBag.Error = "Kullanıcı adı zaten kayıtlı.";
                return View();
            }
            users.Add(new User { Username = username, Password = password });
            _store.SaveUsers(users);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var users = _store.LoadUsers();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
                return View();
            }
            HttpContext.Session.SetString("User", username);
            return RedirectToAction("Index", "Survey");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }
    }
}
