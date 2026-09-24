using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace VapeUnity.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
       private readonly IEmailSender _emailSender;

       public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Input.Email, Email = model.Input.Email };
                var result = await _userManager.CreateAsync(user, model.Input.Password);

              /*  if (result.Succeeded)
                {
                    await _emailSender.SendEmailAsync(user.Email, "Confirmação de Email", "Por favor, confirme seu email.");

                    return RedirectToAction("ConfirmationSent");
                }*/

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public IActionResult ConfirmationSent()
        {
            return View();
        }
    }

    public class RegisterModel
    {
        public RegisterInputModel Input { get; set; }
    }

    public class RegisterInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}