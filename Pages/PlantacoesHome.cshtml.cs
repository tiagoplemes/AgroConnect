using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class PlantacoesHomeModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!TempData.ContainsKey("UsuarioLogado"))
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}