using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eBookStoreClientAdmin.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public ActionResult OnGet()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToPage("./Login");
        }
    }
}
