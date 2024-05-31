using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgroConnect.Pages
{
    public class HomeModel : PageModel
    {
        private int? _idUsuarioLogado;

        public IActionResult OnGet()
        {
            GetCookieIdUsuarioLogado();

            if (_idUsuarioLogado == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();

        }

        private void GetCookieIdUsuarioLogado()
        {
            var cookie = Request.Cookies["UsuarioLogado"];
            _idUsuarioLogado = cookie == null ? null : int.Parse(cookie);
        }
    }
}
