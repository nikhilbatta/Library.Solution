using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<LibraryManager> _userManager;
        private readonly SignInManager<LibraryManager> _signInManager;

        public AccountController(UserManager<LibraryManager> userManager, SignInManager<LibraryManager> signInManager, LibraryContext db)
        {
             _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
         public IActionResult Register()
        {
            return View();
        }
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
            var user = new LibraryManager { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
         [HttpPost]
        public async Task<ActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}