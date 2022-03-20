using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityEF.Pages
{
    public class LogoutModel : PageModel
    {
        public SignInManager<IdentityUser> SignInManager { get; }

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await SignInManager.SignOutAsync();
            return RedirectToPage("Login");
        }

        public IActionResult OnPostNoLogoutAsync()
        {
            return RedirectToPage("Index");
        }
    }
}
