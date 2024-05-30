using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class DeslogarModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (TempData.ContainsKey("UsuarioLogado"))
            {
                TempData.Remove("UsuarioLogado");
                TempData.Clear();
            }

            return RedirectToPage("Index");
        }
    }
}
