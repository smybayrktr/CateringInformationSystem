using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public HomeController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel,string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user!=null)
                {
                    await _signInManager.SignOutAsync();
                    var a= await _signInManager.PasswordSignInAsync(user, loginModel.Password,false,false);
                    if (a.Succeeded)
                    {   
                        
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Email address is not valid or password");
                }
            }

            return View();
        }
        
    }
}