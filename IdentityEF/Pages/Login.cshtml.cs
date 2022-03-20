using IdentityEF.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityEF.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login ModelLogin { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(ModelLogin.Email, ModelLogin.Password, ModelLogin.RememberMe, false);
                if (result.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Username or Password is incorrect");
            }
            return Page();
        }
    }
}
