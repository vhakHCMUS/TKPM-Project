using Microsoft.AspNetCore.Mvc;
using TKPM_Project.Models;
using TKPM_Project.Repositories;

namespace TKPM_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var account = _accountRepository.GetAll()
                .FirstOrDefault(a => a.Username == username && a.PasswordHash == password);

            if (account == null)
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }

            return View("AccountProfile", account); // Chuyển đến trang AccountProfile
        }

    }
}
