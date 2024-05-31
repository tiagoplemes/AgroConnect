using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class DeslogarModel : PageModel
    {
        public IActionResult OnGet()
        {
            ClearIdCookie();

            return RedirectToPage("Index");
        }

        public void ClearIdCookie()
        {
            if (Request.Cookies.ContainsKey("UsuarioLogado"))
            {
                Response.Cookies.Delete("UsuarioLogado");
            }
        }
    }
}
